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

        public LoginService(IUserProvider _userProvider)
        {
            userProvider = _userProvider;
        }

        public LoginResult Login(string login, string password)
        {
            try
            {
                var user = userProvider.GetUserByLogin(login);
                if (user==null)
                {
                    return LoginResult.InvalidCredentials;
                }
                else
                {
                    if (!(user.Login == login && user.Password == password))
                    {
                        return LoginResult.InvalidCredentials;
                    }
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
                throw new Exception("Authentification error", ex);
            }
        }

        public void Logout()
        {
            FormsAuthentication.SignOut();
        }
    }
}
