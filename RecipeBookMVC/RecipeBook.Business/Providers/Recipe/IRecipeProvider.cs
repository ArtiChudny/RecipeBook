﻿
using System.Collections.Generic;
using RecipeBook.Common.Models;


namespace RecipeBook.Business.Providers
{
    public interface IRecipeProvider
    {
        IEnumerable<Recipe> GetRecipies();
        IEnumerable<Recipe> GetRecipiesByCategory(int? id);
        RecipeDetails GetDetails(int id);
    }
}