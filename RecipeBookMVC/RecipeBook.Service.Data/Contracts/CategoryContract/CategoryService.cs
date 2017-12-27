using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using RecipeBook.Service.Data.ModelsDto;

namespace RecipeBook.Service.Data.Contracts.CategoryContract
{
    public class CategoryService : ICategoryService
    {
        SqlConnection sqlConnection = new SqlConnection();
        string connectionString = ConfigurationManager.ConnectionStrings["RecipeBookDB"].ConnectionString;

        public IEnumerable<CategoryDto> GetCategories()
        {
            sqlConnection.ConnectionString = connectionString;
            var categoriesList = new List<CategoryDto>();

            using (var cmd = new SqlCommand("GetCategories", sqlConnection))
            {
                cmd.CommandType = CommandType.StoredProcedure;

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
                sqlConnection.Close();
            }
            return categoriesList;
        }

        public void AddCategory(CategoryDto category)
        {
            sqlConnection.ConnectionString = connectionString;
            using (var cmd = new SqlCommand("AddCategory", sqlConnection))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@categoryName", category.CategoryName);
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

        public void DeleteCategory(int categoryId)
        {
            sqlConnection.ConnectionString = connectionString;
            using (var cmd = new SqlCommand("DeleteCategory", sqlConnection))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@categoryId", categoryId);
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

        public void UpdateCategory(CategoryDto category)
        {
            sqlConnection.ConnectionString = connectionString;
            using (var cmd = new SqlCommand("UpdateCategory", sqlConnection))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@categoryId", category.CategoryId);
                cmd.Parameters.AddWithValue("@categoryName", category.CategoryName);
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