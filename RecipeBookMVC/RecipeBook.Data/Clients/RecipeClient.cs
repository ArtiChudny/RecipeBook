using System.Collections.Generic;
using RecipeBook.Data.RecipeService;

namespace RecipeBook.Data.Clients
{
    public class RecipeClient : IRecipeClient
    {
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

        public IEnumerable<RecipeIngredientDto> GetRecipeIngredients(int id)
        {
            List<RecipeIngredientDto> ingredientsDto = new List<RecipeIngredientDto>();
            using (RecipeServiceClient client = new RecipeServiceClient())
            {
                client.Open();
                ingredientsDto.AddRange(client.GetRecipeIngredients(id));
                client.Close();
            }
            return ingredientsDto;
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

        public IEnumerable<RecipeDto> GetRecipesByIngredient(string recipeName)
        {
            List<RecipeDto> recipesDto = new List<RecipeDto>();
            using (RecipeServiceClient client = new RecipeServiceClient())
            {
                client.Open();
                recipesDto.AddRange(client.GetRecipesByIngredient(recipeName));
                client.Close();
            }
            return recipesDto;
        }
    }
}
