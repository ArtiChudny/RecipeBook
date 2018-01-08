using System.ComponentModel.DataAnnotations;
using RecipeBook.Common.Models;

namespace RecipeBook.Web.Models
{
    public class RegistrationViewModel
    {
        [Required(AllowEmptyStrings = true, ErrorMessage = "Field login is required!")]
        public string Login { get; set; }

        [Required(AllowEmptyStrings = true, ErrorMessage = "Field password is required!")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Passwords do not match")]
        public string RePassword { get; set; }

        [Required(AllowEmptyStrings = true, ErrorMessage = "Field email is required!")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Chose at least one role!")]
        public int[] Roles { get; set; }
        //public IEnumerable<Role> Roles { get; set; }
    }
}