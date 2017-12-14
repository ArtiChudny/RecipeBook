using StructureMap.Configuration.DSL;
using RecipeBook.Business.Providers;
using RecipeBook.Business.AuthentificationService;

namespace RecipeBook.Business.Container
{
    public class BusinessRegistry : Registry
    {
        public BusinessRegistry()
        {
            For<ICategoryProvider>().Use<CategoryProvider>();
            For<IRecipeProvider>().Use<RecipeProvider>();
            For<IUserProvider>().Use<UserProvider>();
            For<ILoginService>().Use<LoginService>();
            For<IValidationService>().Use<IValidationService>();
        }
    }
}
