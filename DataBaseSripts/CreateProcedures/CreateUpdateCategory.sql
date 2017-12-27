CREATE PROCEDURE UpdateCategory
@categoryId int, @CategoryName nvarchar(50)
AS
UPDATE Categories SET
CategoryName = @CategoryName
WHERE CategoryId = @categoryId