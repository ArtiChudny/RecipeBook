using System.Collections.Generic;
using RecipeBook.Data.RecipeService;

namespace RecipeBook.Data.Clients
{
    public interface IRecipeClient
    {
        IEnumerable<RecipeDto> GetRecipes();
        IEnumerable<CategoryDto> GetCategories();
        RecipeDetailsDto GetDedails(int id);
    }
}
