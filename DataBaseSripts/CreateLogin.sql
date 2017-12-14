USE [master]
GO

/* For security reasons the login is created disabled and with a random password. */
/****** Object:  Login [User]    Script Date: 12.12.2017 16:56:24 ******/
CREATE LOGIN [User] WITH PASSWORD=N'I9XLmD5/3NJLJZli2+n0qrL0XcneGgfyxWEK6tgw1II=', DEFAULT_DATABASE=[RecipeBook], DEFAULT_LANGUAGE=[русский], CHECK_EXPIRATION=OFF, CHECK_POLICY=OFF
GO

ALTER LOGIN [User] DISABLE
GO


