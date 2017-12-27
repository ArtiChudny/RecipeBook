using System.Collections.Generic;
using RecipeBook.Data.CategoryService;

namespace RecipeBook.Data.Clients
{
    public interface ICategoryClient
    {
        IEnumerable<CategoryDto> GetCategories();
        void AddCategory(CategoryDto category);
        void DeleteCategory(int categoryId);
        void UpdateCategory(CategoryDto category);
    }
}
