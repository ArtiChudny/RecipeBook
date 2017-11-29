using RecipeBook.Common.Models;
using RecipeBook.Data.RecipeService;

namespace RecipeBook.Data.Converters
{
    public interface IConverter
    {
        Recipe ToRecipe(RecipeDto recipeDto);
        Category ToCategory(CategoryDto categoryDto);
        RecipeDetails ToRecipeDetails(RecipeDetailsDto detailsDto);
    }
}
