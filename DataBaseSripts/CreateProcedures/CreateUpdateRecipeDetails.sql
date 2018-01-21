CREATE PROCEDURE UpdateRecipeDetails
@recipeId int, @description nvarchar(50), @time nvarchar(50), @temperature nvarchar(50), @steps nvarchar(100)
AS
UPDATE RecipeDetails
SET
RecipeDescription = @description,
CookingTime = @time,
CookingTemperature = @temperature,
Steps = @steps
WHERE RecipeId = @recipeId