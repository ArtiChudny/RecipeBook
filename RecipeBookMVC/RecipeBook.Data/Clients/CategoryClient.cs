using System;
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
            {
                try
                {
                    client.Open();
                    categoriesDto.AddRange(client.GetCategories());
                    client.Close();
                }
                catch (Exception ex)
                {
                    throw new Exception("Service error", ex);
                }
            }
            return categoriesDto;
        }

        public void AddCategory(CategoryDto category)
        {
            using (CategoryServiceClient client = new CategoryServiceClient())
            {
                try
                {
                    client.Open();
                    client.AddCategory(category);
                    client.Close();
                }
                catch (Exception ex)
                {
                    throw new Exception("Service error", ex);
                }
            }
        }

        public void DeleteCategory(int categoryId)
        {
            using (CategoryServiceClient client = new CategoryServiceClient())
            {
                try
                {
                    client.Open();
                    client.DeleteCategory(categoryId);
                    client.Close();

                }
                catch (Exception ex)
                {
                    throw new Exception("Service error", ex);
                }
            }
        }

        public void UpdateCategory(CategoryDto category)
        {
            using (CategoryServiceClient client = new CategoryServiceClient())
            {
                try
                {
                    client.Open();
                    client.UpdateCategory(category);
                    client.Close();
                }
                catch (Exception ex)
                {
                    throw new Exception("Service error", ex);
                }
            }
        }
    }
}
