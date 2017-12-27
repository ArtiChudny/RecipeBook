CREATE PROCEDURE DeleteIngredient
@ingredientId int
AS
DELETE FROM Ingredients
WHERE IngredientId = @ingredientId