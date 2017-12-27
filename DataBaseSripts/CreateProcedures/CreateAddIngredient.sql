CREATE PROCEDURE AddIngredient
@ingredientName nvarchar(50)
AS
INSERT INTO Ingredients(IngredientName)
VALUES (@IngredientName)