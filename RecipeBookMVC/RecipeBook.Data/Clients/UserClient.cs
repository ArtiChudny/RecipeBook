using System;
using System.Collections.Generic;
using RecipeBook.Data.UserService;

namespace RecipeBook.Data.Clients
{
    public class UserClient : IUserClient
    {
        public void AddUser(UserDto user)
        {
            using (UserServiceClient client = new UserServiceClient())
            {
                try
                {
                    client.Open();
                    client.AddUser(user);
                    client.Close();
                }
                catch (Exception ex)
                {
                    throw new Exception("Service error", ex);
                }
            }
        }

        public void AddUserRole(int userId, int roleId)
        {
            using (UserServiceClient client = new UserServiceClient())
            {
                try
                {
                    client.Open();
                    client.AddUserRole(userId, roleId);
                    client.Close();
                }
                catch (Exception ex)
                {
                    throw new Exception("Service error", ex);
                }
            }
        }

        public void DeleteUser(int userId)
        {
            using (UserServiceClient client = new UserServiceClient())
            {
                try
                {
                    client.Open();
                    client.DeleteUser(userId);
                    client.Close();
                }
                catch (Exception ex)
                {
                    throw new Exception("Service error", ex);
                }
            }
        }

        public void DeleteUserRoles(int userId)
        {
            using (UserServiceClient client = new UserServiceClient())
            {
                try
                {
                    client.Open();
                    client.DeleteUserRoles(userId);
                    client.Close();
                }
                catch (Exception ex)
                {
                    throw new Exception("Service error", ex);
                }
            }
        }

        public IEnumerable<RoleDto> GetRoles()
        {
            List<RoleDto> rolesDto = new List<RoleDto>();
            using (UserServiceClient client = new UserServiceClient())
            {
                try
                {
                    client.Open();
                    rolesDto.AddRange(client.GetRoles());
                    client.Close();
                }
                catch (Exception ex)
                {
                    throw new Exception("Service error", ex);
                }
            }
            return rolesDto;

        }

        public UserDto GetUserByLogin(string login)
        {
            UserDto userDto = new UserDto();
            using (UserServiceClient client = new UserServiceClient())
            {
                try
                {
                    client.Open();
                    userDto = client.GetUserByLogin(login);
                    client.Close();
                }
                catch (Exception ex)
                {
                    throw new Exception("Service error", ex);
                }
            }
            return userDto;
        }

        public IEnumerable<RoleDto> GetUserRoles(string login)
        {
            List<RoleDto> userRolesDto = new List<RoleDto>();
            using (UserServiceClient client = new UserServiceClient())
            {
                try
                {
                    client.Open();
                    userRolesDto.AddRange(client.GetUserRoles(login));
                    client.Close();
                }
                catch (Exception ex)
                {
                    throw new Exception("Service error", ex);
                }

            }
            return userRolesDto;
        }

        public IEnumerable<UserDto> GetUsers()
        {
            List<UserDto> usersDto = new List<UserDto>();
            using (UserServiceClient client = new UserServiceClient())
            {
                try
                {
                    client.Open();
                    usersDto.AddRange(client.GetUsers());
                    client.Close();
                }
                catch (Exception ex)
                {
                    throw new Exception("Service error", ex);
                }
            }
            return usersDto;
        }

        public void UpdateUser(UserDto user)
        {
            using (UserServiceClient client = new UserServiceClient())
            {
                try
                {
                    client.Open();
                    client.UpdateUser(user);
                    client.Close();
                }
                catch (Exception ex)
                {
                    throw new Exception("Service error", ex);
                }
            }
          
        }
    }
}
