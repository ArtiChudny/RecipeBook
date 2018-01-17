using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using log4net;
using RecipeBook.Service.Data.ModelsDto;

namespace RecipeBook.Service.Data.Contracts
{
    public class RecipeService : IRecipeService
    {
        private readonly ILog log = LogManager.GetLogger("Logger");
        SqlConnection sqlConnection = new SqlConnection();
        string connectionString = ConfigurationManager.ConnectionStrings["RecipeBookDB"].ConnectionString;

        public IEnumerable<RecipeDto> GetRecipes()
        {
            sqlConnection.ConnectionString = connectionString;
            var recipesList = new List<RecipeDto>();

            using (var cmd = new SqlCommand("GetRecipes", sqlConnection))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                try
                {
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
                                Details = null
                            };
                            recipesList.Add(recipe);
                        }
                    };
                    sqlConnection.Close();
                }
                catch (Exception ex)
                {
                    log.Error(ex);
                    throw new Exception("Database error");
                }


            }
            return recipesList;
        }

        public RecipeDetailsDto GetDedails(int id)
        {
            sqlConnection.ConnectionString = connectionString;
            var recipeDetails = new RecipeDetailsDto();

            using (var cmd = new SqlCommand("GetDetails", sqlConnection))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@RecipeId", id);
                try
                {
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
                }
                catch (Exception ex)
                {
                    log.Error(ex);
                    throw ex;
                }
            }
            return recipeDetails;
        }

        public IEnumerable<RecipeIngredientDto> GetRecipeIngredients(int id)
        {
            sqlConnection.ConnectionString = connectionString;
            var recipeIngredientsList = new List<RecipeIngredientDto>();

            using (var cmd = new SqlCommand("GetRecipeIngredients", sqlConnection))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", id);
                try
                {
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
                }
                catch (Exception ex)
                {
                    log.Error(ex);
                    throw ex;
                }
            }
            return recipeIngredientsList;
        }

        public IEnumerable<RecipeDto> GetRecipesByIngredient(string ingredientName)
        {
            sqlConnection.ConnectionString = connectionString;
            var recipesList = new List<RecipeDto>();
            using (var cmd = new SqlCommand("GetRecipesByIngredient", sqlConnection))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ingredient", ingredientName);
                try
                {
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
                }
                catch (Exception ex)
                {
                    log.Error(ex);
                    throw ex;
                }
            }
            return recipesList;
        }

        public IEnumerable<RecipeDto> GetRecipesByName(string recipeName)
        {
            sqlConnection.ConnectionString = connectionString;
            var recipesList = new List<RecipeDto>();
            using (var cmd = new SqlCommand("GetRecipeByName", sqlConnection))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@name", recipeName);
                try
                {
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
                }
                catch (Exception ex)
                {
                    log.Error(ex);
                    throw ex;
                }
            }
            return recipesList;
        }

        public IEnumerable<RecipeDto> GetRecipesByCategory(string categoryName)
        {
            sqlConnection.ConnectionString = connectionString;
            var recipesList = new List<RecipeDto>();

            using (var cmd = new SqlCommand("GetRecipesByCategory", sqlConnection))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@category", categoryName);
                try
                {
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
                }
                catch (Exception ex)
                {
                    log.Error(ex);
                    throw ex;
                }
            }
            return recipesList;
        }

        public IEnumerable<IngredientDto> GetIngredients()
        {
            sqlConnection.ConnectionString = connectionString;
            var ingredientList = new List<IngredientDto>();

            using (var cmd = new SqlCommand("GetIngredients", sqlConnection))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                try
                {
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
                }
                catch (Exception ex)
                {
                    log.Error(ex);
                    throw ex;
                }

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
                catch (Exception ex)
                {
                    log.Error(ex);
                    throw ex;
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
                catch (Exception ex)
                {
                    log.Error(ex);
                    throw ex;
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
                catch (Exception ex)
                {
                    log.Error(ex);
                    throw ex;
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
                catch (Exception ex)
                {
                    log.Error(ex);
                    throw ex;
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
                catch (Exception ex)
                {
                    log.Error(ex);
                    throw ex;
                }
            }
        }

        public int AddRecipe(RecipeDto recipe)
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
                    return recipeId;
                }
                catch (Exception ex)
                {
                    log.Error(ex);
                    throw ex;
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
                    sqlConnection.Close();
                }
                catch (Exception ex)
                {
                    log.Error(ex);
                    throw ex;
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
                catch (Exception ex)
                {
                    log.Error(ex);
                    throw ex;
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
                catch (Exception ex)
                {
                    log.Error(ex);
                    throw ex;
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
                catch (Exception ex)
                {
                    log.Error(ex);
                    throw ex;
                }
            }
        }

        public void DeleteRecipeIngredients(int recipeId)
        {
            sqlConnection.ConnectionString = connectionString;
            using (var cmd = new SqlCommand("DeleteRecipeIngredients", sqlConnection))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@recipeId", recipeId);
                try
                {
                    sqlConnection.Open();
                    cmd.ExecuteNonQuery();
                    sqlConnection.Close();
                }
                catch (Exception ex)
                {
                    log.Error(ex);
                    throw ex;
                }
            }
        }

    }
}