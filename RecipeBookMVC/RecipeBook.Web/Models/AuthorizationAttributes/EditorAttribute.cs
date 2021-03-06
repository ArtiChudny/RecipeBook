﻿using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using RecipeBook.Web.Models.Principal;

namespace RecipeBook.Web.Models.AuthorizationAttributes
{
    public class EditorAttribute : AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            {
                var user = HttpContext.Current.User as UserPrincipal;
                if (user != null)
                {
                    if (!user.IsInRole("Editor") || !user.IsInRole("Admin"))
                    {
                        filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "Login", action = "Denied", requiredRole = "Editor" }));
                    }
                }
                else
                {
                    filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "Login", action = "Login" }));
                }
            }
        }
    }
}