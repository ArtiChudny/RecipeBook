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

        void AddIngredient(Ingredient ingredient);
        void DeleteIngredient(int ingredientId);
        void UpdateIngredient(Ingredient ingredient);

        void AddRecipeIngredient(RecipeIngredient ingredient);
        void DeleteRecipeIngredient(int recipeId, int ingredientId);
        void DeleteRecipeIngredients(int recipeId);

        int AddRecipe(Recipe recipe);
        void DeleteRecipe(int recipeId);
        void UpdateRecipe(Recipe recipe);

        void AddRecipeDetails(RecipeDetails details);
        void UpdateRecipeDetails(RecipeDetails details);
    }
}
