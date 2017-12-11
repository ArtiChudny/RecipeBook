﻿using System.Collections.Generic;
using System.Linq;
using RecipeBook.Common.Models;
using RecipeBook.Data.Repositories;


namespace RecipeBook.Business.Providers
{
    public class RecipeProvider : IRecipeProvider
    {
        private IDataProvider dataProvider;

        public RecipeProvider(IDataProvider _dataProvider)
        {
            dataProvider = _dataProvider;
        }

        public RecipeDetails GetDetails(int id)
        {
            return dataProvider.GetDedails(id);
        }

        public IEnumerable<RecipeIngredient> GetRecipeIngredients(int id)
        {
            return dataProvider.GetRecipeIngredients(id);
        }

        public IEnumerable<Recipe> GetRecipies()
        {
            return dataProvider.GetRecipies();
        }

        public IEnumerable<Recipe> GetRecipiesByCategory(int? id)
        {
            return dataProvider.GetRecipies().Where(x => x.CategoryId == id).ToList();
        }

    }
}
