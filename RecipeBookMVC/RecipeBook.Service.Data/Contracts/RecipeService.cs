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
            List<RecipeDto> recipesList = new List<RecipeDto>();

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

            RecipeDetailsDto recipeDetails = new RecipeDetailsDto();

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

    }
}
