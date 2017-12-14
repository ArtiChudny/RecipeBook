using RecipeBook.Business.Providers;

namespace RecipeBook.Business.AuthentificationService
{
    public class ValidationService : IValidationService
    {
        private IUserProvider userProvider;

        public ValidationService(IUserProvider _userProvider)
        {
            userProvider = _userProvider;
        }
        public bool IsValidUser(string login, string password)
        {
            var user = userProvider.GetUserByLogin(login);

            if (user != null)
            {
                if (user.Login == login && user.Password == password)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
