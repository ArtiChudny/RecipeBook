CREATE PROCEDURE GetRecipeIngredients
@RecipeId int
AS
SELECT * FROM RecipesIngredients
WHERE RecipeId=@RecipeId
