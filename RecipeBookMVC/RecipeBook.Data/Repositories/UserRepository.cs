using System;
using System.Collections.Generic;
using RecipeBook.Data.Converters;
using RecipeBook.Common.Models;
using RecipeBook.Data.Clients;
using RecipeBook.Data.UserService;


namespace RecipeBook.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        IUserClient userClient;
        IConverter converter;

        public UserRepository(IUserClient _userClient, IConverter _converter)
        {
            userClient = _userClient;
            converter = _converter;
        }

        public IEnumerable<Role> GetRoles()
        {
            IEnumerable<Role> roles = null;
            IEnumerable<RoleDto> rolesDto = userClient.GetRoles();
            if (rolesDto != null)
            {
                roles = converter.ToRoles(rolesDto);
            }
            return roles;
        }

        public User GetUserByLogin(string login)
        {
            User user = new User();
            UserDto userDto = userClient.GetUserByLogin(login);
            user = converter.ToUser(userDto);
            return user;
        }

        public IEnumerable<User> GetUsers()
        {
            IEnumerable<UserDto> usersDto = userClient.GetUsers();
            List<User> users = new List<User>();
            foreach (var item in usersDto)
            {
                users.Add(converter.ToUser(item));
            }
            return users;
        }

        public IEnumerable<Role> GetUserRoles(string login)
        {
            IEnumerable<Role> userRoles = null;
            IEnumerable<RoleDto> userRolesDto = userClient.GetUserRoles(login);
            if (userRolesDto != null)
            {
                userRoles = converter.ToRoles(userRolesDto);
            }
            return userRoles;
        }

        public void AddUser(User user)
        {
            userClient.AddUser(converter.ToUserDto(user));
        }

        public void DeleteUser(int userId)
        {
            userClient.DeleteUser(userId);
        }

        public void UpdateUser(User user)
        {
            userClient.UpdateUser(converter.ToUserDto(user));
        }

        public void AddUserRole(int userId, int roleId)
        {
            userClient.AddUserRole(userId,roleId);
        }

        public void DeleteUserRoles(int userId)
        {
            userClient.DeleteUserRoles(userId);
        }
    }
}
