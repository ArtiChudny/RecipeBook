using System.Collections.Generic;
using RecipeBook.Common.Models;
using RecipeBook.Data.Repositories;

namespace RecipeBook.Business.Providers
{
    public class CategoryProvider : ICategoryProvider
    {
        private IDataRepository dataProvider;

        public CategoryProvider(IDataRepository _dataProvider)
        {
            dataProvider = _dataProvider;
        }

        public IEnumerable<Category> GetCategories()
        {
            return dataProvider.GetCategories();
        }

    }
}
