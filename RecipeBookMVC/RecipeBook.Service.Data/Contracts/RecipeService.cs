using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using RecipeBook.Service.Data.ModelsDto;

namespace RecipeBook.Service.Data.Contracts
{
    public class RecipeService : IRecipeService
    {
        SqlConnection sqlConnection = new SqlConnection();
        string connectionString = ConfigurationManager.ConnectionStrings["RecipeBookDB"].ConnectionString;

        public IEnumerable<RecipeDto> GetRecipes()
        {
            sqlConnection.ConnectionString = connectionString;
            var recipesList = new List<RecipeDto>();

            using (var cmd = new SqlCommand("GetRecipes", sqlConnection))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                sqlConnection.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var recipe = new RecipeDto()
                        {
                            RecipeId = reader.GetFieldValue<int>(0),
                            RecipeName = reader.GetFieldValue<string>(1),
                            CategoryId = reader.GetFieldValue<int>(2),
                            PhotoUrl = reader.GetFieldValue<string>(3)
                        };
                        recipesList.Add(recipe);
                    }
                };
                sqlConnection.Close();
            }
            return recipesList;
        }

        public RecipeDetailsDto GetDedails(int id)
        {
            sqlConnection.ConnectionString = connectionString;
            SqlCommand cmd = new SqlCommand("GetDetails", sqlConnection)
            { CommandType = CommandType.StoredProcedure };
            cmd.Parameters.AddWithValue("@RecipeId", id);

            var recipeDetails = new RecipeDetailsDto();

            sqlConnection.Open();
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    recipeDetails.RecipeId = reader.GetFieldValue<int>(0);
                    recipeDetails.Description = reader.GetFieldValue<string>(1);
                    recipeDetails.CookingTime = reader.GetFieldValue<string>(2);
                    recipeDetails.CookingTemperature = reader.GetFieldValue<string>(3);
                    recipeDetails.Steps = reader.GetFieldValue<string>(4);
                }
            }
            sqlConnection.Close();
            return recipeDetails;
        }

        public IEnumerable<RecipeIngredientDto> GetRecipeIngredients(int id)
        {
            sqlConnection.ConnectionString = connectionString;
            SqlCommand cmd = new SqlCommand("GetRecipeIngredients", sqlConnection)
            { CommandType = CommandType.StoredProcedure };
            cmd.Parameters.AddWithValue("@Id", id);

            var recipeIngredientsList = new List<RecipeIngredientDto>();

            sqlConnection.Open();
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    var recipeIngredient = new RecipeIngredientDto()
                    {
                        RecipeId = reader.GetFieldValue<int>(0),
                        IngredientName = reader.GetFieldValue<string>(1),
                        Weight = reader.GetFieldValue<string>(2),
                    };
                    recipeIngredientsList.Add(recipeIngredient);
                }
            };
            sqlConnection.Close();
            return recipeIngredientsList;
        }

        public IEnumerable<RecipeDto> GetRecipesByIngredient(string ingredientName)
        {
            sqlConnection.ConnectionString = connectionString;
            SqlCommand cmd = new SqlCommand("GetRecipesByIngredient", sqlConnection)
            { CommandType = CommandType.StoredProcedure };
            cmd.Parameters.AddWithValue("@ingredient", ingredientName);

            var recipesList = new List<RecipeDto>();

            sqlConnection.Open();
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    var recipe = new RecipeDto()
                    {
                        RecipeId = reader.GetFieldValue<int>(0),
                        RecipeName = reader.GetFieldValue<string>(1),
                        CategoryId = reader.GetFieldValue<int>(2),
                        PhotoUrl = reader.GetFieldValue<string>(3),
                    };
                    recipesList.Add(recipe);
                }
            };
            sqlConnection.Close();
            return recipesList;
        }
    }

}