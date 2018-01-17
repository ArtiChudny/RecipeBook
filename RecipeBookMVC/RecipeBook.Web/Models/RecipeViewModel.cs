using System.ComponentModel.DataAnnotations;
using RecipeBook.Common.Models;

namespace RecipeBook.Web.Models
{
    public class RecipeViewModel
    {
        public int RecipeId { get; set; }
        [Required(AllowEmptyStrings = true, ErrorMessage = "Field Name is required!")]
        public string RecipeName { get; set; }
        public string PhotoUrl { get; set; }
        [Required(AllowEmptyStrings = true, ErrorMessage = "Field Category is required!")]
        public int CategoryId { get; set; }

        [Required(AllowEmptyStrings = true, ErrorMessage = "Field CookingTime is required!")]
        public string CookingTime { get; set; }
        public string CookingTemperature { get; set; }
        [Required(AllowEmptyStrings = true, ErrorMessage = "Field Desription is required!")]
        public string Description { get; set; }
        [Required(AllowEmptyStrings = true, ErrorMessage = "Field Steps is required!")]
        public string Steps { get; set; }

        [Required(AllowEmptyStrings = true, ErrorMessage = "Select at least one ingredient!")]
        public RecipeIngredient[] Ingredients { get; set; }
    }
}