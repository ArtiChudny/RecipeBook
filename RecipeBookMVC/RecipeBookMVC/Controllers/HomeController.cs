using System.Web.Mvc;
using System.Linq;
using log4net;
using RecipeBook.Business.Providers;
using RecipeBook.Web.Models;

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
    
        public ActionResult Index()
        {
            return View();
        }
    
        public ActionResult Details(int _recipeId)
        {
            DetailsViewModel details = new DetailsViewModel();
            details.recipeDetails = provider.GetDetails(_recipeId);
            details.recipeIngredients = provider.GetRecipeIngredients(_recipeId);
            var recipe = provider.GetRecipies().Where(x => x.RecipeId == _recipeId).Single();
            details.ImageUrl = recipe.PhotoUrl;
            details.RecipeName = recipe.RecipeName;
            return View(details);
        }

        [HttpGet]
        public ActionResult RecipeList(int? id)
        {
            if (id == null || id == 0)
            {
                var recipes = provider.GetRecipies().OrderByDescending(x=>x.RecipeId);
                return PartialView("RecipeList",recipes);
            }
            else
            {
                var recipes = provider.GetRecipiesByCategory(id);
                return PartialView("RecipeList",recipes);
            }
        }

    }
}