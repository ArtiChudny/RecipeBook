
using System;
using System.Collections.Generic;
using RecipeBook.Common.Models;
using System.Linq;


namespace RecipeBook.Data.Repositories
{
    public class DataProvider : IDataProvider
    {
        List<Category> Categories = new List<Category>()
        {
            new Category { CategoryId = 1, CategoryName = "Soups" },
            new Category { CategoryId = 2, CategoryName = "Dessert" },
            new Category { CategoryId = 3, CategoryName = "Salads" },
            new Category { CategoryId = 4, CategoryName = "MainCourses" }
        };

        List<Recipe> Recipies = new List<Recipe>()
        {
            new Recipe { RecipeId = 1, RecipeName = "Borsch", PhotoUrl = null, CategoryId = 1 },
            new Recipe { RecipeId = 2, RecipeName = "Shchi", PhotoUrl = null, CategoryId = 1 },
            new Recipe { RecipeId = 3, RecipeName = "Pancake", PhotoUrl = null, CategoryId = 2 },
            new Recipe { RecipeId = 4, RecipeName = "Greek Salad", PhotoUrl = null, CategoryId = 3 },
            new Recipe { RecipeId = 5, RecipeName = "Cutlets", PhotoUrl = null, CategoryId = 4 }
        };


        List<RecipeDetails> Details = new List<RecipeDetails>()
        {
            new RecipeDetails {RecipeId = 1, CookingTemperature= "100", CookingTime = "60 min", Description = "Borsch", Steps = "Steps"},
            new RecipeDetails {RecipeId = 2, CookingTemperature= "100", CookingTime = "60 min", Description = "Shchi", Steps = "Steps"},
            new RecipeDetails {RecipeId = 3, CookingTemperature= "120", CookingTime = "20 min", Description = "Pancake", Steps = "Steps"},
            new RecipeDetails {RecipeId = 4, CookingTemperature= "-", CookingTime = "20 min", Description = "Greek Salad", Steps = "Steps"},
            new RecipeDetails {RecipeId = 5, CookingTemperature= "120", CookingTime = "20 min", Description = "Cutlets", Steps = "Steps"}
        };

        public IEnumerable<Category> GetCategories()
        {
            return Categories;
        }

        public RecipeDetails GetDedails(int id)
        {
            return Details.Single(m => m.RecipeId == id);
        }

        public IEnumerable<Recipe> GetRecipies()
        {

            return Recipies;
        }

    }
}
