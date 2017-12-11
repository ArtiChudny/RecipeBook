using RecipeBook.Common.Models;
using System.Collections.Generic;

namespace RecipeBook.Data.Repositories
{
    public interface IDataProvider
    {
        IEnumerable<Recipe> GetRecipies();
        IEnumerable<Category> GetCategories();
        IEnumerable<RecipeIngredient> GetRecipeIngredients(int id);
        RecipeDetails GetDedails(int id);

    }
}
