CREATE PROCEDURE DeleteRecipe
@recipeId int
AS
DELETE FROM Recipes
WHERE RecipeId  = @recipeId