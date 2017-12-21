CREATE PROCEDURE GetRecipesByCategory
@category nvarchar(50)
AS
Select *
FROM Recipes
INNER JOIN Categories
ON Recipes.CategoryId=Categories.CategoryId
WHERE CategoryName = @category
