using System;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using Newtonsoft.Json;
using RecipeBook.Common.Models;
using RecipeBook.Web.Models.Principal;
using System.Web;

namespace RecipeBookMVC
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }

        public void Application_PostAuthenticateRequest(Object sender, EventArgs e)
        {
            var auth = HttpContext.Current.Request.Cookies[FormsAuthentication.FormsCookieName];
            if (auth != null)
            {
                FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(auth.Value);
                User model = JsonConvert.DeserializeObject<User>(ticket.UserData);
                UserPrincipal principal = new UserPrincipal(ticket.Name)
                {
                    UserId = model.UserId,
                    Login = model.Login,
                    Roles = model.Roles
                };
                HttpContext.Current.User = principal;
            }
        }
    }
}
