using StructureMap.Configuration.DSL;
using RecipeBook.Business.Providers;

namespace RecipeBook.Business.Container
{
    public class BusinessRegistry : Registry
    {
        public BusinessRegistry()
        {
            For<IRecipeProvider>().Use<RecipeProvider>();
        }
    }
}
