
using System;
using System.Web.Mvc;
using System.Linq;
using log4net;
using RecipeBook.Business.Providers;


namespace RecipeBookMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILog log = LogManager.GetLogger("Logger");
        private IRecipeProvider provider;

        public HomeController(IRecipeProvider _provider)
        {
            provider = _provider;
        }
        // GET: Home

        public ActionResult Index(int? _categoryId)
        {
            if (_categoryId == null || _categoryId==0)
            {
                return View(provider.GetRecipies().ToList());
            }
            else return View(provider.GetRecipiesByCategory(_categoryId));

        }

        public ActionResult Details(int _recipeId)
        {
            return View(provider.GetDetails(_recipeId));
        }

    }
}