using RecipeBook.Common.Models;
using System.Linq;
using RecipeBook.Data.RecipeService;
using RecipeBook.Data.CategoryService;
using RecipeBook.Data.UserService;
using System.Collections.Generic;

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

        public CategoryDto ToCategoryDto(Category category)
        {
            return new CategoryDto()
            {
                CategoryId = category.CategoryId,
                CategoryName = category.CategoryName
            };
        }

        public Ingredient ToIngredient(IngredientDto ingredientDto)
        {
            return new Ingredient
            {
                IngredientId = ingredientDto.IngredientId,
                IngredientName = ingredientDto.IngredientName
            };
        }

        public IngredientDto ToIngredientDto(Ingredient ingredient)
        {
            return new IngredientDto()
            {
                IngredientId = ingredient.IngredientId,
                IngredientName = ingredient.IngredientName
            };
        }

        public Recipe ToRecipe(RecipeDto recipeDto)
        {
            return new Recipe()
            {
                RecipeId = recipeDto.RecipeId,
                CategoryId = recipeDto.CategoryId,
                RecipeName = recipeDto.RecipeName,
                PhotoUrl = recipeDto.PhotoUrl,
                Details = ToRecipeDetails(recipeDto.Details)
            };
        }

        public RecipeDetails ToRecipeDetails(RecipeDetailsDto detailsDto)
        {
            if (detailsDto != null)
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
            else
            {
                return null;
            }
        }

        public RecipeDetailsDto ToRecipeDetailsDto(RecipeDetails details)
        {
            if (details != null)
            {
                return new RecipeDetailsDto()
                {
                    RecipeId = details.RecipeId,
                    CookingTemperature = details.CookingTemperature,
                    CookingTime = details.CookingTime,
                    Description = details.Description,
                    Steps = details.Steps
                };
            }
            else
            {
                return null;
            }

        }

        public RecipeDto ToRecipeDto(Recipe recipe)
        {
            return new RecipeDto()
            {
                RecipeId = recipe.RecipeId,
                RecipeName = recipe.RecipeName,
                PhotoUrl = recipe.PhotoUrl,
                CategoryId = recipe.CategoryId,
                Details = ToRecipeDetailsDto(recipe.Details)
            };
        }

        public RecipeIngredient ToRecipeIngredient(RecipeIngredientDto recipeDto)
        {
            return new RecipeIngredient
            {
                RecipeId = recipeDto.RecipeId,
                IngredientName = recipeDto.IngredientName,
                Weight = recipeDto.Weight,
                IngredientId = recipeDto.IngredientId
            };
        }

        public RecipeIngredientDto ToRecipeIngredientDto(RecipeIngredient recipeIngredient)
        {
            return new RecipeIngredientDto()
            {
                RecipeId = recipeIngredient.RecipeId,
                IngredientName = recipeIngredient.IngredientName,
                Weight = recipeIngredient.IngredientName,
                IngredientId = recipeIngredient.IngredientId
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

        public RoleDto ToRoleDto(Role role)
        {
            return new RoleDto
            {
                RoleId = role.RoleId,
                RoleName = role.RoleName
            };
        }

        public IEnumerable<Role> ToRoles(IEnumerable<RoleDto> rolesDto)
        {
            List<Role> roles = new List<Role>();
            foreach (var item in rolesDto)
            {
                roles.Add(ToRole(item));
            }
            return roles;
        }

        public IEnumerable<RoleDto> ToRolesDto(IEnumerable<Role> roles)
        {
            List<RoleDto> rolesDto = new List<RoleDto>();
            if (roles != null)
            {
                foreach (var item in roles)
                {
                    rolesDto.Add(ToRoleDto(item));
                }
            }
            return rolesDto;
        }

        public User ToUser(UserDto userDto)
        {
            return new User
            {
                UserId = userDto.UserId,
                Login = userDto.Login,
                Password = userDto.Password,
                Email = userDto.Email,
                Roles = ToRoles(userDto.UserRoles).ToArray()
            };
        }

        public UserDto ToUserDto(User user)
        {
            return new UserDto
            {
                UserId = user.UserId,
                Login = user.Login,
                Password = user.Password,
                Email = user.Email,
                UserRoles = ToRolesDto(user.Roles).ToArray()
            };
        }
    }
}
