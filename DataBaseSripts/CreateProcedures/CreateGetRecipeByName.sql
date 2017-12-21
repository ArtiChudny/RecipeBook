CREATE PROCEDURE GetRecipeByName
@name nvarchar(50)
AS
Select *
FROM Recipes
WHERE RecipeName = @name
