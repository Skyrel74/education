using AutoMapper;
using Cenema.Models.Reports;
using Cenema.Reports;
using System;
using System.Web.Mvc;

namespace Cenema.Factories
{
    public static class ReportsFactory
    {
        public static string GetReportFormView(ReportType type)
        {
            switch (type)
            {
                case ReportType.PontialRealProfit:
                    return "~/Views/Tickets/Reports/PotentialRealProfitForm.cshtml";
                /*case ReportType.UnprofitableMovies:
                    return "~/Views/Tickets/Reports/UnprofitableMoviesForm.cshtml";*/
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }
        }

        public static BaseReportsForm GetReportFormModel(ControllerContext context, ReportType type, IMapper mapper)
        {
            switch (type)
            {
                case ReportType.PontialRealProfit:
                    return mapper.Map<PotentialRealProfitReportForm>(context);
                /*case ReportType.UnprofitableMovies:
                    return mapper.Map<UnprofitableMoviesReportForm>(context);*/
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }
        }

        public static IReportBuilder GetReportStrategy(BaseReportsForm form, IMapper mapper)
        {
            switch (form.ReportType)
            {
                case ReportType.PontialRealProfit:
                    {
                        var formModel = (PotentialRealProfitReportForm)form;
                        var strategy = new PotentialRealProfitReportStrategy(mapper)
                        {
                            Parameters = formModel.GetParameters()
                        };
                        return strategy;
                    }
                /*case ReportType.UnprofitableMovies:
                    {
                        var formModel = (UnprofitableMoviesReportForm)form;
                        var strategy = new UnprofitableMoviesReportStrategy(mapper)
                        {
                            Parameters = formModel.GetParameters()
                        };
                        return strategy;
                    }*/
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}