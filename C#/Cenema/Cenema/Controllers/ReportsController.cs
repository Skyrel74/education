using AutoMapper;
using Cenema.Factories;
using Cenema.Interfaces;
using Cenema.Models.Reports;
using LightInject;
using System.Web.Mvc;

namespace Cenema.Controllers
{
    public class ReportsController : Controller
    {
        [Inject]
        public ITicketsService TicketsService { get; set; }
        [Inject]
        public IMapper Mapper { get; set; }

        [HttpGet]
        public ActionResult Reports()
        {
            return View("~/Views/Tickets/Reports/Reports.cshtml");
        }
        [HttpGet]
        public ActionResult GetReportForm(ReportType type)
        {
            var currentView = ReportsFactory.GetReportFormView(type);
            return PartialView(currentView);
        }
        [HttpPost]
        public ActionResult BuildReport([ModelBinder(typeof(BaseReportFormModelBinder))]BaseReportsForm form)
        {
            var reportsStrategy = ReportsFactory.GetReportStrategy(form, Mapper);
            var reportLink = reportsStrategy.BuildReport();
            return View("~/View/Tickets/Reports/DownloadReport.cshtml", model: reportLink);
        }
    }
}