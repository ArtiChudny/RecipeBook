using System;
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
                try
                {
                    client.Open();
                    detailsDto = client.GetDedails(id);
                    client.Close();
                }
                catch (Exception ex)
                {
                    throw new Exception("Service error", ex);
                }
            }
            return detailsDto;
        }

        public IEnumerable<IngredientDto> GetIngredients()
        {
            List<IngredientDto> ingredientsDto = new List<IngredientDto>();
            using (RecipeServiceClient client = new RecipeServiceClient())
            {
                try
                {
                    client.Open();
                    ingredientsDto.AddRange(client.GetIngredients());
                    client.Close();
                }
                catch (Exception ex)
                {
                    throw new Exception("Service error", ex);
                }
            }
            return ingredientsDto;
        }

        public IEnumerable<RecipeIngredientDto> GetRecipeIngredients(int id)
        {
            List<RecipeIngredientDto> ingredientsDto = new List<RecipeIngredientDto>();
            using (RecipeServiceClient client = new RecipeServiceClient())
            {
                try
                {
                    client.Open();
                    ingredientsDto.AddRange(client.GetRecipeIngredients(id));
                    client.Close();
                }
                catch (Exception ex)
                {
                    throw new Exception("Service error", ex);
                }
            }
            return ingredientsDto;
        }

        public IEnumerable<RecipeDto> GetRecipes()
        {
            List<RecipeDto> recipiesDto = new List<RecipeDto>();
            using (RecipeServiceClient client = new RecipeServiceClient())
            {
                try
                {
                    client.Open();
                    recipiesDto.AddRange(client.GetRecipes());
                    client.Close();
                }
                catch (Exception ex)
                {
                    throw new Exception("Service error", ex);
                }
            }
            return recipiesDto;
        }

        public IEnumerable<RecipeDto> GetRecipesByCategory(string categoryName)
        {
            List<RecipeDto> recipesDto = new List<RecipeDto>();
            using (RecipeServiceClient client = new RecipeServiceClient())
            {
                try
                {
                    client.Open();
                    recipesDto.AddRange(client.GetRecipesByCategory(categoryName));
                    client.Close();
                }
                catch (Exception ex)
                {
                    throw new Exception("Service error", ex);
                }
            }
            return recipesDto;
        }

        public IEnumerable<RecipeDto> GetRecipesByIngredient(string ingredientName)
        {
            List<RecipeDto> recipesDto = new List<RecipeDto>();
            using (RecipeServiceClient client = new RecipeServiceClient())
            {
                try
                {
                    client.Open();
                    recipesDto.AddRange(client.GetRecipesByIngredient(ingredientName));
                    client.Close();
                }
                catch (Exception ex)
                {
                    throw new Exception("Service error", ex);
                }
            }
            return recipesDto;
        }

        public IEnumerable<RecipeDto> GetRecipesByName(string recipeName)
        {
            List<RecipeDto> recipesDto = new List<RecipeDto>();
            using (RecipeServiceClient client = new RecipeServiceClient())
            {
                try
                {
                    client.Open();
                    recipesDto.AddRange(client.GetRecipesByName(recipeName));
                    client.Close();
                }
                catch (Exception ex)
                {
                    throw new Exception("Service error", ex);
                }
            }
            return recipesDto;
        }

        public void AddIngredient(IngredientDto ingredient)
        {
            using (RecipeServiceClient client = new RecipeServiceClient())
            {
                try
                {
                    client.Open();
                    client.AddIngredient(ingredient);
                    client.Close();
                }
                catch (Exception ex)
                {
                    throw new Exception("Service error", ex);
                }
            }
        }

        public int AddRecipe(RecipeDto recipe)
        {
            int RecipeId;
            using (RecipeServiceClient client = new RecipeServiceClient())
            {
                try
                {
                    client.Open();
                    RecipeId = client.AddRecipe(recipe);
                    client.Close();
                }
                catch (Exception ex)
                {
                    throw new Exception("Service error", ex);
                }
            }
            return RecipeId;
        }

        public void AddRecipeDetails(RecipeDetailsDto details)
        {
            using (RecipeServiceClient client = new RecipeServiceClient())
            {
                try
                {
                    client.Open();
                    client.AddRecipeDetails(details);
                    client.Close();
                }
                catch (Exception ex)
                {
                    throw new Exception("Service error", ex);
                }
            }
        }

        public void AddRecipeIngredient(RecipeIngredientDto ingredient)
        {
            using (RecipeServiceClient client = new RecipeServiceClient())
            {
                try
                {
                    client.Open();
                    client.AddRecipeIngredient(ingredient);
                    client.Close();
                }
                catch (Exception ex)
                {
                    throw new Exception("Service error", ex);
                }
            }
        }

        public void DeleteIngredient(int ingredientId)
        {
            using (RecipeServiceClient client = new RecipeServiceClient())
            {
                try
                {
                    client.Open();
                    client.DeleteIngredient(ingredientId);
                    client.Close();
                }
                catch (Exception ex)
                {
                    throw new Exception("Service error", ex);
                }
            }
        }

        public void DeleteRecipe(int recipeId)
        {
            using (RecipeServiceClient client = new RecipeServiceClient())
            {
                try
                {
                    client.Open();
                    client.DeleteRecipe(recipeId);
                    client.Close();
                }
                catch (Exception ex)
                {
                    throw new Exception("Service error", ex);
                }
            }
        }

        public void DeleteRecipeIngredient(int recipeId, int ingredientId)
        {
            using (RecipeServiceClient client = new RecipeServiceClient())
            {
                try
                {
                    client.Open();
                    client.DeleteRecipeIngredient(recipeId, ingredientId);
                    client.Close();
                }
                catch (Exception ex)
                {
                    throw new Exception("Service error", ex);
                }
            }
        }

        public void UpdateIngredient(IngredientDto ingredient)
        {
            using (RecipeServiceClient client = new RecipeServiceClient())
            {
                try
                {
                    client.Open();
                    client.UpdateIngredient(ingredient);
                    client.Close();
                }
                catch (Exception ex)
                {
                    throw new Exception("Service error", ex);
                }
            }
        }

        public void UpdateRecipe(RecipeDto recipe)
        {
            using (RecipeServiceClient client = new RecipeServiceClient())
            {
                try
                {
                    client.Open();
                    client.UpdateRecipe(recipe);
                    client.Close();
                }
                catch (Exception ex)
                {
                    throw new Exception("Service error", ex);
                }
            }
        }

        public void UpdateRecipeDetails(RecipeDetailsDto details)
        {
            using (RecipeServiceClient client = new RecipeServiceClient())
            {
                try
                {
                    client.Open();
                    client.UpdateRecipeDetails(details);
                    client.Close();
                }
                catch (Exception ex)
                {
                    throw new Exception("Service error", ex);
                }
            }
        }

        public void DeleteRecipeIngredients(int recipeId)
        {
            using (RecipeServiceClient client = new RecipeServiceClient())
            {
                try
                {
                    client.Open();
                    client.DeleteRecipeIngredients(recipeId);
                    client.Close();
                }
                catch (Exception ex)
                {
                    throw new Exception("Service error", ex);
                }
            }
        }

        public bool IsServerConnected()
        {
            using (RecipeServiceClient client = new RecipeServiceClient())
            {
                try
                {
                    bool flag;
                    client.Open();
                    flag = client.IsServerConnected();
                    client.Close();
                    return flag;
                }
                catch (Exception ex)
                {
                    throw new Exception("Service error", ex);
                }
            }
        }
    }
}
