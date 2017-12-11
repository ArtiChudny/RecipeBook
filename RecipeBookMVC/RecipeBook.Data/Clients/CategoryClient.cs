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
    }
}
