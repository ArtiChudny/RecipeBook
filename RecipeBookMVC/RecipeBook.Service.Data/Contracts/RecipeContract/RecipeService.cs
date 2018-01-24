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
        private readonly ILog log = LogManager.GetLogger("ServiceLogger");
        private string connectionString = ConfigurationManager.ConnectionStrings["RecipeBookDB"].ConnectionString;

        public IEnumerable<RecipeDto> GetRecipes()
        {
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                var recipesList = new List<RecipeDto>();
                using (var cmd = new SqlCommand("GetRecipes", sqlConnection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    try
                    {
                        sqlConnection.Open();
                        SqlDataReader reader = cmd.ExecuteReader();
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
                    }
                    catch (Exception ex)
                    {
                        log.Error("Db error", ex);
                        throw ex;
                    }
                    finally
                    {
                        sqlConnection.Close();
                    }
                }
                return recipesList;

            }
        }

        public RecipeDetailsDto GetDedails(int id)
        {
            using (var sqlConnection = new SqlConnection(connectionString))
            {
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
                    }
                    catch (Exception ex)
                    {
                        log.Error(ex);
                        throw ex;
                    }
                    finally
                    {
                        sqlConnection.Close();
                    }
                }
                return recipeDetails;
            }
        }

        public IEnumerable<RecipeIngredientDto> GetRecipeIngredients(int id)
        {
            using (var sqlConnection = new SqlConnection(connectionString))
            {
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
                        }
                    }
                    catch (Exception ex)
                    {
                        log.Error(ex);
                        throw ex;
                    }
                    finally
                    {
                        sqlConnection.Close();
                    }
                }
                return recipeIngredientsList;
            }
        }

        public IEnumerable<RecipeDto> GetRecipesByIngredient(string ingredientName)
        {
            using (var sqlConnection = new SqlConnection(connectionString))
            {
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
                        }
                    }
                    catch (Exception ex)
                    {
                        log.Error(ex);
                        throw ex;
                    }
                    finally
                    {
                        sqlConnection.Close();
                    }
                }
                return recipesList;
            }
        }

        public IEnumerable<RecipeDto> GetRecipesByName(string recipeName)
        {
            using (var sqlConnection = new SqlConnection(connectionString))
            {
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
                        }
                    }
                    catch (Exception ex)
                    {
                        log.Error(ex);
                        throw ex;
                    }
                    finally
                    {
                        sqlConnection.Close();
                    }
                }
                return recipesList;
            }
        }

        public IEnumerable<RecipeDto> GetRecipesByCategory(string categoryName)
        {
            using (var sqlConnection = new SqlConnection(connectionString))
            {
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
                    }
                    catch (Exception ex)
                    {
                        log.Error(ex);
                        throw ex;
                    }
                    finally
                    {
                        sqlConnection.Close();
                    }
                }
                return recipesList;
            }
        }

        public IEnumerable<IngredientDto> GetIngredients()
        {
            using (var sqlConnection = new SqlConnection(connectionString))
            {
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
                    finally
                    {
                        sqlConnection.Close();
                    }
                }
                return ingredientList;
            }
        }


        public void AddIngredient(IngredientDto ingredient)
        {
            using (var sqlConnection = new SqlConnection(connectionString))
            {
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
                    finally
                    {
                        sqlConnection.Close();
                    }
                }
            }
        }

        public void DeleteIngredient(int ingredientId)
        {
            using (var sqlConnection = new SqlConnection(connectionString))
            {
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
                    finally
                    {
                        sqlConnection.Close();
                    }
                }
            }
        }

        public void UpdateIngredient(IngredientDto ingredient)
        {
            using (var sqlConnection = new SqlConnection(connectionString))
            {
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
                    finally
                    {
                        sqlConnection.Close();
                    }
                }
            }
        }

        public void AddRecipeIngredient(RecipeIngredientDto recipeIngredient)
        {
            using (var sqlConnection = new SqlConnection(connectionString))
            {
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
                    }
                    catch (Exception ex)
                    {
                        log.Error(ex);
                        throw ex;
                    }
                    finally
                    {
                        sqlConnection.Close();
                    }
                }
            }
        }

        public void DeleteRecipeIngredient(int recipeId, int ingredientId)
        {
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                using (var cmd = new SqlCommand("DeleteRecipeIngredient", sqlConnection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@recipeId", recipeId);
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
                    finally
                    {
                        sqlConnection.Close();
                    }
                }
            }
        }

        public int AddRecipe(RecipeDto recipe)
        {
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                int recipeId = 0;
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
                        AddRecipeDetails(recipe.Details);

                    }
                    catch (Exception ex)
                    {
                        log.Error(ex);
                        throw ex;
                    }
                    finally
                    {
                        sqlConnection.Close();
                    }
                }
                return recipeId;
            }
        }

        public void DeleteRecipe(int recipeId)
        {
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                using (var cmd = new SqlCommand("DeleteRecipe", sqlConnection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@recipeId", recipeId);
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
                    finally
                    {
                        sqlConnection.Close();
                    }
                }
            }
        }

        public void UpdateRecipe(RecipeDto recipe)
        {
            using (var sqlConnection = new SqlConnection(connectionString))
            {
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
                    }
                    catch (Exception ex)
                    {
                        log.Error(ex);
                        throw ex;
                    }
                    finally
                    {
                        sqlConnection.Close();
                    }
                }
            }
        }

        public void AddRecipeDetails(RecipeDetailsDto details)
        {
            using (var sqlConnection = new SqlConnection(connectionString))
            {
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
                    }
                    catch (Exception ex)
                    {
                        log.Error(ex);
                        throw ex;
                    }
                    finally
                    {
                        sqlConnection.Close();
                    }
                }
            }
        }

        public void UpdateRecipeDetails(RecipeDetailsDto details)
        {
            using (var sqlConnection = new SqlConnection(connectionString))
            {
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
                    }
                    catch (Exception ex)
                    {
                        log.Error(ex);
                        throw ex;
                    }
                    finally
                    {
                        sqlConnection.Close();
                    }
                }
            }
        }

        public void DeleteRecipeIngredients(int recipeId)
        {
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                using (var cmd = new SqlCommand("DeleteRecipeIngredients", sqlConnection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@recipeId", recipeId);
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
                    finally
                    {
                        sqlConnection.Close();
                    }
                }
            }
        }

        public bool IsServerConnected()
        {
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                try
                {
                    sqlConnection.Open();
                    return true;
                }
                catch (SqlException)
                {
                    return false;
                }
                finally
                {
                    sqlConnection.Close();
                }
            }
            
        }

    }
}