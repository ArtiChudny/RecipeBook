using System.ComponentModel.DataAnnotations;

namespace RecipeBook.Web.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Enter the login")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Enter the password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}