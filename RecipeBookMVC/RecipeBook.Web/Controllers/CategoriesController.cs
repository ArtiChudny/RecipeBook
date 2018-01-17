using System;
using System.Web.Mvc;
using log4net;
using RecipeBook.Business.Providers;

namespace RecipeBookMVC.Controllers
{

    public class CategoriesController : Controller
    {
        private ICategoryProvider provider;
        private readonly ILog log = LogManager.GetLogger("Logger");

        public CategoriesController(ICategoryProvider _provider)
        {
            provider = _provider;
        }

        public ActionResult CategoriesList()
        {
            try
            {
                var categories = provider.GetCategories();
                return PartialView("CategoriesList", categories);
            }
            catch (Exception ex)
            {
                log.Error(ex);
                return View("Error", (object)"Sorry, something went wrong. Try again later.");
            }
           
        }


    }
}