using RecipeBook.Common.Models;
using System.Collections.Generic;

namespace RecipeBook.Data.Repositories
{
    public interface IDataRepository
    {
        IEnumerable<Recipe> GetRecipies();
        IEnumerable<Category> GetCategories();
        IEnumerable<RecipeIngredient> GetRecipeIngredients(int id);
        IEnumerable<Recipe> GetRecipesByIngredient(string recipeName);
        RecipeDetails GetDedails(int id);

    }
}
