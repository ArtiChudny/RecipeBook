using System.Web.Mvc;
using RecipeBook.Business.Providers;

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
            var categories = provider.GetCategories();
            return PartialView("CategoriesList",categories);
        }


    }
}