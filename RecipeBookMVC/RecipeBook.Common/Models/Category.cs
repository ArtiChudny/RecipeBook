using System.Collections.Generic;

namespace RecipeBook.Common.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public List<Recipe> Recepies { get; set; }
    }
}
