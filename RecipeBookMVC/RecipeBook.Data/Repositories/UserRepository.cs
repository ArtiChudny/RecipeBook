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
            List<Role> roles = new List<Role>();
            IEnumerable<RoleDto> rolesDto = userClient.GetRoles();
            if (rolesDto != null)
            {
                foreach (var item in rolesDto)
                {
                    roles.Add(converter.ToRole(item));
                }
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
    }
}
