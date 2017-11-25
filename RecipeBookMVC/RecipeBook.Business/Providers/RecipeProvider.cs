
using System.Collections.Generic;
using RecipeBook.Common.Models;
using RecipeBook.Data.Repositories;

namespace RecipeBook.Business.Providers
{
    class RecipeProvider : IRecipeProvider
    {
        private IDataProvider dataProvider;

        public RecipeProvider(IDataProvider _dataProvider)
        {
            dataProvider = _dataProvider;
        }


        public IEnumerable<Category> GetCategories
        {
            get
            {
                return dataProvider.GetCategories();
            }
        }

        public IEnumerable<Recipe> GetRecipies
        {
            get
            {
                return dataProvider.GetRecipies();
            }
        }
    }
}
