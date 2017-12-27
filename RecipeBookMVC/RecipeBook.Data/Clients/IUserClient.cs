using System.Collections.Generic;
using RecipeBook.Data.UserService;

namespace RecipeBook.Data.Clients
{
    public interface IUserClient
    {
        UserDto GetUserByLogin(string login);
        IEnumerable<RoleDto> GetRoles();
        IEnumerable<UserDto> GetUsers();
        IEnumerable<RoleDto> GetUserRoles(string login);
        void AddUser(UserDto user);
        void DeleteUser(int userId);
        void UpdateUser(UserDto user);
        void AddUserRole(int userId, int roleId);
        void DeleteUserRoles(int userId);
    }
}
