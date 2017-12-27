using System.Collections.Generic;
using RecipeBook.Data.CategoryService;

namespace RecipeBook.Data.Clients
{
    public class CategoryClient : ICategoryClient
    {
        public IEnumerable<CategoryDto> GetCategories()
        {
            List<CategoryDto> categoriesDto = new List<CategoryDto>();
            using (CategoryServiceClient client = new CategoryServiceClient())
            {//trycatch
                client.Open();
                categoriesDto.AddRange(client.GetCategories());
                client.Close();
            }
            return categoriesDto;
        }

        public void AddCategory(CategoryDto category)
        {
            using (CategoryServiceClient client = new CategoryServiceClient())
            {
                client.Open();
                client.AddCategory(category);
                client.Close();
            }
        }

        public void DeleteCategory(int categoryId)
        {
            using (CategoryServiceClient client = new CategoryServiceClient())
            {
                client.Open();
                client.DeleteCategory(categoryId);
                client.Close();
            }
        }

        public void UpdateCategory(CategoryDto category)
        {
            using (CategoryServiceClient client = new CategoryServiceClient())
            {
                client.Open();
                client.UpdateCategory(category);
                client.Close();
            }
        }
    }
}
