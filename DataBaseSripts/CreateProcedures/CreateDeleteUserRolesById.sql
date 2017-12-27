CREATE PROCEDURE DeleteUserRolesById
@userId int
AS
DELETE FROM UsersRoles
WHERE UsersRoles.UserId=@userId
