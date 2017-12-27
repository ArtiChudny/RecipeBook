namespace RecipeBook.Common.Models
{
    public class RecipeIngredient
    {
        public int RecipeId { get; set; }
        public int IngredientId { get; set; }
        public string IngredientName { get; set; }
        public string Weight { get; set; }
    }
}
