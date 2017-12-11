CREATE PROCEDURE GetUserByLogin
@UserLogin nvarchar(50)
AS
SELECT * FROM
Users
WHERE Login=@UserLogin