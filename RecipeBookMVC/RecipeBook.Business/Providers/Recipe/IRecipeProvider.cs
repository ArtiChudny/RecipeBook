using System.Collections.Generic;
using RecipeBook.Common.Models;

namespace RecipeBook.Business.Providers
{
    public interface IRecipeProvider
    {
        IEnumerable<Recipe> GetRecipies();
        IEnumerable<Ingredient> GetIngredients();
        IEnumerable<Recipe> GetRecipiesByCategory(int? id);
        RecipeDetails GetDetails(int id);
        IEnumerable<RecipeIngredient> GetRecipeIngredients(int id);
        IEnumerable<Recipe> GetRecipesByIngredient(string ingredientName);
        IEnumerable<Recipe> GetRecipesByName(string recipeName);
        IEnumerable<Recipe> GetRecipesByCategory(string categoryName);
    }
}
