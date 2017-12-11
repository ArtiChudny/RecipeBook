CREATE PROCEDURE GetRecipeIngredients
@Id int
AS
Select RecipesIngredients.RecipeId, Ingredients.IngredientName, RecipesIngredients.Weight
FROM RecipesIngredients
INNER JOIN Ingredients ON
RecipesIngredients.IngredientId=Ingredients.IngredientId
WHERE RecipeId=@Id