CREATE PROCEDURE UpdateRecipe
@recipeId int, @categoryId int, @recipeName nvarchar(50), @photoUrl nvarchar(100)
AS
UPDATE Recipes 
SET
CategoryId = @categoryId,
RecipeName  = @recipeName,
PhotoUrl = @photoUrl
WHERE RecipeId  = @recipeId
