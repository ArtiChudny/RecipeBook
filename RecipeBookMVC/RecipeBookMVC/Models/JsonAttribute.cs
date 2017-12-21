using System.Reflection;
using System.Web.Mvc;

namespace RecipeBook.Web.Models
{
    public class JsonAttribute : ActionMethodSelectorAttribute
    {
        public override bool IsValidForRequest(ControllerContext controllerContext, MethodInfo methodInfo)
        {
            return controllerContext.HttpContext.Request.IsAjaxRequest();
        }
    }
}