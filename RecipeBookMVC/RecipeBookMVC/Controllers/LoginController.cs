using System.Web.Mvc;
using RecipeBook.Business.AuthentificationService;
using RecipeBook.Common.Enums;
using RecipeBook.Web.Models;

namespace RecipeBook.Web.Controllers
{
    public class LoginController : Controller
    {
        private readonly ILoginService loginService;

        public LoginController(ILoginService _loginService)
        {
            loginService = _loginService;
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string login, string password)
        {
            var result = loginService.Login(login, password);
            if (result == LoginResult.NoError)
            {
                return RedirectToAction("Index", "Home");
            }
            var model = new LoginViewModel();

            if (result == LoginResult.EmptyCredentials)
            {
                model.Message = "Empty credentials";
            }
            if (result == LoginResult.InvalidCredentials)
            {
                model.Message = "Invalid credentials";
            }
            return View(model);
        }

        public ActionResult Logout()
        {
            loginService.Logout();
            return RedirectToAction("Login", "Login");
        }
    }
}