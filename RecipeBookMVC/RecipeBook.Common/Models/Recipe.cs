
namespace RecipeBook.Common.Models
{
    public class Recipe
    {
        public int RecipeId { get; set; }
        public string RecipeName { get; set; }
        public string PhotoUrl { get; set; }
        public int CategoryId { get; set; }
    }
}
