
namespace RecipeBook.Business.AuthentificationService
{
    public interface IValidationService
    {
        bool IsValidUser(string login, string password);
    }
}
