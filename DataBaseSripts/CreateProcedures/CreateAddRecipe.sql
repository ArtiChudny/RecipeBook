CREATE PROCEDURE AddRecipe
@recipeName nvarchar(50), @categoryId int, @photoUrl nvarchar(100)
AS
INSERT INTO Recipes (RecipeName, CategoryId, PhotoUrl)
VALUES (@recipeName, @categoryId, @photoUrl)
SELECT @@IDENTITY