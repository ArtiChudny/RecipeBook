using System.ServiceModel;
using RecipeBook.Service.Data.ModelsDto;
using System.Collections.Generic;

namespace RecipeBook.Service.Data.Contracts
{
    [ServiceContract]
    public interface IRecipeService
    {
        [OperationContract]
        IEnumerable<RecipeDto> GetRecipes();

        [OperationContract]
        IEnumerable<CategoryDto> GetCategories();

        [OperationContract]
        RecipeDetailsDto GetDedails(int id);
    }
}
