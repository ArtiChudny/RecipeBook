using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using log4net;
using RecipeBook.Service.Data.ModelsDto;

namespace RecipeBook.Service.Data.Contracts.UserContract
{
    public class UserService : IUserService
    {
        private readonly ILog log = LogManager.GetLogger("Logger");
        SqlConnection sqlConnection = new SqlConnection();
        string connectionString = ConfigurationManager.ConnectionStrings["RecipeBookDB"].ConnectionString;

        public UserDto GetUserByLogin(string login)
        {
            var user = new UserDto();
            sqlConnection.ConnectionString = connectionString;
            using (var cmd = new SqlCommand("GetUserByLogin", sqlConnection))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@UserLogin", login);
                try
                {
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
                    user.UserRoles = GetUserRoles(user.Login);
                }
                catch (Exception ex)
                {
                    log.Error(ex);
                    throw ex;
                }
            }
            return user;
        }

        public IEnumerable<RoleDto> GetRoles()
        {
            sqlConnection.ConnectionString = connectionString;
            var roleList = new List<RoleDto>();

            using (var cmd = new SqlCommand("GetRoles", sqlConnection))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                try
                {
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
                catch (Exception ex)
                {
                    log.Error(ex);
                    throw ex;
                }
            }
            return roleList;
        }

        public IEnumerable<UserDto> GetUsers()
        {
            sqlConnection.ConnectionString = connectionString;
            var userList = new List<UserDto>();

            using (var cmd = new SqlCommand("GetUsers", sqlConnection))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                try
                {
                    sqlConnection.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var user = new UserDto()
                            {
                                UserId = reader.GetFieldValue<int>(0),
                                Login = reader.GetFieldValue<string>(1),
                                Password = reader.GetFieldValue<string>(2),
                                Email = reader.GetFieldValue<string>(3)
                            };
                            userList.Add(user);
                        }
                    };
                    sqlConnection.Close();
                    foreach (var item in userList)
                    {
                        item.UserRoles = GetUserRoles(item.Login);
                    }
                }
                catch (Exception ex)
                {
                    log.Error(ex);
                    throw ex;
                }
            }
            return userList;
        }


        public IEnumerable<RoleDto> GetUserRoles(string login)
        {
            sqlConnection.ConnectionString = connectionString;
            var roleList = new List<RoleDto>();

            using (var cmd = new SqlCommand("GetUserRolesByLogin", sqlConnection))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@login", login);
                try
                {
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
                catch (Exception ex)
                {
                    log.Error(ex);
                    throw ex;
                }
            }
            return roleList;
        }

        public void AddUser(UserDto user)
        {
            sqlConnection.ConnectionString = connectionString;

            using (var cmd = new SqlCommand("AddUser", sqlConnection))
            {
                int userId;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@login", user.Login);
                cmd.Parameters.AddWithValue("@password", user.Password);
                cmd.Parameters.AddWithValue("@email", user.Email);
                try
                {
                    sqlConnection.Open();
                    userId = Convert.ToInt32(cmd.ExecuteScalar());
                    sqlConnection.Close();
                    foreach (var item in user.UserRoles)
                    {
                        AddUserRole(userId, item.RoleId);
                    }
                }
                catch (Exception ex)
                {
                    log.Error(ex);
                    throw ex;
                }
            }

        }

        public void DeleteUser(int userId)
        {
            sqlConnection.ConnectionString = connectionString;

            using (var cmd = new SqlCommand("DeleteUser", sqlConnection))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@userId", userId);
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

        public void UpdateUser(UserDto user)
        {
            sqlConnection.ConnectionString = connectionString;
            using (var cmd = new SqlCommand("UpdateUser", sqlConnection))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@userId", user.UserId);
                cmd.Parameters.AddWithValue("@login", user.Login);
                cmd.Parameters.AddWithValue("@password", user.Password);
                cmd.Parameters.AddWithValue("@email", user.Email);
                try
                {
                    sqlConnection.Open();
                    cmd.ExecuteNonQuery();
                    sqlConnection.Close();
                    DeleteUserRoles(user.UserId);
                    foreach (var item in user.UserRoles)
                    {
                        AddUserRole(user.UserId, item.RoleId);
                    }
                }
                catch (Exception ex)
                {
                    log.Error(ex);
                    throw ex;
                }
            }

        }


        public void AddUserRole(int userId, int roleId)
        {
            sqlConnection.ConnectionString = connectionString;

            using (var cmd = new SqlCommand("AddUserRole", sqlConnection))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@userId", userId);
                cmd.Parameters.AddWithValue("@roleId", roleId);
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

        public void DeleteUserRoles(int userId)
        {
            sqlConnection.ConnectionString = connectionString;

            using (var cmd = new SqlCommand("DeleteUserRolesById", sqlConnection))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@userId", userId);
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
