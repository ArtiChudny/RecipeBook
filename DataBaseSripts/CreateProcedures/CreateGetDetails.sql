CREATE PROCEDURE GetDetails
@RecipeId int
AS
SELECT * FROM
RecipeDetails
WHERE RecipeId=@RecipeId