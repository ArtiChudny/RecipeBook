﻿using RecipeBook.Common.Models;
using RecipeBook.Data.RecipeService;
using RecipeBook.Data.CategoryService;
using RecipeBook.Data.UserService;

namespace RecipeBook.Data.Converters
{
    public interface IConverter
    {
        Recipe ToRecipe(RecipeDto recipeDto);
        Category ToCategory(CategoryDto categoryDto);
        RecipeDetails ToRecipeDetails(RecipeDetailsDto detailsDto);
        RecipeIngredient ToRecipeIngredient(RecipeIngredientDto recipeDto);
        User ToUser(UserDto userDto);
        Role ToRole(RoleDto roleDto);
    }
}
