CREATE PROCEDURE AddUserRole
@userId int, @roleId int
AS
INSERT INTO UsersRoles (UserId,RoleId)
VALUES (@userId, @roleId)