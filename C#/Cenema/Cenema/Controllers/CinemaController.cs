using Cenema.Models;
using System.Web.Mvc;

namespace Cenema.Controllers
{
    public class CinemaController : Controller
    {
        // GET: Cinema
        public ActionResult Index(string param)
        {
            ViewData["Param"] = param;
            ViewBag.Param = param;
            return View(new CinemaViewModel() { Author = "Me" });
        }
    }
}