USE RecipeBook
GO
CREATE PROCEDURE AddRecipeIngredient
@ingredientId int, @recipeId int, @weight nvarchar(50)
AS
INSERT INTO RecipesIngredients (RecipeId, IngredientId,Weight)
VALUES (@recipeId,@ingredientId, @weight)