using System.Collections.Generic;
using System.Runtime.Serialization;

namespace RecipeBook.Service.Data.ModelsDto
{
    [DataContract]
    public class UserDto
    {
        [DataMember]
        public int UserId { get; set; }
        [DataMember]
        public string Login { get; set; }
        [DataMember]
        public string Password { get; set; }
        [DataMember]
        public string Email { get; set; }
        [DataMember]
        public IEnumerable<RoleDto> UserRoles { get; set; }
    }
}
