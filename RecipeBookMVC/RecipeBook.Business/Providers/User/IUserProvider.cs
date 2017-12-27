using System.Collections.Generic;
using RecipeBook.Common.Models;

namespace RecipeBook.Business.Providers
{
    public interface IUserProvider
    {
        User GetUserByLogin(string login);
        IEnumerable<Role> GetRoles();
        IEnumerable<User> GetUsers();
        IEnumerable<Role> GetUserRoles(string login);
        void AddUser(User user);
        void DeleteUser(int userId);
        void UpdateUser(User user);
        void AddUserRole(int userId, int roleId);
        void DeleteUserRoles(int userId);
    }
}
