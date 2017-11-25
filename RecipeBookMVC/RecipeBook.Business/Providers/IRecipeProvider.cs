
using System.Collections.Generic;
using RecipeBook.Common.Models;

namespace RecipeBook.Business.Providers
{
    public interface IRecipeProvider
    {
        IEnumerable<Recipe> GetRecipies { get; }
        //IEnumerable<RecipeDetails> GetRecipeDetails();
        IEnumerable<Category> GetCategories { get; }

    }
}
