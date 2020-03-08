﻿using AutoMapper;
using Cenema.Reports;
using Cenema.Utils;
using NPOI.SS.UserModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Web.Hosting;

namespace Cenema.Models.Reports
{
    public abstract class ReportsBaseStrategy<T> : IReportBuilder
    {
        protected SqlDatabaseUtil DatabaseUtil { get; set; }
        public Dictionary<string, object> Parameters { get; set; }

        protected ReportsBaseStrategy(IMapper mapper)
        {
            DatabaseUtil = new SqlDatabaseUtil(mapper);
            Parameters = new Dictionary<string, object>();
        }

        public string BuildReport()
        {
            var model = GetDataModel();
            CreateReportsDirectoryIfNotExists();
            var filename = Path.Combine(Constants.ReportsDirectory, string.Concat(InternalGetDownloadFileName(), DateTime.Now.ToString("_yyyyMMdd-hhmmss"), GetTargetExtention()));
            InternalBuildReport(filename, model);
            return GetFileLinkUrl(filename);
        }

        protected string TemplateFileName => InternalGetTemplateFileName();

        protected abstract string InternalGetTemplateFileName();
        protected abstract string InternalGetDownloadFileName();
        protected abstract T GetDataModel();
        protected string GetFileLinkUrl(string filePath)
        {
            var approot = HostingEnvironment.MapPath(Path.Combine(Constants.ExcelTemplateDirectory, TemplateFileName)).TrimEnd('\\');
            return filePath.Replace(approot, string.Empty).Replace("\\", "/");
        }
        protected void InternalBuildReport(string filename, T model)
        {
            var templatePath = HostingEnvironment.MapPath(Path.Combine(Constants.ExcelTemplateDirectory, TemplateFileName));
           

            using (var templateFileStream = new FileStream(templatePath, FileMode.Open, FileAccess.Read))
            {
                var workbook = WorkbookFactory.Create(templateFileStream);
                ProcessWorkbook(workbook, model);
                SaveWorkbook(workbook, filename);
            }
        }

        protected abstract void ProcessWorkbook(IWorkbook workbook, T model);
        private void SaveWorkbook(IWorkbook workbook, string filename)
        {
            var targetPath = HostingEnvironment.MapPath(filename);
            if (string.IsNullOrEmpty(targetPath))
            {
                throw new ApplicationException($"Unable to map path \"{targetPath}\".");
            }
            if (File.Exists(targetPath))
            {
                File.Delete(targetPath);
            }
            using(var outputFileStream = new FileStream(targetPath, FileMode.CreateNew))
            {
                workbook.Write(outputFileStream);
                outputFileStream.Close();
            }
        }

        private string GetTargetExtention()
        {
            return Path.GetExtension(TemplateFileName);
        }

        private static void CreateReportsDirectoryIfNotExists()
        {
            try
            {
                var reportsPath = HostingEnvironment.MapPath(Constants.ReportsDirectory);
                if (string.IsNullOrEmpty(reportsPath))
                {
                    throw new ApplicationException($"Unable to map path \"{reportsPath}\".");
                }
                if (!Directory.Exists(reportsPath))
                {
                    Directory.CreateDirectory(reportsPath);
                }
            }
            catch(Exception e)
            {
                throw new ApplicationException($"Unable to create Reports directory", e);
            }
        }
    }
}