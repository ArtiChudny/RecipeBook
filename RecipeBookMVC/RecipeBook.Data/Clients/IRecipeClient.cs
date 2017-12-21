using System.Collections.Generic;
using RecipeBook.Data.RecipeService;

namespace RecipeBook.Data.Clients
{
    public interface IRecipeClient
    {
        IEnumerable<RecipeDto> GetRecipes();
        RecipeDetailsDto GetDedails(int id);
        IEnumerable<IngredientDto> GetIngredients();
        IEnumerable<RecipeIngredientDto> GetRecipeIngredients(int id);
        IEnumerable<RecipeDto> GetRecipesByIngredient(string ingredientName);
        IEnumerable<RecipeDto> GetRecipesByName(string recipeName);
        IEnumerable<RecipeDto> GetRecipesByCategory(string categoryName);
        
    }
}
