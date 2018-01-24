using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using log4net;
using RecipeBook.Service.Data.ModelsDto;

namespace RecipeBook.Service.Data.Contracts.CategoryContract
{
    public class CategoryService : ICategoryService
    {
        private readonly ILog log = LogManager.GetLogger("ServiceLogger");
        private string connectionString = ConfigurationManager.ConnectionStrings["RecipeBookDB"].ConnectionString;

        public IEnumerable<CategoryDto> GetCategories()
        {
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                var categoriesList = new List<CategoryDto>();
                using (var cmd = new SqlCommand("GetCategories", sqlConnection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    try
                    {
                        sqlConnection.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {

                            while (reader.Read())
                            {
                                var category = new CategoryDto()
                                {
                                    CategoryId = reader.GetFieldValue<int>(0),
                                    CategoryName = reader.GetFieldValue<string>(1)
                                };
                                categoriesList.Add(category);
                            }
                        };
                    }
                    catch (SqlException ex)
                    {
                        log.Error(ex);
                        throw ex;
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
                return categoriesList;
            }

        }

        public void AddCategory(CategoryDto category)
        {
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                using (var cmd = new SqlCommand("AddCategory", sqlConnection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@categoryName", category.CategoryName);
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

        public void DeleteCategory(int categoryId)
        {
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                using (var cmd = new SqlCommand("DeleteCategory", sqlConnection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@categoryId", categoryId);
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

        public void UpdateCategory(CategoryDto category)
        {
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                using (var cmd = new SqlCommand("UpdateCategory", sqlConnection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@categoryId", category.CategoryId);
                    cmd.Parameters.AddWithValue("@categoryName", category.CategoryName);
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
    }
}