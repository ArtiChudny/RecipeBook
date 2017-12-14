﻿
namespace RecipeBook.Common.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public Role[] Roles { get; set; }
    }
}
