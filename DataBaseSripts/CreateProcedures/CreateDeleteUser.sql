CREATE PROCEDURE DeleteUser
@userId int
AS
DELETE FROM Users
WHERE Users.UserId=@userId
