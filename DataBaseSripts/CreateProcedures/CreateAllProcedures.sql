USE [RecipeBook]
GO

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

GO

CREATE PROCEDURE GetRecipeIngredients
@Id int
AS
Select RecipesIngredients.RecipeId, Ingredients.IngredientName, RecipesIngredients.Weight
FROM RecipesIngredients
INNER JOIN Ingredients ON
RecipesIngredients.IngredientId=Ingredients.IngredientId
WHERE RecipeId=@Id

GO

CREATE PROCEDURE GetRoles
AS
Select *
FROM Roles

GO

CREATE PROCEDURE GetUserByLogin
@UserLogin nvarchar(50)
AS
SELECT * FROM
Users
WHERE Login=@UserLogin

GO

CREATE PROCEDURE GetUserRolesByLogin
@login nvarchar(50)
AS
SELECT Roles.RoleId,Roles.RoleName
FROM UsersRoles
INNER JOIN Roles ON
Roles.RoleId=UsersRoles.RoleId
WHERE UserId=(SELECT UserId FROM Users WHERE Login=@login)

GO

CREATE PROCEDURE GetRecipesByIngredient
@ingredient nvarchar(50)
AS
SELECT Recipes.RecipeId,Recipes.RecipeName,Recipes.CategoryId,Recipes.PhotoUrl,Recipes.UserId
FROM Recipes INNER JOIN
RecipesIngredients ON
Recipes.RecipeId=RecipesIngredients.RecipeId
INNER JOIN Ingredients ON
RecipesIngredients.IngredientId = Ingredients.IngredientId
WHERE Ingredients.IngredientId = (Select IngredientId FROM Ingredients WHERE IngredientName = @ingredient)


