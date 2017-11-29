using RecipeBook.Common.Models;
using RecipeBook.Data.RecipeService;

namespace RecipeBook.Data.Converters
{
    public class Converter : IConverter
    {
        public Category ToCategory(CategoryDto categoryDto)
        {
            return new Category()
            {
                CategoryId = categoryDto.CategoryId,
                CategoryName = categoryDto.CategoryName
            };
        }

        public Recipe ToRecipe(RecipeDto recipeDto)
        {
            return new Recipe()
            {
                RecipeId = recipeDto.RecipeId,
                CategoryId = recipeDto.CategoryId,
                RecipeName = recipeDto.RecipeName,
                PhotoUrl = recipeDto.PhotoUrl
            };
        }

        public RecipeDetails ToRecipeDetails(RecipeDetailsDto detailsDto)
        {
            return new RecipeDetails
            {
                RecipeId = detailsDto.RecipeId,
                CookingTemperature = detailsDto.CookingTemperature,
                CookingTime = detailsDto.CookingTime,
                Description = detailsDto.Description,
                Steps = detailsDto.Steps
            };
        }
    }
}
