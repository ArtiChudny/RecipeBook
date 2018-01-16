using System;
using System.Web.Mvc;
using System.Linq;
using System.IO;
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
            try
            {
                DetailsViewModel details = new DetailsViewModel();
                details.recipeDetails = provider.GetDetails(_recipeId);
                details.recipeIngredients = provider.GetRecipeIngredients(_recipeId);
                var recipe = provider.GetRecipies().Where(x => x.RecipeId == _recipeId).Single();
                details.RecipeId = recipe.RecipeId;
                details.ImageUrl = recipe.PhotoUrl;
                details.RecipeName = recipe.RecipeName;
                return View(details);
            }
            catch (Exception ex)
            {
                log.Error(ex);

                return View("Error", (object)"Sorry, something went wrong. Try again later.");
            }

        }

        [HttpGet]
        public ActionResult RecipeList(int? id)
        {
            try
            {
                if (id == null || id == 0)
                {
                    var recipes = provider.GetRecipies().OrderByDescending(x => x.RecipeId);
                    return PartialView("RecipeList", recipes);
                }
                else
                {
                    var recipes = provider.GetRecipiesByCategory(id);
                    return PartialView("RecipeList", recipes);
                }
            }
            catch (Exception ex)
            {
                log.Error(ex);
                return View("Error", (object)"Sorry, something went wrong. Try again later.");
            }

        }

        public ActionResult ExportToWord(int _id)
        {
            try
            {
                var recipe = provider.GetRecipies().Where(x => x.RecipeId == _id).Single();
                var details = provider.GetDetails(_id);
                var ingredients = provider.GetRecipeIngredients(_id);

                Response.ClearContent();
                Response.Buffer = true;
                Response.AddHeader("content-disposition", "attachment; filename = Recipe.doc");
                Response.ContentType = "application/ms-word";
                Response.Charset = "";

                using (StringWriter sw = new StringWriter())
                {

                    sw.Write(recipe.RecipeName);
                    sw.WriteLine();
                    sw.Write("\nCooking time: " + details.CookingTime);
                    sw.WriteLine();
                    sw.Write("Cooking temperature: " + details.CookingTemperature);
                    sw.WriteLine();
                    sw.Write("\nIngredients:\n");
                    sw.Write("____________________________________\n");
                    foreach (var item in ingredients)
                    {
                        sw.Write(item.IngredientName + " : " + item.Weight);
                        sw.WriteLine();
                    }
                    sw.Write("____________________________________");
                    sw.Write("\n\nSteps:\n");
                    sw.Write(details.Steps);

                    Response.Output.Write(sw.ToString());
                    Response.Flush();
                    Response.End();
                }
                return View();
            }
            catch (Exception ex)
            {
                log.Error(ex);
                return View("Error", (object)"Sorry, something went wrong. Try again later.");
            }

        }

    }
}