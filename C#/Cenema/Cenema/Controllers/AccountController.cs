using Cenema.Models;
using System.Web.Mvc;

namespace Cenema.Controllers
{
    public class AccountController : Controller
    {
        [HttpGet]
        public ActionResult Login()
        {
            var model = new LoginModel() { Login = "user"};
            return View(model);
        }

        [HttpPost]
        public ActionResult Login(LoginModel model)
        {
            if(ModelState.IsValid)
            {
                return View("LoginResult", model);
            }
            return View(model);
        }
    }
}