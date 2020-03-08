using System.Web.Mvc;
using AutoMapper;
using Cenema.Factories;
using Cenema.Models.Reports;

namespace Cenema
{
    public class BaseReportFormModelBinder : DefaultModelBinder
    {
        private readonly IMapper _mapper;

        public BaseReportFormModelBinder()
        {
            _mapper = DependencyResolver.Current.GetService<IMapper>();
        }

        public override object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            if (!(base.BindModel(controllerContext, bindingContext) is BaseReportsForm model))
                return null;

            return ReportsFactory.GetReportFormModel(controllerContext, model.ReportType, _mapper);
        }
    }
}