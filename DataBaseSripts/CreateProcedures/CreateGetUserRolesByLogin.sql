CREATE PROCEDURE GetUserRolesByLogin
@login nvarchar(50)
AS
SELECT Roles.RoleId,Roles.RoleName
FROM UsersRoles
INNER JOIN Roles ON
Roles.RoleId=UsersRoles.RoleId
WHERE UserId=(SELECT UserId FROM Users WHERE Login=@login)
