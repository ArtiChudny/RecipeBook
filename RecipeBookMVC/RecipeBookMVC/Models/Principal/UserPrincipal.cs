using System.Security.Principal;
using RecipeBook.Common.Models;

namespace RecipeBook.Web.Models.Principal
{
    public class UserPrincipal : IPrincipal
    {
        public int UserId { get; set; }
        public string Login { get; set; }
        public Role[] Roles { get; set; }

        public IIdentity Identity
        {
            get; private set;

        }

        public UserPrincipal(string userName)
        {
            Identity = new GenericIdentity(userName);
        }

        public bool IsInRole(string role)
        {
            bool flag = false;
            foreach (var item in Roles)
            {
                if (item.RoleName == role)
                {
                    flag = true;
                }

            }
            return flag;
        }

    }
}
