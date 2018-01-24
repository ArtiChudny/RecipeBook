using System;
using System.Web.Mvc;
using RecipeBook.Business.AuthentificationService;
using log4net;
using RecipeBook.Common.Enums;
using RecipeBook.Web.Models;

namespace RecipeBook.Web.Controllers
{
    public class LoginController : Controller
    {
        private readonly ILog log = LogManager.GetLogger("Logger");
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
                try
                {
                    var result = loginService.Login(model.Login, model.Password);
                    if (result == LoginResult.InvalidCredentials)
                    {
                        ModelState.AddModelError("Password", "Unable to log in. Check your login and password.");
                        return View();
                    }
                    if (result == LoginResult.NoError)
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
                catch (Exception ex)
                {
                    log.Error(ex);
                    return View("Error", (object)"Sorry, something went wrong. Try again later.");
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