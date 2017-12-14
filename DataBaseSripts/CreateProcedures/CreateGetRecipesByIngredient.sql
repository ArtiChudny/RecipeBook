CREATE PROCEDURE GetRecipesByIngredient
@ingredient nvarchar(50)
AS
SELECT Recipes.RecipeId,Recipes.RecipeName,Recipes.CategoryId,Recipes.PhotoUrl,Recipes.UserId
FROM Recipes INNER JOIN
RecipesIngredients ON
Recipes.RecipeId=RecipesIngredients.RecipeId
INNER JOIN Ingredients ON
RecipesIngredients.IngredientId = Ingredients.IngredientId
WHERE Ingredients.IngredientId = (Select IngredientId FROM Ingredients WHERE IngredientName = @ingredient)
