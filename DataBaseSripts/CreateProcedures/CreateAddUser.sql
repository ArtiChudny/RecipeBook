CREATE PROCEDURE AddUser
@login nvarchar(50), @email nvarchar(50) , @password nvarchar(50)
AS
INSERT INTO Users (Login,Password,Email)
VALUES (@login,@password,@email)
SELECT @@IDENTITY