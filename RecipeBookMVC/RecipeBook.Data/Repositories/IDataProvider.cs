using RecipeBook.Common.Models;
using System.Collections.Generic;

namespace RecipeBook.Data.Repositories
{
    public interface IDataProvider
    {
        IEnumerable<Recipe> GetRecipies();
        //IEnumerable<RecipeDetails> GetRecipeDetails();
        IEnumerable<Category> GetCategories();
    }
}
