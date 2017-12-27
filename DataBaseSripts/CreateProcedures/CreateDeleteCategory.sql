CREATE PROCEDURE DeleteCategory
@categoryId int
AS
DELETE FROM Categories
WHERE CategoryId = @categoryId