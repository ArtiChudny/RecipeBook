using System.Collections.Generic;
using RecipeBook.Data.UserService;

namespace RecipeBook.Data.Clients
{
    public interface IUserClient
    {
        UserDto GetUserByLogin(string login);
        IEnumerable<RoleDto> GetRoles();
    }
}
