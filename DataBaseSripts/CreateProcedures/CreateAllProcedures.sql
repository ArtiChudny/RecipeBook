CREATE PROCEDURE GetCategories
AS
SELECT * FROM Categories

GO

CREATE PROCEDURE GetDetails
@RecipeId int
AS
BEGIN
SELECT * FROM
RecipeDetails
WHERE RecipeId=@RecipeId
END

GO

CREATE PROCEDURE GetIngredients
AS
SELECT * FROM Ingredients

GO

CREATE PROCEDURE GetRecipeIngredients
@RecipeId int
AS
BEGIN
SELECT * FROM RecipesIngredients
WHERE RecipeId=@RecipeId
END

GO

CREATE PROCEDURE GetRecipes
AS
SELECT * FROM Recipes

