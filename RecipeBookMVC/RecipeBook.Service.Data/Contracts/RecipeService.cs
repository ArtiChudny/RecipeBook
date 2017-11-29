using System.Collections.Generic;
using System.Linq;
using RecipeBook.Service.Data.ModelsDto;

namespace RecipeBook.Service.Data.Contracts
{
    public class RecipeService : IRecipeService
    {
        List<CategoryDto> Categories = new List<CategoryDto>()
        {
            new CategoryDto { CategoryId = 1, CategoryName = "Soups" },
            new CategoryDto { CategoryId = 2, CategoryName = "Dessert" },
            new CategoryDto { CategoryId = 3, CategoryName = "Salads" },
            new CategoryDto { CategoryId = 4, CategoryName = "MainCourses" }
        };

        List<RecipeDto> Recipies = new List<RecipeDto>()
        {
            new RecipeDto { RecipeId = 1, RecipeName = "Borsch", PhotoUrl = null, CategoryId = 1 },
            new RecipeDto { RecipeId = 2, RecipeName = "Shchi", PhotoUrl = null, CategoryId = 1 },
            new RecipeDto { RecipeId = 3, RecipeName = "Pancake", PhotoUrl = null, CategoryId = 2 },
            new RecipeDto { RecipeId = 4, RecipeName = "Greek Salad", PhotoUrl = null, CategoryId = 3 },
            new RecipeDto { RecipeId = 5, RecipeName = "Cutlets", PhotoUrl = null, CategoryId = 4 }
        };


        List<RecipeDetailsDto> Details = new List<RecipeDetailsDto>()
        {
            new RecipeDetailsDto {RecipeId = 1, CookingTemperature= "100", CookingTime = "60 min", Description = "Borsch", Steps = "Steps"},
            new RecipeDetailsDto {RecipeId = 2, CookingTemperature= "100", CookingTime = "60 min", Description = "Shchi", Steps = "Steps"},
            new RecipeDetailsDto {RecipeId = 3, CookingTemperature= "120", CookingTime = "20 min", Description = "Pancake", Steps = "Steps"},
            new RecipeDetailsDto {RecipeId = 4, CookingTemperature= "-", CookingTime = "20 min", Description = "Greek Salad", Steps = "Steps"},
            new RecipeDetailsDto {RecipeId = 5, CookingTemperature= "120", CookingTime = "20 min", Description = "Cutlets", Steps = "Steps"}
        };

        public IEnumerable<CategoryDto> GetCategories()
        {
            return Categories;
        }

        public RecipeDetailsDto GetDedails(int id)
        {
            return Details.Single(x => x.RecipeId == id);
        }

        public IEnumerable<RecipeDto> GetRecipes()
        {
            return Recipies;
        }
    }
}
