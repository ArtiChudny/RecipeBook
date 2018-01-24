using System;
using System.Collections.Generic;
using System.Linq;
using RecipeBook.Common.Models;
using RecipeBook.Data.Repositories;

namespace RecipeBook.Business.Providers
{
    public class RecipeProvider : IRecipeProvider
    {
        private IDataRepository dataProvider;

        public RecipeProvider(IDataRepository _dataProvider)
        {
            dataProvider = _dataProvider;
        }

        public RecipeDetails GetDetails(int id)
        {
            return dataProvider.GetDedails(id);
        }

        public IEnumerable<Ingredient> GetIngredients()
        {
            return dataProvider.GetIngredients();
        }

        public IEnumerable<RecipeIngredient> GetRecipeIngredients(int id)
        {
            return dataProvider.GetRecipeIngredients(id);
        }

        public IEnumerable<Recipe> GetRecipesByCategory(string categoryName)
        {
            return dataProvider.GetRecipesByCategory(categoryName);
        }

        public IEnumerable<Recipe> GetRecipesByIngredient(string ingredientName)
        {
            return dataProvider.GetRecipesByIngredient(ingredientName);
        }

        public IEnumerable<Recipe> GetRecipesByName(string recipeName)
        {
            return dataProvider.GetRecipesByName(recipeName);
        }

        public IEnumerable<Recipe> GetRecipies()
        {
            return dataProvider.GetRecipies();
        }

        public IEnumerable<Recipe> GetRecipiesByCategory(int? id)
        {
            return dataProvider.GetRecipies().Where(x => x.CategoryId == id).ToList();
        }

        public void AddIngredient(Ingredient ingredient)
        {
            dataProvider.AddIngredient(ingredient);
        }

        public int AddRecipe(Recipe recipe)
        {
            return dataProvider.AddRecipe(recipe);
        }

        public void AddRecipeDetails(RecipeDetails details)
        {
            dataProvider.AddRecipeDetails(details);
        }

        public void AddRecipeIngredient(RecipeIngredient ingredient)
        {
            dataProvider.AddRecipeIngredient(ingredient);
        }

        public void DeleteIngredient(int ingredientId)
        {
            dataProvider.DeleteIngredient(ingredientId);
        }

        public void DeleteRecipe(int recipeId)
        {
            dataProvider.DeleteRecipe(recipeId);
        }

        public void DeleteRecipeIngredient(int recipeId, int ingredientId)
        {
            dataProvider.DeleteRecipeIngredient(recipeId, ingredientId);
        }

        public void UpdateIngredient(Ingredient ingredient)
        {
            dataProvider.UpdateIngredient(ingredient);
        }

        public void UpdateRecipe(Recipe recipe)
        {
            dataProvider.UpdateRecipe(recipe);
        }

        public void UpdateRecipeDetails(RecipeDetails details)
        {
            dataProvider.UpdateRecipeDetails(details);
        }

        public void DeleteRecipeIngredients(int recipeId)
        {
            dataProvider.DeleteRecipeIngredients(recipeId);
        }

        public bool IsServerConnected()
        {
            return dataProvider.IsServerConnected();
        }
    }
}
