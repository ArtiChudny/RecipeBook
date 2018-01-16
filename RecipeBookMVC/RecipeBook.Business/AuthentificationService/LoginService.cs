using System;
using System.Web;
using System.Web.Security;
using Newtonsoft.Json;
using RecipeBook.Common.Enums;
using RecipeBook.Business.Providers;

namespace RecipeBook.Business.AuthentificationService
{
    public class LoginService : ILoginService
    {
        private IUserProvider userProvider;
        private IValidationService validationService;

        public LoginService(IUserProvider _userProvider, IValidationService _validationService)
        {
            userProvider = _userProvider;
            validationService = _validationService;
        }

        public LoginResult Login(string login, string password)
        {
            if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password))
            {
                return LoginResult.EmptyCredentials;
            }
            try
            {
                var user = userProvider.GetUserByLogin(login);

                if (validationService.IsValidUser(login, password))
                {
                    var userData = JsonConvert.SerializeObject(user);
                    var ticket = new FormsAuthenticationTicket(2, login, DateTime.Now, DateTime.Now.AddHours(1), false, userData);
                    var encTicket = FormsAuthentication.Encrypt(ticket);
                    var authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encTicket);
                    HttpContext.Current.Response.Cookies.Add(authCookie);
                    return LoginResult.NoError;
                }
            }
            catch (Exception ex)
            {
                return LoginResult.InvalidCredentials;
                throw ex;
            }
            return LoginResult.InvalidCredentials;

        }

        public void Logout()
        {
            FormsAuthentication.SignOut();
        }
    }
}
