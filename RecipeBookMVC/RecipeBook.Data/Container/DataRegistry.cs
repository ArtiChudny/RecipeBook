using StructureMap.Configuration.DSL;
using RecipeBook.Data.Repositories;
using RecipeBook.Data.Clients;
using RecipeBook.Data.Converters;

namespace RecipeBook.Data.Container
{
    public class DataRegistry : Registry
    {
        public DataRegistry()
        {
            For<IDataProvider>().Use<DataProvider>();
            For<IConverter>().Use<Converter>();
            For<IRecipeClient>().Use<RecipeClient>();
            For<ICategoryClient>().Use<CategoryClient>();

        }

    }
}
