USE [master]
GO

/* For security reasons the login is created disabled and with a random password. */
/****** Object:  Login [User]    Script Date: 12.12.2017 16:56:24 ******/
CREATE LOGIN [User] WITH PASSWORD='recipebook', DEFAULT_DATABASE=[RecipeBook], DEFAULT_LANGUAGE=[русский], CHECK_EXPIRATION=OFF, CHECK_POLICY=OFF
GO

CREATE USER [User] FOR LOGIN [User] WITH DEFAULT_SCHEMA=[dbo]
GO
ALTER ROLE [db_owner] ADD MEMBER [User]
GO

