using System.ComponentModel.DataAnnotations;

namespace RecipeBook.Web.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Field is required")]
        public string Login { get; set; }
        [Required(ErrorMessage = "Field is required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public string Message { get; set; }
    }
}