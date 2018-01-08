using RecipeBook.Common.Models;
using System.Collections.Generic;

namespace RecipeBook.Data.Repositories
{
    public interface IDataRepository
    {
        IEnumerable<Category> GetCategories();
        void AddCategory(Category category);
        void DeleteCategory(int categoryId);
        void UpdateCategory(Category category);

        IEnumerable<Recipe> GetRecipies();
        IEnumerable<Ingredient> GetIngredients();
        IEnumerable<RecipeIngredient> GetRecipeIngredients(int id);
        IEnumerable<Recipe> GetRecipesByIngredient(string ingredientName);
        IEnumerable<Recipe> GetRecipesByName(string recipeName);
        IEnumerable<Recipe> GetRecipesByCategory(string categoryName);
        RecipeDetails GetDedails(int id);

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
