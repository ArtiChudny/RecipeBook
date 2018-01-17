CREATE PROCEDURE UpdateRecipeDetails
@recipeId int, @description nvarchar(100), @time nvarchar(50), @temperature nvarchar(50), @steps nvarchar(1000)
AS
UPDATE RecipeDetails
SET
RecipeDescription = @description,
CookingTime = @time,
CookingTemperature = @temperature,
Steps = @steps
WHERE RecipeId = @recipeId