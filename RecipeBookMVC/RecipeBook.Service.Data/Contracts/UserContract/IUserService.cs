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
        [OperationContract]
        IEnumerable<UserDto> GetUsers();
        [OperationContract]
        IEnumerable<RoleDto> GetUserRoles(string login);
        [OperationContract]
        void AddUser(UserDto user);
        [OperationContract]
        void DeleteUser(int userId);
        [OperationContract]
        void UpdateUser(UserDto user);
        [OperationContract]
        void AddUserRole(int userId, int roleId);
        [OperationContract]
        void DeleteUserRoles(int userId);



    }
}
