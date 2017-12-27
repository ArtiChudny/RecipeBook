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
                client.Open();
                client.AddUser(user);
                client.Close();
            }
        }

        public void AddUserRole(int userId, int roleId)
        {
            using (UserServiceClient client = new UserServiceClient())
            {
                client.Open();
                client.AddUserRole(userId,roleId);
                client.Close();
            }
        }

        public void DeleteUser(int userId)
        {
            using (UserServiceClient client = new UserServiceClient())
            {
                client.Open();
                client.DeleteUser(userId);
                client.Close();
            }
        }

        public void DeleteUserRoles(int userId)
        {
            using (UserServiceClient client = new UserServiceClient())
            {
                client.Open();
                client.DeleteUserRoles(userId);
                client.Close();
            }
        }

        public IEnumerable<RoleDto> GetRoles()
        {
            List<RoleDto> rolesDto = new List<RoleDto>();
            using (UserServiceClient client = new UserServiceClient())
            {
                client.Open();
                rolesDto.AddRange(client.GetRoles());
                client.Close();
            }
            return rolesDto;

        }

        public UserDto GetUserByLogin(string login)
        {
            UserDto userDto = new UserDto();
            using (UserServiceClient client = new UserServiceClient())
            {
                client.Open();
                userDto = client.GetUserByLogin(login);
                client.Close();
            }
            return userDto;
        }

        public IEnumerable<RoleDto> GetUserRoles(string login)
        {
            List<RoleDto> userRolesDto = new List<RoleDto>();
            using (UserServiceClient client = new UserServiceClient())
            {
                client.Open();
                userRolesDto.AddRange(client.GetUserRoles(login));
                client.Close();
            }
            return userRolesDto;
        }

        public IEnumerable<UserDto> GetUsers()
        {
            List<UserDto> usersDto = new List<UserDto>();
            using (UserServiceClient client = new UserServiceClient())
            {
                client.Open();
                usersDto.AddRange(client.GetUsers());
                client.Close();
            }
            return usersDto;
        }

        public void UpdateUser(UserDto user)
        {
            using (UserServiceClient client = new UserServiceClient())
            {
                client.Open();
                client.UpdateUser(user);
                client.Close();
            }
          
        }
    }
}
