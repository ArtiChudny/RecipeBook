﻿using System.Collections.Generic;
using RecipeBook.Data.RecipeService;

namespace RecipeBook.Data.Clients
{
    public interface IRecipeClient
    {
        IEnumerable<RecipeDto> GetRecipes();
        RecipeDetailsDto GetDedails(int id);
    }
}
