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
        IEnumerable<IngredientDto> GetIngredients();

        [OperationContract]
        RecipeDetailsDto GetDedails(int id);

        [OperationContract]
        IEnumerable<RecipeIngredientDto> GetRecipeIngredients(int id);

        [OperationContract]
        IEnumerable<RecipeDto> GetRecipesByIngredient(string ingredientName);

        [OperationContract]
        IEnumerable<RecipeDto> GetRecipesByName(string recipeName);

        [OperationContract]
        IEnumerable<RecipeDto> GetRecipesByCategory(string categoryName);

        [OperationContract]
        void AddIngredient(IngredientDto ingredient);
        [OperationContract]
        void DeleteIngredient(int ingredientId);
        [OperationContract]
        void UpdateIngredient(IngredientDto ingredient);

        [OperationContract]
        void AddRecipeIngredient(RecipeIngredientDto recipeIngredient);
        [OperationContract]
        void DeleteRecipeIngredient(int recipeId, int ingredientId);
        [OperationContract]
        void DeleteRecipeIngredients(int recipeId);

        [OperationContract]
        int AddRecipe(RecipeDto recipe);
        [OperationContract]
        void DeleteRecipe(int recipeId);
        [OperationContract]
        void UpdateRecipe(RecipeDto recipe);

        [OperationContract]
        void AddRecipeDetails(RecipeDetailsDto details);
        [OperationContract]
        void UpdateRecipeDetails(RecipeDetailsDto details);

        [OperationContract]
        bool IsServerConnected();

    }
}
