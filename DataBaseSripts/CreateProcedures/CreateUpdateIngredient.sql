CREATE PROCEDURE UpdateIngredient
@ingredientId int, @ingredientName nvarchar(50)
AS
UPDATE Ingredients
SET
IngredientName = @ingredientName
WHERE IngredientId = @ingredientId