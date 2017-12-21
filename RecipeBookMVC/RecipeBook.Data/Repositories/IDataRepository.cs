using RecipeBook.Common.Models;
using System.Collections.Generic;

namespace RecipeBook.Data.Repositories
{
    public interface IDataRepository
    {
        IEnumerable<Recipe> GetRecipies();
        IEnumerable<Category> GetCategories();
        IEnumerable<Ingredient> GetIngredients();
        IEnumerable<RecipeIngredient> GetRecipeIngredients(int id);
        IEnumerable<Recipe> GetRecipesByIngredient(string ingredientName);
        IEnumerable<Recipe> GetRecipesByName(string recipeName);
        IEnumerable<Recipe> GetRecipesByCategory(string categoryName);
        RecipeDetails GetDedails(int id);

    }
}
