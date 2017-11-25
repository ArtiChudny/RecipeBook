using StructureMap.Configuration.DSL;
using RecipeBook.Data.Repositories;

namespace RecipeBook.Data.Container
{
    public class DataRegistry : Registry
    {
        public DataRegistry()
        {
            For<IDataProvider>().Use<Repositories.Data>();
        }

    }
}
