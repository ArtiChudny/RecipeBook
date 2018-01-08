CREATE PROCEDURE DeleteRecipeIngredients
@recipeId int
AS
DELETE FROM RecipesIngredients
WHERE RecipeId = @RecipeId