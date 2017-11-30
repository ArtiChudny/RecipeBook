using System.ServiceModel;
using RecipeBook.Service.Data.ModelsDto;
using System.Collections.Generic;

namespace RecipeBook.Service.Data.Contracts.CategoryContract
{
    [ServiceContract]
    public interface ICategoryService
    {
        [OperationContract]
        IEnumerable<CategoryDto> GetCategories();
    }
}
