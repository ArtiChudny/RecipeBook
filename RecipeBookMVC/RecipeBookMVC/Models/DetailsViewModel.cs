using RecipeBook.Common.Models;
using System.Collections.Generic;

namespace RecipeBook.Web.Models
{
    public class DetailsViewModel
    {
        public RecipeDetails recipeDetails { get; set; }
        public IEnumerable<RecipeIngredient> recipeIngredients { get; set; }
        public string ImageUrl { get; set; }
        public string RecipeName { get; set; }
    }

}