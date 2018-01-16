using System;
using System.Web;
using System.Web.Mvc;
using System.Linq;
using System.IO;
using log4net;
using PagedList;
using RecipeBook.Business.Providers;
using RecipeBook.Common.Models;
using RecipeBook.Web.Models;

namespace RecipeBook.Web.Controllers
{
    [Authorize(Roles = "Editor")]
    public class EditorController : Controller
    {
        int pageSize = 10;
        private readonly ILog log = LogManager.GetLogger("Logger");
        private IRecipeProvider recipeProvider;
        private ICategoryProvider categoryProvider;

        public EditorController(IRecipeProvider _recipeProvider, ICategoryProvider _categoryProvider)
        {
            recipeProvider = _recipeProvider;
            categoryProvider = _categoryProvider;
        }


        public ActionResult Index(int? id)
        {
            ViewBag.Id = id;
            return View();
        }

        [HttpGet]
        public ActionResult IngredientsList(int? page)
        {
            try
            {
                int pageNumber = (page ?? 1);
                var ingredients = recipeProvider.GetIngredients().OrderBy(x => x.IngredientName);
                return PartialView("IngredientsList", ingredients.ToPagedList(pageNumber, pageSize));
            }
            catch (Exception ex)
            {
                log.Error(ex);
                return View("Error", (object)"Sorry, something went wrong. Try again later.");
            }
        }

        [HttpGet]
        public ActionResult Addingredient()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddIngredient(Ingredient ingredient)
        {
            if (ingredient.IngredientName == null)
            {
                ModelState.AddModelError("IngredientName", "Field Name is required");
            }
            if (ModelState.IsValid)
            {
                try
                {
                    recipeProvider.AddIngredient(ingredient);
                    return RedirectToAction("Index", new { id = 3 });
                }
                catch (Exception ex)
                {
                    log.Error(ex);
                    return View("Error", (object)"Sorry, something went wrong. Try again later.");
                }
            }
            else
            {
                return View();
            }

        }

        [HttpGet]
        public ActionResult EditIngredient(int id)
        {
            var ingredient = recipeProvider.GetIngredients().Where(x => x.IngredientId == id).Single();
            return View(ingredient);
        }

        [HttpPost]
        public ActionResult EditIngredient(Ingredient ingredient)
        {
            if (ingredient.IngredientName == null)
            {
                ModelState.AddModelError("IngredientName", "Field Name is required");
            }

            if (ModelState.IsValid)
            {
                try
                {
                    recipeProvider.UpdateIngredient(ingredient);
                    return RedirectToAction("Index", new { id = 3 });
                }
                catch (Exception ex)
                {
                    log.Error(ex);
                    return View("Error", (object)"Sorry, something went wrong. Try again later.");
                }
            }
            else
            {
                return View(ingredient);
            }

        }

        public ActionResult DeleteIngredient(int id)
        {
            try
            {
                recipeProvider.DeleteIngredient(id);
                return RedirectToAction("IngredientsList");

            }
            catch (Exception ex)
            {
                log.Error(ex);
                return View("Error", (object)"Sorry, something went wrong. Try again later.");
            }

        }

        [HttpGet]
        public ActionResult CategoriesList(int? page)
        {
            try
            {
                int pageNumber = (page ?? 1);
                var categories = categoryProvider.GetCategories();
                return PartialView("CategoriesList", categories.ToPagedList(pageNumber, pageSize));
            }
            catch (Exception ex)
            {
                log.Error(ex);
                return View("Error", (object)"Sorry, something went wrong. Try again later.");
            }

        }

        [HttpGet]
        public ActionResult AddCategory()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddCategory(Category category)
        {
            if (category.CategoryName == null)
            {
                ModelState.AddModelError("CategoryName", "Field Name is required");
            }
            if (ModelState.IsValid)
            {
                try
                {
                    categoryProvider.AddCategory(category);
                    return RedirectToAction("Index", new { id = 1 });
                }
                catch (Exception ex)
                {
                    log.Error(ex);
                    return View("Error", (object)"Sorry, something went wrong. Try again later.");
                }
            }
            else
            {
                return View();
            }

        }

        [HttpGet]
        public ActionResult EditCategory(int id)
        {
            var category = categoryProvider.GetCategories().Where(x => x.CategoryId == id).FirstOrDefault();
            return View(category);
        }

        [HttpPost]
        public ActionResult EditCategory(Category category)
        {
            if (category.CategoryName == null)
            {
                ModelState.AddModelError("CategoryName", "Field Name is required");
            }
            if (ModelState.IsValid)
            {
                try
                {
                    categoryProvider.UpdateCategory(category);
                    return RedirectToAction("Index", new { id = 1 });
                }
                catch (Exception ex)
                {
                    log.Error(ex);
                    return View("Error", (object)"Sorry, something went wrong. Try again later.");
                }
            }
            else
            {
                return View(category);
            }
        }


        public ActionResult DeleteCategory(int id)
        {
            try
            {
                categoryProvider.DeleteCategory(id);
                return RedirectToAction("CategoriesList");
            }
            catch (Exception ex)
            {
                log.Error(ex);
                return View("Error", (object)"Sorry, something went wrong. Try again later.");
            }
        }

        [HttpGet]
        public ActionResult RecipesList(int? page)
        {
            try
            {
                int pageNumber = (page ?? 1);
                var users = recipeProvider.GetRecipies().OrderByDescending(x => x.RecipeId);
                return PartialView("RecipesList", users.ToPagedList(pageNumber, pageSize));
            }
            catch (Exception ex)
            {
                log.Error(ex);
                return View("Error", (object)"Sorry, something went wrong. Try again later.");
            }

        }

        public ActionResult DeleteRecipe(int id)
        {
            try
            {
                recipeProvider.DeleteRecipe(id);
                return RedirectToAction("RecipesList");
            }
            catch (Exception ex)
            {
                log.Error(ex);
                return View("Error", (object)"Sorry, something went wrong. Try again later.");
            }
        }

        [HttpGet]
        public ActionResult AddRecipe()
        {
            try
            {
                ViewBag.categories = categoryProvider.GetCategories().OrderBy(x => x.CategoryName);
                ViewBag.ingredients = recipeProvider.GetIngredients().OrderBy(x => x.IngredientName);
                return View("AddRecipe");
            }
            catch (Exception ex)
            {
                log.Error(ex);
                return View("Error", (object)"Sorry, something went wrong. Try again later.");
            }
        }

        [HttpPost]
        public ActionResult AddRecipe(RecipeViewModel model, HttpPostedFileBase upload)
        {
            var ingredients = model.Ingredients.ToList();
            int n = 0;
            foreach (var item in model.Ingredients)
            {
                if (item.IngredientId == 0 || item.Weight == null)
                {
                    ModelState.AddModelError("Ingredients", "There should be no empty fields!");
                    break;
                }
                if (ingredients.Exists(x => x.IngredientId == item.IngredientId))
                {
                    n++;
                }
            }
            if (n > 1)
            {
                ModelState.AddModelError("Ingredients", "There should not be the same ingredients!");
            }

            if (ModelState.IsValid)
            {
                try
                {
                    RecipeDetails details = new RecipeDetails()
                    {
                        Description = model.Description,
                        CookingTime = model.CookingTime,
                        CookingTemperature = model.CookingTemperature,
                        Steps = model.Steps
                    };
                    Recipe recipe = new Recipe()
                    {
                        RecipeName = model.RecipeName,
                        CategoryId = model.CategoryId,
                        Details = details
                    };
                    if (upload != null)
                    {
                        string fileName = Path.GetFileName(upload.FileName);
                        upload.SaveAs(Server.MapPath("~/Images/" + fileName));
                        recipe.PhotoUrl = "/Images/" + fileName;
                    }
                    else
                    {
                        recipe.PhotoUrl = null;
                    }
                    int NewRecipeId = recipeProvider.AddRecipe(recipe);
                    foreach (var item in model.Ingredients)
                    {
                        item.RecipeId = NewRecipeId;
                        recipeProvider.AddRecipeIngredient(item);
                    }
                    return RedirectToAction("Index", new { id = 2 });
                }
                catch (Exception ex)
                {
                    log.Error(ex);
                    return View("Error", (object)"Sorry, something went wrong. Try again later.");
                }
            }
            else
            {
                ViewBag.categories = categoryProvider.GetCategories().OrderBy(x => x.CategoryName);
                ViewBag.ingredients = recipeProvider.GetIngredients().OrderBy(x => x.IngredientName);
                return View(model);
            }

        }

        [HttpGet]
        public ActionResult EditRecipe(int id)
        {
            try
            {
                ViewBag.categories = categoryProvider.GetCategories().OrderBy(x => x.CategoryName);
                ViewBag.ingredients = recipeProvider.GetIngredients().OrderBy(x => x.IngredientName);
                var recipe = recipeProvider.GetRecipies().Where(x => x.RecipeId == id).SingleOrDefault();
                var recipeDetails = recipeProvider.GetDetails(id);
                var ingredients = recipeProvider.GetRecipeIngredients(id);

                RecipeViewModel model = new RecipeViewModel()
                {
                    RecipeId = recipe.RecipeId,
                    CategoryId = recipe.CategoryId,
                    RecipeName = recipe.RecipeName,
                    PhotoUrl = recipe.PhotoUrl,
                    CookingTemperature = recipeDetails.CookingTemperature,
                    CookingTime = recipeDetails.CookingTime,
                    Description = recipeDetails.Description,
                    Steps = recipeDetails.Steps,
                    Ingredients = ingredients.ToArray()
                };

                return View(model);
            }
            catch (Exception ex)
            {
                log.Error(ex);
                return View("Error", (object)"Sorry, something went wrong. Try again later.");
            }
        }

        [HttpPost]
        public ActionResult EditRecipe(RecipeViewModel model, HttpPostedFileBase upload)
        {
            var ingredients = model.Ingredients.ToList();
            int n = 0;
            foreach (var item in model.Ingredients)
            {
                if (item.IngredientId == 0 || item.Weight == null)
                {
                    ModelState.AddModelError("Ingredients", "There should be no empty fields!");
                    break;
                }
                if (ingredients.Exists(x => x.IngredientId == item.IngredientId))
                {
                    n++;
                }
            }
            if (n > 1)
            {
                ModelState.AddModelError("Ingredients", "There should not be the same ingredients!");
            }
            if (ModelState.IsValid)
            {
                try
                {
                    RecipeDetails details = new RecipeDetails()
                    {
                        RecipeId = model.RecipeId,
                        Description = model.Description,
                        CookingTime = model.CookingTime,
                        CookingTemperature = model.CookingTemperature,
                        Steps = model.Steps
                    };
                    Recipe recipe = new Recipe()
                    {
                        RecipeId = model.RecipeId,
                        RecipeName = model.RecipeName,
                        CategoryId = model.CategoryId,
                        PhotoUrl = model.PhotoUrl,
                        Details = details
                    };
                    if (upload != null)
                    {
                        string fileName = Path.GetFileName(upload.FileName);
                        upload.SaveAs(Server.MapPath("~/Images/" + fileName));
                        recipe.PhotoUrl = "/Images/" + fileName;
                    }
                    else
                    {
                        recipe.PhotoUrl = model.PhotoUrl;
                    }
                    recipeProvider.UpdateRecipe(recipe);
                    recipeProvider.UpdateRecipeDetails(details);
                    recipeProvider.DeleteRecipeIngredients(recipe.RecipeId);
                    foreach (var item in model.Ingredients)
                    {
                        item.RecipeId = recipe.RecipeId;
                        recipeProvider.AddRecipeIngredient(item);
                    }

                    return RedirectToAction("Index", new { id = 2 });
                }

                catch (Exception ex)
                {
                    log.Error(ex);
                    return View("Error", (object)"Sorry, something went wrong. Try again later.");
                }
            }
            else
            {
                ViewBag.categories = categoryProvider.GetCategories().OrderBy(x => x.CategoryName);
                ViewBag.ingredients = recipeProvider.GetIngredients().OrderBy(x => x.IngredientName);
                return View(model);
            }
        }

    }
}