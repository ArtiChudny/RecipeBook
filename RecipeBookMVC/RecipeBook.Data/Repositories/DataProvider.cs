using System.Collections.Generic;
using RecipeBook.Data.Converters;
using RecipeBook.Common.Models;
using RecipeBook.Data.Clients;
using RecipeBook.Data.RecipeService;
using RecipeBook.Data.CategoryService;

namespace RecipeBook.Data.Repositories
{
    public class DataProvider : IDataProvider
    {
        IRecipeClient _recipeClient;
        ICategoryClient _categoryClient;
        IConverter _converter;

        public DataProvider(IRecipeClient recipeClient, ICategoryClient categoryClient, IConverter converter)
        {
            _converter = converter;
            _recipeClient = recipeClient;
            _categoryClient = categoryClient;
        }

        public IEnumerable<Category> GetCategories()
        {
            IEnumerable<CategoryDto> categoriesDto = _categoryClient.GetCategories();
            List<Category> categoryList = new List<Category>();
            IEnumerable<Category> categories;
            if (categoriesDto != null)
            {
                foreach (var item in categoriesDto)
                {
                    categoryList.Add(_converter.ToCategory(item));
                }
            }
            categories = categoryList;
            return categories;
        }

        public RecipeDetails GetDedails(int id)
        {
            RecipeDetailsDto detailsDto = _recipeClient.GetDedails(id);
            RecipeDetails details = new RecipeDetails();
            if (detailsDto != null)
            {
                details = _converter.ToRecipeDetails(detailsDto);
            }
            return details;
        }

        public IEnumerable<Recipe> GetRecipies()
        {
            IEnumerable<RecipeDto> recipesDto = _recipeClient.GetRecipes();
            List<Recipe> recipeList = new List<Recipe>();
            IEnumerable<Recipe> recipies;
            if (recipesDto != null)
            {
                foreach (var item in recipesDto)
                {
                    recipeList.Add(_converter.ToRecipe(item));
                }
            }
            recipies = recipeList;
            return recipies;
        }

    }
}
