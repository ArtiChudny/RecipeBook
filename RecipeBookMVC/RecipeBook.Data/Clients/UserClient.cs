using System.Collections.Generic;
using RecipeBook.Data.UserService;

namespace RecipeBook.Data.Clients
{
    public class UserClient : IUserClient
    {
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
    }
}
