using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using RecipeBook.Service.Data.ModelsDto;


namespace RecipeBook.Service.Data.Contracts.UserContract
{
    public class UserService : IUserService
    {
        SqlConnection sqlConnection = new SqlConnection();
        string connectionString = ConfigurationManager.ConnectionStrings["RecipeBookDB"].ConnectionString;

        public UserDto GetUserByLogin(string login)
        {
            sqlConnection.ConnectionString = connectionString;
            SqlCommand cmd = new SqlCommand("GetUserByLogin", sqlConnection)
            { CommandType = CommandType.StoredProcedure };
            cmd.Parameters.AddWithValue("@UserLogin", login);

            var user = new UserDto();

            sqlConnection.Open();
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    user.UserId = reader.GetFieldValue<int>(0);
                    user.Login = reader.GetFieldValue<string>(1);
                    user.Password = reader.GetFieldValue<string>(2);
                    user.Email = reader.GetFieldValue<string>(3);
                }
            }
            sqlConnection.Close();

            cmd = new SqlCommand("GetUserRolesByLogin", sqlConnection)
            { CommandType = CommandType.StoredProcedure };
            cmd.Parameters.AddWithValue("@login", login);


            var rolelist = new List<RoleDto>();
            sqlConnection.Open();
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    var role = new RoleDto()
                    {
                        RoleId = reader.GetFieldValue<int>(0),
                        RoleName = reader.GetFieldValue<string>(1)
                    };
                    rolelist.Add(role);
                }
            }
            sqlConnection.Close();

            user.UserRoles = rolelist;
            return user;
        }

        public IEnumerable<RoleDto> GetRoles()
        {
            sqlConnection.ConnectionString = connectionString;
            var roleList = new List<RoleDto>();

            using (var cmd = new SqlCommand("GetRoles", sqlConnection))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                sqlConnection.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var role = new RoleDto()
                        {
                            RoleId = reader.GetFieldValue<int>(0),
                            RoleName = reader.GetFieldValue<string>(1)
                        };
                        roleList.Add(role);
                    }
                };
                sqlConnection.Close();
            }
            return roleList;
        }

    }
}
