CREATE PROCEDURE CreateIngredientEntry
@IngredientName nvarchar(50)
AS
INSERT INTO Ingredients(IngredientName)
VALUES (@IngredientName)