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

    }
}