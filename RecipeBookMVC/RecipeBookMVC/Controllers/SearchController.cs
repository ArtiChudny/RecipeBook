using System.Web.Mvc;
using System.Linq;
using System.Collections.Generic;
using log4net;
using RecipeBook.Business.Providers;
using RecipeBook.Web.Models;
using RecipeBook.Common.Models;

namespace RecipeBook.Web.Controllers
{
    public class SearchController : Controller
    {
        private IRecipeProvider recipeProvider;
        public SearchController(IRecipeProvider _recipeProvider)
        {
            recipeProvider = _recipeProvider;
        }

        public ActionResult SearchByIngredient(string ingredientName)
        {
            IEnumerable<Recipe> recipes = recipeProvider.GetRecipesByIngredient(ingredientName);
            return View(recipes);

        }
        public ActionResult Index()
        {
            return View();
        }
    }
}