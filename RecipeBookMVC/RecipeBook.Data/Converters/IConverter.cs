using System.Collections.Generic;
using RecipeBook.Common.Models;
using RecipeBook.Data.RecipeService;
using RecipeBook.Data.CategoryService;
using RecipeBook.Data.UserService;

namespace RecipeBook.Data.Converters
{
    public interface IConverter
    {
        Category ToCategory(CategoryDto categoryDto);
        CategoryDto ToCategoryDto(Category category);

        Recipe ToRecipe(RecipeDto recipeDto);
        RecipeDto ToRecipeDto(Recipe recipe);

        RecipeDetails ToRecipeDetails(RecipeDetailsDto detailsDto);
        RecipeDetailsDto ToRecipeDetailsDto(RecipeDetails details);

        RecipeIngredient ToRecipeIngredient(RecipeIngredientDto recipIngredienteDto);
        RecipeIngredientDto ToRecipeIngredientDto(RecipeIngredient recipeIngredient);

        Ingredient ToIngredient(IngredientDto ingredientDto);
        IngredientDto ToIngredientDto(Ingredient ingredient);

        User ToUser(UserDto userDto);
        UserDto ToUserDto(User user);
        Role ToRole(RoleDto roleDto);
        RoleDto ToRoleDto(Role role);
        IEnumerable<RoleDto> ToRolesDto(IEnumerable<Role> roles);
        IEnumerable<Role> ToRoles(IEnumerable<RoleDto> rolesDto);
    }
}
