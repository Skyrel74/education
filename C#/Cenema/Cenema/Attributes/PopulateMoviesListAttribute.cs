using System.Web;
using System.Web.Mvc;
using Cenema.Interfaces;
using Cenema.Services;
using LightInject;

namespace Cenema.Attributes
{
    public class PopulateMoviesListAttribute : ActionFilterAttribute
    {
        [Inject]
        public ITicketsService TicketsSetvice { get; set; }
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            filterContext.Controller.ViewData["MoviesList"] = TicketsSetvice.GetAllMovies();
            base.OnActionExecuting(filterContext);
        }
    }
}