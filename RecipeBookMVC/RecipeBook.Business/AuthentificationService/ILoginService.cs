using RecipeBook.Common.Enums;

namespace RecipeBook.Business.AuthentificationService
{
    public interface ILoginService
    {
        LoginResult Login(string login, string password);
        void Logout();
    }
}
