using StructureMap.Configuration.DSL;
using RecipeBook.Data.Repositories;
using RecipeBook.Data.Clients;

namespace RecipeBook.Data.Container
{
    public class DataRegistry : Registry
    {
        public DataRegistry()
        {
            For<IDataProvider>().Use<DataProvider>();

            For<IRecipeClient>().Use<RecipeClient>();
        }

    }
}
