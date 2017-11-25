using StructureMap.Configuration.DSL;
using RecipeBook.Business.Container;
using RecipeBook.Data.Container;

namespace RecipeBook.Dependencies.Registries
{
    public class CommonRegistry : Registry
    {
        public CommonRegistry()
        {
            Scan(scan => {
                scan.Assembly(typeof(DataRegistry).Assembly);
                scan.Assembly(typeof(BusinessRegistry).Assembly);
                scan.WithDefaultConventions();
            });
        }
    }
}
