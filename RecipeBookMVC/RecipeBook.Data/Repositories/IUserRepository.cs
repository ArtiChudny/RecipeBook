using System.Collections.Generic;
using RecipeBook.Common.Models;

namespace RecipeBook.Data.Repositories
{
    public interface IUserRepository
    {
        User GetUserByLogin(string login);
        IEnumerable<Role> GetRoles();
    }
}
