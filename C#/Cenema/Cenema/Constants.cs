using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace Cenema
{
    public class Constants
    {
        public static string ReportsDirectory => ConfigurationManager.AppSettings["ReportsDirectory"];
        public static string ExcelTemplateDirectory => ConfigurationManager.AppSettings["ExcelTemplateDirectory"];
    }
}