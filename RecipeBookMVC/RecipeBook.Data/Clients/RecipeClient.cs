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

        public IEnumerable<IngredientDto> GetIngredients()
        {
            List<IngredientDto> ingredientsDto = new List<IngredientDto>();
            using (RecipeServiceClient client = new RecipeServiceClient())
            {
                client.Open();
                ingredientsDto.AddRange(client.GetIngredients());
                client.Close();
            }
            return ingredientsDto;
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

        public IEnumerable<RecipeDto> GetRecipesByCategory(string categoryName)
        {
            List<RecipeDto> recipesDto = new List<RecipeDto>();
            using (RecipeServiceClient client = new RecipeServiceClient())
            {
                client.Open();
                recipesDto.AddRange(client.GetRecipesByCategory(categoryName));
                client.Close();
            }
            return recipesDto;
        }

        public IEnumerable<RecipeDto> GetRecipesByIngredient(string ingredientName)
        {
            List<RecipeDto> recipesDto = new List<RecipeDto>();
            using (RecipeServiceClient client = new RecipeServiceClient())
            {
                client.Open();
                recipesDto.AddRange(client.GetRecipesByIngredient(ingredientName));
                client.Close();
            }
            return recipesDto;
        }

        public IEnumerable<RecipeDto> GetRecipesByName(string recipeName)
        {
            List<RecipeDto> recipesDto = new List<RecipeDto>();
            using (RecipeServiceClient client = new RecipeServiceClient())
            {
                client.Open();
                recipesDto.AddRange(client.GetRecipesByName(recipeName));
                client.Close();
            }
            return recipesDto;
        }

        public void AddIngredient(IngredientDto ingredient)
        {
            using (RecipeServiceClient client = new RecipeServiceClient())
            {
                client.Open();
                client.AddIngredient(ingredient);
                client.Close();
            }
        }

        public void AddRecipe(RecipeDto recipe)
        {
            using (RecipeServiceClient client = new RecipeServiceClient())
            {
                client.Open();
                client.AddRecipe(recipe);
                client.Close();
            }
        }

        public void AddRecipeDetails(RecipeDetailsDto details)
        {
            using (RecipeServiceClient client = new RecipeServiceClient())
            {
                client.Open();
                client.AddRecipeDetails(details);
                client.Close();
            }
        }

        public void AddRecipeIngredient(int recipeId, int ingredientId)
        {
            using (RecipeServiceClient client = new RecipeServiceClient())
            {
                client.Open();
                client.AddRecipeIngredient(recipeId, ingredientId);
                client.Close();
            }
        }

        public void DeleteIngredient(int ingredientId)
        {
            using (RecipeServiceClient client = new RecipeServiceClient())
            {
                client.Open();
                client.DeleteIngredient(ingredientId);
                client.Close();
            }
        }

        public void DeleteRecipe(int recipeId)
        {
            using (RecipeServiceClient client = new RecipeServiceClient())
            {
                client.Open();
                client.DeleteIngredient(recipeId);
                client.Close();
            }
        }

        public void DeleteRecipeIngredient(int recipeId, int ingredientId)
        {
            using (RecipeServiceClient client = new RecipeServiceClient())
            {
                client.Open();
                client.DeleteRecipeIngredient(recipeId, ingredientId);
                client.Close();
            }
        }

        public void UpdateIngredient(IngredientDto ingredient)
        {
            using (RecipeServiceClient client = new RecipeServiceClient())
            {
                client.Open();
                client.UpdateIngredient(ingredient);
                client.Close();
            }
        }

        public void UpdateRecipe(RecipeDto recipe)
        {
            using (RecipeServiceClient client = new RecipeServiceClient())
            {
                client.Open();
                client.UpdateRecipe(recipe);
                client.Close();
            }
        }

        public void UpdateRecipeDetails(RecipeDetailsDto details)
        {
            using (RecipeServiceClient client = new RecipeServiceClient())
            {
                client.Open();
                client.UpdateRecipeDetails(details);
                client.Close();
            }
        }
    }
}
