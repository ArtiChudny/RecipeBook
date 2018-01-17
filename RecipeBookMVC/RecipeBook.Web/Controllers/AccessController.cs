using System.Web.Mvc;

namespace RecipeBook.Web.Controllers
{
    public class AccessController : Controller
    {
        // GET: Access
        public ActionResult Denied(string message)
        {
            return View(message);
        }
    }
}