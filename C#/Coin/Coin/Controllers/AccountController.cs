using Coin.API;
using Coin.Models;
using Coin.Services;
using LightInject;
using System.Web.Mvc;

namespace Coin.Controllers
{
    public class AccountController : Controller
    {
        [Inject]
        public IUsersService TicketsService { get; set; }

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(LoginModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            if (TicketsService.Register(model))
            {
                return RedirectToAction("Login");
            }
            ModelState.AddModelError("Email", "User with this email is already registered");
            return View(model);
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginModel model)
        {
            if (TicketsService.Login(model))
            {
                return RedirectToAction("Coin");
            }
            ModelState.AddModelError("", "Account with that data does not exist");
            return View(model);
        }

        [HttpGet]
        public ActionResult Coin()
        {
            var coins = TicketsService.GetAllCoins();
            return View("Coin", coins);
        }
    }
}