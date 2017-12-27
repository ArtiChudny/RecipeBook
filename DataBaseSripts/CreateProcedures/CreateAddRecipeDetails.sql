USE RecipeBook
GO
CREATE PROCEDURE AddRecipeDetails
@recipeId int, @description nvarchar(50), @time nvarchar(50), @temperature nvarchar(50), @steps nvarchar(100)
AS
INSERT INTO RecipeDetails (RecipeId, RecipeDescription, CookingTime, CookingTemperature, Steps)
VALUES
(@recipeId, @description, @time, @temperature, @steps)