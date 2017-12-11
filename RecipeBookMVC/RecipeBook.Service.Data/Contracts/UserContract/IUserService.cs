using System.ServiceModel;
using RecipeBook.Service.Data.ModelsDto;
using System.Collections.Generic;

namespace RecipeBook.Service.Data.Contracts.UserContract
{
    [ServiceContract]
    public interface IUserService
    {
        [OperationContract]
        UserDto GetUserByLogin(string login);
        [OperationContract]
        IEnumerable<RoleDto> GetRoles();
    }
}
