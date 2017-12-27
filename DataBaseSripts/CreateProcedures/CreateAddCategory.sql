USE RecipeBook
GO
CREATE PROCEDURE AddCategory
@categoryName nvarchar(50)
AS
INSERT INTO Categories (CategoryName)
VALUES (@CategoryName)