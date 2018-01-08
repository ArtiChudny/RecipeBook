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

        void AddIngredient(IngredientDto ingredient);
        void DeleteIngredient(int ingredientId);
        void UpdateIngredient(IngredientDto ingredient);

        void AddRecipeIngredient(RecipeIngredientDto ingredient);
        void DeleteRecipeIngredient(int recipeId, int ingredientId);
        void DeleteRecipeIngredients(int recipeId);

        int AddRecipe(RecipeDto recipe);
        void DeleteRecipe(int recipeId);
        void UpdateRecipe(RecipeDto recipe);

        void AddRecipeDetails(RecipeDetailsDto details);
        void UpdateRecipeDetails(RecipeDetailsDto details);

    }
}
