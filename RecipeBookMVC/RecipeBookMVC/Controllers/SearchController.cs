using System.Web.Mvc;
using System.Linq;
using System.Collections.Generic;
using log4net;
using RecipeBook.Common.Models;
using RecipeBook.Business.Providers;
using RecipeBook.Web.Models;
using System;

namespace RecipeBook.Web.Controllers
{
    public class SearchController : Controller
    {
        private IRecipeProvider recipeProvider;
        private ICategoryProvider categoryProvider;
        public SearchController(IRecipeProvider _recipeProvider, ICategoryProvider _categoryProvider)
        {
            recipeProvider = _recipeProvider;
            categoryProvider = _categoryProvider;
        }


        public ActionResult SearchByIngredient()
        {
            return PartialView("SearchResult");
        }

        [HttpPost]
        public ActionResult SearchByIngredient(SearchViewModel model)
        {
            if (model == null)
            {
                throw new NullReferenceException();
            }

            IEnumerable<Recipe> recipes;

            if (model.RecipeName == null || model.IngredientName == null || model.CategoryName == null)
            {
                if (model.CategoryName == null && model.IngredientName == null)
                {
                    recipes = recipeProvider.GetRecipesByName(model.RecipeName);
                    return PartialView("SearchResult", recipes);
                }

                if (model.CategoryName == null && model.RecipeName == null)
                {
                    recipes = recipeProvider.GetRecipesByIngredient(model.IngredientName);
                    return PartialView("SearchResult", recipes);
                }

                if (model.IngredientName == null && model.RecipeName == null)
                {
                    recipes = recipeProvider.GetRecipesByCategory(model.CategoryName);
                    return PartialView("SearchResult", recipes);
                }

                if (model.IngredientName == null)
                {
                    recipes = recipeProvider.GetRecipesByCategory(model.CategoryName).Where(x => x.RecipeName == model.RecipeName);
                    return PartialView("SearchResult", recipes);
                }

                if (model.RecipeName == null)
                {
                    var category = categoryProvider.GetCategories().FirstOrDefault(x => x.CategoryName.Contains(model.CategoryName));
                    recipes = recipeProvider.GetRecipesByIngredient(model.IngredientName).Where(x => x.CategoryId == category.CategoryId);
                    return PartialView("SearchResult", recipes);
                }

                if (model.CategoryName == null)
                {
                    recipes = recipeProvider.GetRecipesByIngredient(model.IngredientName).Where(x => x.RecipeName == model.RecipeName);
                    return PartialView("SearchResult", recipes);
                }

            }
            else
            {
                var category = categoryProvider.GetCategories().FirstOrDefault(x => x.CategoryName.Contains(model.CategoryName));
                recipes = recipeProvider.GetRecipesByIngredient(model.IngredientName).Where(x => x.CategoryId == category.CategoryId);
                recipes = recipes.Where(x => x.RecipeName.Contains(model.RecipeName));
                return PartialView("SearchResult", recipes);
            }
           
            return PartialView("SearchResult");
        }

        public ActionResult Search()
        {
            ViewBag.categories = categoryProvider.GetCategories();
            ViewBag.ingredients = recipeProvider.GetIngredients().OrderBy(x=>x.IngredientName);
            return View();
        }
    }
}