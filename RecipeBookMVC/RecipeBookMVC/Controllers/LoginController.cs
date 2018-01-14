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
        public ActionResult Login(LoginViewModel model)
        {

            if (ModelState.IsValid)
            {
                var result = loginService.Login(model.Login, model.Password);
                if (result == LoginResult.InvalidCredentials)
                {
                    model.Message = "Invalid credentials";
                    return View();
                }
                if (result == LoginResult.NoError)
                {
                    return RedirectToAction("Index", "Home");
                }

            }
            return View();
        }

        public ActionResult Logout()
        {
            loginService.Logout();
            return RedirectToAction("Index", "Home");
        }
    }
}