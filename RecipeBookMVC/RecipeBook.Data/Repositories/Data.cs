
using System.Collections.Generic;
using RecipeBook.Common.Models;

namespace RecipeBook.Data.Repositories
{
    class Data : IDataProvider
    {
        List<Category> Categories = new List<Category>
        {
            new Category { CategoryId = 1, CategoryName = "Soups" },
            new Category { CategoryId = 2, CategoryName = "Dessert" },
            new Category { CategoryId = 3, CategoryName = "Salads" },
            new Category { CategoryId = 4, CategoryName = "MainCourses" }
        };

        List<Recipe> Recipies = new List<Recipe>
        {
            new Recipe { RecipeId = 1, RecipeName = "Borsch", PhotoUrl = "url", CategoryId = 1 },
            new Recipe { RecipeId = 2, RecipeName = "Shchi", PhotoUrl = "url", CategoryId = 1 },
            new Recipe { RecipeId = 3, RecipeName = "Pancake", PhotoUrl = "url", CategoryId = 2 },
            new Recipe { RecipeId = 4, RecipeName = "Greek Salad", PhotoUrl = "url", CategoryId = 3 },
            new Recipe { RecipeId = 5, RecipeName = "Cutlets", PhotoUrl = "url", CategoryId = 4 }
        };



        public IEnumerable<Category> GetCategories()
        {
            return Categories;
        }

        /*public IEnumerable<RecipeDetails> GetRecipeDetails()
        {
            throw new NotImplementedException();
        }*/

        public IEnumerable<Recipe> GetRecipies()
        {
            return Recipies;
        }
    }
}
