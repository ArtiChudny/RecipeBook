using System;
using System.Collections.Generic;
using RecipeBook.Data.Converters;
using RecipeBook.Common.Models;
using RecipeBook.Data.Clients;
using RecipeBook.Data.RecipeService;
using RecipeBook.Data.CategoryService;


namespace RecipeBook.Data.Repositories
{
    public class DataRepository : IDataRepository
    {
        IRecipeClient recipeClient;
        ICategoryClient categoryClient;
        IConverter converter;

        public DataRepository(IRecipeClient _recipeClient, ICategoryClient _categoryClient, IConverter _converter)
        {
            converter = _converter;
            recipeClient = _recipeClient;
            categoryClient = _categoryClient;
        }

        public IEnumerable<Category> GetCategories()
        {
            IEnumerable<CategoryDto> categoriesDto = categoryClient.GetCategories();
            List<Category> categoryList = new List<Category>();
            IEnumerable<Category> categories;
            if (categoriesDto != null)
            {
                foreach (var item in categoriesDto)
                {
                    categoryList.Add(converter.ToCategory(item));
                }
            }
            categories = categoryList;
            return categories;
        }

        public RecipeDetails GetDedails(int id)
        {
            RecipeDetailsDto detailsDto = recipeClient.GetDedails(id);
            RecipeDetails details = new RecipeDetails();
            if (detailsDto != null)
            {
                details = converter.ToRecipeDetails(detailsDto);
            }
            return details;
        }

        public IEnumerable<Recipe> GetRecipies()
        {
            IEnumerable<RecipeDto> recipesDto = recipeClient.GetRecipes();
            List<Recipe> recipeList = new List<Recipe>();
            IEnumerable<Recipe> recipies;
            if (recipesDto != null)
            {
                foreach (var item in recipesDto)
                {
                    recipeList.Add(converter.ToRecipe(item));
                }
            }
            recipies = recipeList;
            return recipies;
        }

        public IEnumerable<RecipeIngredient> GetRecipeIngredients(int id)
        {
            IEnumerable<RecipeIngredientDto> recipeIngredientsDto = recipeClient.GetRecipeIngredients(id);
            List<RecipeIngredient> recipeIngredientsList = new List<RecipeIngredient>();
            IEnumerable<RecipeIngredient> recipeIngredients;
            if (recipeIngredientsDto != null)
            {
                foreach (var item in recipeIngredientsDto)
                {
                    recipeIngredientsList.Add(converter.ToRecipeIngredient(item));
                }
            }
            recipeIngredients = recipeIngredientsList;
            return recipeIngredients;
        }

        public IEnumerable<Recipe> GetRecipesByIngredient(string ingredientName)
        {
            IEnumerable<RecipeDto> recipesDto = recipeClient.GetRecipesByIngredient(ingredientName);
            List<Recipe> recipesList = new List<Recipe>();
            if (recipesDto != null)
            {
                foreach (var item in recipesDto)
                {
                    recipesList.Add(converter.ToRecipe(item));
                }
            }
            return recipesList;
        }

        public IEnumerable<Recipe> GetRecipesByName(string recipeName)
        {
            IEnumerable<RecipeDto> recipesDto = recipeClient.GetRecipesByName(recipeName);
            List<Recipe> recipesList = new List<Recipe>();
            if (recipesDto != null)
            {
                foreach (var item in recipesDto)
                {
                    recipesList.Add(converter.ToRecipe(item));
                }
            }
            return recipesList;
        }

        public IEnumerable<Recipe> GetRecipesByCategory(string categoryName)
        {
            IEnumerable<RecipeDto> recipesDto = recipeClient.GetRecipesByCategory(categoryName);
            List<Recipe> recipesList = new List<Recipe>();
            if (recipesDto != null)
            {
                foreach (var item in recipesDto)
                {
                    recipesList.Add(converter.ToRecipe(item));
                }
            }
            return recipesList;
        }

        public IEnumerable<Ingredient> GetIngredients()
        {
            IEnumerable<IngredientDto> ingredientsDto = recipeClient.GetIngredients();
            List<Ingredient> ingredientsList = new List<Ingredient>();
            if (ingredientsDto != null)
            {
                foreach (var item in ingredientsDto)
                {
                    ingredientsList.Add(converter.ToIngredient(item));
                }
            }
            return ingredientsList;
        }

        public void AddCategory(Category category)
        {
            categoryClient.AddCategory(converter.ToCategoryDto(category));
        }

        public void DeleteCategory(int categoryId)
        {
            categoryClient.DeleteCategory(categoryId);
        }

        public void UpdateCategory(Category category)
        {
            categoryClient.UpdateCategory(converter.ToCategoryDto(category));
        }

        public void AddIngredient(Ingredient ingredient)
        {
            recipeClient.AddIngredient(converter.ToIngredientDto(ingredient));
        }

        public void DeleteIngredient(int ingredientId)
        {
            recipeClient.DeleteIngredient(ingredientId);
        }

        public void UpdateIngredient(Ingredient ingredient)
        {
            recipeClient.UpdateIngredient(converter.ToIngredientDto(ingredient));
        }

        public void AddRecipeIngredient(RecipeIngredient ingredient)
        {
            recipeClient.AddRecipeIngredient(converter.ToRecipeIngredientDto(ingredient));
        }

        public void DeleteRecipeIngredient(int recipeId, int ingredientId)
        {
            recipeClient.DeleteRecipeIngredient(recipeId, ingredientId);
        }

        public int AddRecipe(Recipe recipe)
        {
            return recipeClient.AddRecipe(converter.ToRecipeDto(recipe));
        }

        public void DeleteRecipe(int recipeId)
        {
            recipeClient.DeleteRecipe(recipeId);
        }

        public void UpdateRecipe(Recipe recipe)
        {
            recipeClient.UpdateRecipe(converter.ToRecipeDto(recipe));
        }

        public void AddRecipeDetails(RecipeDetails details)
        {
            recipeClient.AddRecipeDetails(converter.ToRecipeDetailsDto(details));
        }

        public void UpdateRecipeDetails(RecipeDetails details)
        {
            recipeClient.UpdateRecipeDetails(converter.ToRecipeDetailsDto(details));
        }

        public void DeleteRecipeIngredients(int recipeId)
        {
            recipeClient.DeleteRecipeIngredients(recipeId);
        }

        public bool IsServerConnected()
        {
            return recipeClient.IsServerConnected();
        }
    }
}
