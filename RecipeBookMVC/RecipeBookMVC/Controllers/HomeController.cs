using System;
using System.Web.Mvc;
using log4net;

namespace RecipeBookMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILog log = LogManager.GetLogger("Logger");
        // GET: Home
        public ActionResult Index()
        {
            log.Error("Testing Error");
            return View();
        }
    }
}