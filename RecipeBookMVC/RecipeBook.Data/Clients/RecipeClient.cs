using System.Collections.Generic;
using RecipeBook.Data.RecipeService;

namespace RecipeBook.Data.Clients
{
    public class RecipeClient : IRecipeClient
    {
        public IEnumerable<CategoryDto> GetCategories()
        {
            List<CategoryDto> categoriesDto = new List<CategoryDto>();
            using (RecipeServiceClient client = new RecipeServiceClient())
            {
                client.Open();
                categoriesDto.AddRange(client.GetCategories());
                client.Close();
            }
            return categoriesDto;
        }

        public RecipeDetailsDto GetDedails(int id)
        {
            RecipeDetailsDto detailsDto = new RecipeDetailsDto();
            using (RecipeServiceClient client = new RecipeServiceClient())
            {
                client.Open();
                detailsDto = client.GetDedails(id);
                client.Close();
            }
            return detailsDto;
        }

        public IEnumerable<RecipeDto> GetRecipes()
        {
            List<RecipeDto> recipiesDto = new List<RecipeDto>();
            using (RecipeServiceClient client = new RecipeServiceClient())
            {
                client.Open();
                recipiesDto.AddRange(client.GetRecipes());
                client.Close();
            }
            return recipiesDto;
        }
    }
}
