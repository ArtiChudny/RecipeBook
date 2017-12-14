using RecipeBook.Common.Models;
using RecipeBook.Data.RecipeService;
using RecipeBook.Data.CategoryService;
using RecipeBook.Data.UserService;

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

        public RecipeIngredient ToRecipeIngredient(RecipeIngredientDto recipeDto)
        {
            return new RecipeIngredient
            {
                RecipeId = recipeDto.RecipeId,
                IngredientName = recipeDto.IngredientName,
                Weight = recipeDto.Weight
            };
        }

        public Role ToRole(RoleDto roleDto)
        {
            return new Role
            {
                RoleId = roleDto.RoleId,
                RoleName = roleDto.RoleName
            };
        }

        public User ToUser(UserDto userDto)
        {
            return new User
            {
                UserId = userDto.UserId,
                Login = userDto.Login,
                Password = userDto.Password,
                Email = userDto.Email
            };
        }
    }
}
