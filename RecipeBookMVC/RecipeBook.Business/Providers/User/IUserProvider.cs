using System.Collections.Generic;
using RecipeBook.Common.Models;

namespace RecipeBook.Business.Providers
{
    public interface IUserProvider
    {
        User GetUserByLogin(string login);
        IEnumerable<Role> GetRoles();
    }
}
