CREATE PROCEDURE DeleteRecipeIngredient
@recipeId int, @ingredientId int
AS
DELETE FROM RecipesIngredients
WHERE RecipeId = @recipeId AND IngredientId = @ingredientId