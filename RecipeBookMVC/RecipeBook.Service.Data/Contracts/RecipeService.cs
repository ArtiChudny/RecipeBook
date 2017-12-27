using System;
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
                        IngredientId = reader.GetFieldValue<int>(3)
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

        public IEnumerable<RecipeDto> GetRecipesByName(string recipeName)
        {
            sqlConnection.ConnectionString = connectionString;
            SqlCommand cmd = new SqlCommand("GetRecipeByName", sqlConnection)
            { CommandType = CommandType.StoredProcedure };
            cmd.Parameters.AddWithValue("@name", recipeName);

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

        public IEnumerable<RecipeDto> GetRecipesByCategory(string categoryName)
        {
            sqlConnection.ConnectionString = connectionString;
            SqlCommand cmd = new SqlCommand("GetRecipesByCategory", sqlConnection)
            { CommandType = CommandType.StoredProcedure };
            cmd.Parameters.AddWithValue("@category", categoryName);

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

        public IEnumerable<IngredientDto> GetIngredients()
        {
            sqlConnection.ConnectionString = connectionString;
            var ingredientList = new List<IngredientDto>();

            using (var cmd = new SqlCommand("GetIngredients", sqlConnection))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                sqlConnection.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var ingredient = new IngredientDto()
                        {
                            IngredientId = reader.GetFieldValue<int>(0),
                            IngredientName = reader.GetFieldValue<string>(1),
                        };
                        ingredientList.Add(ingredient);
                    }
                };
                sqlConnection.Close();
            }
            return ingredientList;
        }


        public void AddIngredient(IngredientDto ingredient)
        {
            sqlConnection.ConnectionString = connectionString;
            using (var cmd = new SqlCommand("AddIngredient", sqlConnection))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ingredientName", ingredient.IngredientName);
                try
                {
                    sqlConnection.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        public void DeleteIngredient(int ingredientId)
        {
            sqlConnection.ConnectionString = connectionString;
            using (var cmd = new SqlCommand("DeleteIngredient", sqlConnection))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ingredientId", ingredientId);
                try
                {
                    sqlConnection.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        public void UpdateIngredient(IngredientDto ingredient)
        {
            sqlConnection.ConnectionString = connectionString;
            using (var cmd = new SqlCommand("UpdateIngredient", sqlConnection))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ingredientId", ingredient.IngredientId);
                cmd.Parameters.AddWithValue("@ingredientName", ingredient.IngredientName);
                try
                {
                    sqlConnection.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        public void AddRecipeIngredient(RecipeIngredientDto recipeIngredient)
        {
            sqlConnection.ConnectionString = connectionString;
            using (var cmd = new SqlCommand("AddRecipeIngredient", sqlConnection))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@recipeId", recipeIngredient.RecipeId);
                cmd.Parameters.AddWithValue("@ingredientId", recipeIngredient.IngredientId);
                cmd.Parameters.AddWithValue("@weight", recipeIngredient.Weight);
                try
                {
                    sqlConnection.Open();
                    cmd.ExecuteNonQuery();
                    sqlConnection.Close();
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        public void DeleteRecipeIngredient(int recipeId, int ingredientId)
        {
            sqlConnection.ConnectionString = connectionString;
            using (var cmd = new SqlCommand("DeleteRecipeIngredient", sqlConnection))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@recipeId", recipeId);
                cmd.Parameters.AddWithValue("@ingredientId", ingredientId);
                try
                {
                    sqlConnection.Open();
                    cmd.ExecuteNonQuery();
                    sqlConnection.Close();
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        public void AddRecipe(RecipeDto recipe)
        {
            int recipeId;
            sqlConnection.ConnectionString = connectionString;
            using (var cmd = new SqlCommand("AddRecipe", sqlConnection))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@recipeName", recipe.RecipeName);
                cmd.Parameters.AddWithValue("@categoryId", recipe.CategoryId);
                cmd.Parameters.AddWithValue("@photoUrl", recipe.PhotoUrl);
                try
                {
                    sqlConnection.Open();
                    recipeId = Convert.ToInt32(cmd.ExecuteScalar());
                    recipe.Details.RecipeId = recipeId;
                    sqlConnection.Close();
                    AddRecipeDetails(recipe.Details);
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        public void DeleteRecipe(int recipeId)
        {
            sqlConnection.ConnectionString = connectionString;
            using (var cmd = new SqlCommand("DeleteRecipe", sqlConnection))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@recipeId", recipeId);
                try
                {
                    sqlConnection.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        public void UpdateRecipe(RecipeDto recipe)
        {
            sqlConnection.ConnectionString = connectionString;
            using (var cmd = new SqlCommand("UpdateRecipe", sqlConnection))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@recipeId", recipe.RecipeId);
                cmd.Parameters.AddWithValue("@recipeName", recipe.RecipeName);
                cmd.Parameters.AddWithValue("@categoryId", recipe.CategoryId);
                cmd.Parameters.AddWithValue("@photoUrl", recipe.PhotoUrl);
                try
                {
                    sqlConnection.Open();
                    cmd.ExecuteNonQuery();
                    sqlConnection.Close();
                    UpdateRecipeDetails(recipe.Details);
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        public void AddRecipeDetails(RecipeDetailsDto details)
        {
            sqlConnection.ConnectionString = connectionString;
            using (var cmd = new SqlCommand("AddRecipeDetails", sqlConnection))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@recipeId", details.RecipeId);
                cmd.Parameters.AddWithValue("@description", details.Description);
                cmd.Parameters.AddWithValue("@time", details.CookingTime);
                cmd.Parameters.AddWithValue("@temperature", details.CookingTemperature);
                cmd.Parameters.AddWithValue("@steps", details.Steps);
                try
                {
                    sqlConnection.Open();
                    cmd.ExecuteNonQuery();
                    sqlConnection.Close();
                }
                catch (Exception)
                {
                    throw;
                }
            }


        }

        public void UpdateRecipeDetails(RecipeDetailsDto details)
        {
            sqlConnection.ConnectionString = connectionString;
            using (var cmd = new SqlCommand("UpdateRecipeDetails", sqlConnection))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@recipeId", details.RecipeId);
                cmd.Parameters.AddWithValue("@description", details.Description);
                cmd.Parameters.AddWithValue("@time", details.CookingTime);
                cmd.Parameters.AddWithValue("@temperature", details.CookingTemperature);
                cmd.Parameters.AddWithValue("@steps", details.Steps);
                try
                {
                    sqlConnection.Open();
                    cmd.ExecuteNonQuery();
                    sqlConnection.Close();
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }
    }

}