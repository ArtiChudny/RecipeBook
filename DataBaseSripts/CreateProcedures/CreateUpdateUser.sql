CREATE PROCEDURE UpdateUser
@userId int, @login nvarchar(50), @password nvarchar(50), @email nvarchar(50)
AS
UPDATE Users
SET
Login = @login,
Password = @password,
Email = @email
WHERE Users.UserId = @userId