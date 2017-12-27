using System.Collections.Generic;
using RecipeBook.Common.Models;
using RecipeBook.Data.Repositories;

namespace RecipeBook.Business.Providers
{
    public class UserProvider : IUserProvider
    {
        private IUserRepository userProvider;

        public UserProvider(IUserRepository _userProvider)
        {
            userProvider = _userProvider;
        }

        public IEnumerable<Role> GetRoles()
        {
            return userProvider.GetRoles();
        }

        public IEnumerable<Role> GetUserRoles(string login)
        {
            return userProvider.GetUserRoles(login);
        }

        public IEnumerable<User> GetUsers()
        {
            return userProvider.GetUsers();
        }

        public User GetUserByLogin(string login)
        {
            return userProvider.GetUserByLogin(login);
        }

        public void AddUser(User user)
        {
            userProvider.AddUser(user);
        }

        public void AddUserRole(int userId, int roleId)
        {
            userProvider.AddUserRole(userId, roleId);
        }

        public void DeleteUser(int userId)
        {
            userProvider.DeleteUser(userId);
        }

        public void DeleteUserRoles(int userId)
        {
            userProvider.DeleteUserRoles(userId);
        }

        public void UpdateUser(User user)
        {
            userProvider.UpdateUser(user);
        }
    }
}
