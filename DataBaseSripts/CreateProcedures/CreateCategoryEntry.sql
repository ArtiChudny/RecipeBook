CREATE PROCEDURE CreateCategoryEntry
@CategoryName nvarchar(50)
AS
INSERT INTO Categories (CategoryName)
VALUES (@CategoryName)