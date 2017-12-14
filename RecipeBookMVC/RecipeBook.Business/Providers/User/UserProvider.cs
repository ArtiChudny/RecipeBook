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

        public User GetUserByLogin(string login)
        {
            return userProvider.GetUserByLogin(login);
        }

    }
}
