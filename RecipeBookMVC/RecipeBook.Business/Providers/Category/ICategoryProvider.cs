
using System.Collections.Generic;
using RecipeBook.Common.Models;

namespace RecipeBook.Business.Providers
{
    public interface ICategoryProvider
    {
        IEnumerable<Category> GetCategories();
    }
}
