
using System.Collections.Generic;
using System.Web.Mvc;
using RecipeBook.Business.Providers;
using RecipeBookMVC.Models;

namespace RecipeBookMVC.Controllers
{
    public class CategoriesController : Controller
    {
        private ICategoryProvider provider;

        public CategoriesController(ICategoryProvider _provider)
        {
            provider = _provider;
        }

        // GET: Categories

        public ActionResult CategoriesList()
        {
           
            return View(provider.GetCategories());
        }


    }
}