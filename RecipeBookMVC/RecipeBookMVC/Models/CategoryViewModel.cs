using System.Collections.Generic;
using RecipeBook.Common.Models;

namespace RecipeBookMVC.Models
{
    public class CategoryViewModel
    {
        public IEnumerable<Category> Categories { get; set; }
    }
}