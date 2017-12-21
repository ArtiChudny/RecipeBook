USE [master]
GO
/****** Object:  Database [RecipeBook]    Script Date: 15.12.2017 2:07:22 ******/
CREATE DATABASE [RecipeBook]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'RecipeBook', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\RecipeBook.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'RecipeBook_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\RecipeBook_log.ldf' , SIZE = 2048KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [RecipeBook] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [RecipeBook].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [RecipeBook] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [RecipeBook] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [RecipeBook] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [RecipeBook] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [RecipeBook] SET ARITHABORT OFF 
GO
ALTER DATABASE [RecipeBook] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [RecipeBook] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [RecipeBook] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [RecipeBook] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [RecipeBook] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [RecipeBook] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [RecipeBook] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [RecipeBook] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [RecipeBook] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [RecipeBook] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [RecipeBook] SET  DISABLE_BROKER 
GO
ALTER DATABASE [RecipeBook] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [RecipeBook] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [RecipeBook] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [RecipeBook] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [RecipeBook] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [RecipeBook] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [RecipeBook] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [RecipeBook] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [RecipeBook] SET  MULTI_USER 
GO
ALTER DATABASE [RecipeBook] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [RecipeBook] SET DB_CHAINING OFF 
GO
ALTER DATABASE [RecipeBook] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [RecipeBook] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [RecipeBook]
GO
/****** Object:  User [User]    Script Date: 15.12.2017 2:07:22 ******/
CREATE LOGIN [User] WITH PASSWORD='recipebook', DEFAULT_DATABASE=[RecipeBook], DEFAULT_LANGUAGE=[русский], CHECK_EXPIRATION=OFF, CHECK_POLICY=OFF
GO

CREATE USER [User] FOR LOGIN [User] WITH DEFAULT_SCHEMA=[dbo]
GO
ALTER ROLE [db_owner] ADD MEMBER [User]
GO
/****** Object:  StoredProcedure [dbo].[GetCategories]    Script Date: 15.12.2017 2:07:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[CreateCategoryEntry]
@CategoryName nvarchar(50)
AS
INSERT INTO Categories (CategoryName)
VALUES (@CategoryName)
GO
/****** Object:  StoredProcedure [dbo].[CreateIngredientEntry]    Script Date: 21.12.2017 17:11:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CreateIngredientEntry]
@IngredientName nvarchar(50)
AS
INSERT INTO Ingredients(IngredientName)
VALUES (@IngredientName)
GO
/****** Object:  StoredProcedure [dbo].[GetCategories]    Script Date: 21.12.2017 17:11:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetCategories]
AS
SELECT * FROM Categories



GO
/****** Object:  StoredProcedure [dbo].[GetDetails]    Script Date: 21.12.2017 17:11:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetDetails]
@RecipeId int
AS
BEGIN
SELECT * FROM
RecipeDetails
WHERE RecipeId=@RecipeId
END



GO
/****** Object:  StoredProcedure [dbo].[GetIngredients]    Script Date: 21.12.2017 17:11:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetIngredients]
AS
SELECT * FROM Ingredients



GO
/****** Object:  StoredProcedure [dbo].[GetRecipeByName]    Script Date: 21.12.2017 17:11:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetRecipeByName]
@name nvarchar(50)
AS
Select *
FROM Recipes
WHERE RecipeName = @name

GO
/****** Object:  StoredProcedure [dbo].[GetRecipeIngredients]    Script Date: 21.12.2017 17:11:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetRecipeIngredients]
@Id int
AS
Select RecipesIngredients.RecipeId, Ingredients.IngredientName, RecipesIngredients.Weight
FROM RecipesIngredients
INNER JOIN Ingredients ON
RecipesIngredients.IngredientId=Ingredients.IngredientId
WHERE RecipeId=@Id



GO
/****** Object:  StoredProcedure [dbo].[GetRecipes]    Script Date: 21.12.2017 17:11:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetRecipes]
AS
SELECT * FROM Recipes



GO
/****** Object:  StoredProcedure [dbo].[GetRecipesByCategory]    Script Date: 21.12.2017 17:11:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetRecipesByCategory]
@category nvarchar(50)
AS
Select *
FROM Recipes
INNER JOIN Categories
ON Recipes.CategoryId=Categories.CategoryId
WHERE CategoryName = @category

GO
/****** Object:  StoredProcedure [dbo].[GetRecipesByIngredient]    Script Date: 21.12.2017 17:11:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetRecipesByIngredient]
@ingredient nvarchar(50)
AS
SELECT Recipes.RecipeId,Recipes.RecipeName,Recipes.CategoryId,Recipes.PhotoUrl,Recipes.UserId
FROM Recipes INNER JOIN
RecipesIngredients ON
Recipes.RecipeId=RecipesIngredients.RecipeId
INNER JOIN Ingredients ON
RecipesIngredients.IngredientId = Ingredients.IngredientId
WHERE Ingredients.IngredientName = @ingredient
GO
/****** Object:  StoredProcedure [dbo].[GetRoles]    Script Date: 21.12.2017 17:11:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetRoles]
AS
Select *
FROM Roles

GO
/****** Object:  StoredProcedure [dbo].[GetUserByLogin]    Script Date: 21.12.2017 17:11:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetUserByLogin]
@UserLogin nvarchar(50)
AS
SELECT * FROM
Users
WHERE Login=@UserLogin

GO
/****** Object:  StoredProcedure [dbo].[GetUserRolesByLogin]    Script Date: 21.12.2017 17:11:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetUserRolesByLogin]
@login nvarchar(50)
AS
SELECT Roles.RoleId,Roles.RoleName
FROM UsersRoles
INNER JOIN Roles ON
Roles.RoleId=UsersRoles.RoleId
WHERE UserId=(SELECT UserId FROM Users WHERE Login=@login)


GO
/****** Object:  Table [dbo].[Categories]    Script Date: 21.12.2017 17:11:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categories](
	[CategoryId] [int] IDENTITY(1,1) NOT NULL,
	[CategoryName] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Categories] PRIMARY KEY CLUSTERED 
(
	[CategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Ingredients]    Script Date: 21.12.2017 17:11:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ingredients](
	[IngredientId] [int] IDENTITY(1,1) NOT NULL,
	[IngredientName] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Ingredients] PRIMARY KEY CLUSTERED 
(
	[IngredientId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[RecipeDetails]    Script Date: 21.12.2017 17:11:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RecipeDetails](
	[RecipeId] [int] NOT NULL,
	[RecipeDescription] [nvarchar](50) NOT NULL,
	[CookingTime] [nvarchar](50) NOT NULL,
	[CookingTemperature] [nvarchar](50) NULL,
	[Steps] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_RecipeDetails] PRIMARY KEY CLUSTERED 
(
	[RecipeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Recipes]    Script Date: 21.12.2017 17:11:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Recipes](
	[RecipeId] [int] IDENTITY(1,1) NOT NULL,
	[RecipeName] [nvarchar](50) NOT NULL,
	[CategoryId] [int] NOT NULL,
	[PhotoUrl] [nvarchar](50) NULL,
	[UserId] [int] NULL,
 CONSTRAINT [PK_Recipes] PRIMARY KEY CLUSTERED 
(
	[RecipeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[RecipesIngredients]    Script Date: 21.12.2017 17:11:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RecipesIngredients](
	[RecipeId] [int] NOT NULL,
	[IngredientId] [int] NOT NULL,
	[Weight] [nvarchar](50) NOT NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Roles]    Script Date: 21.12.2017 17:11:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Roles](
	[RoleId] [int] IDENTITY(1,1) NOT NULL,
	[RoleName] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Roles] PRIMARY KEY CLUSTERED 
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Users]    Script Date: 21.12.2017 17:11:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[UserId] [int] IDENTITY(1,1) NOT NULL,
	[Login] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](50) NOT NULL,
	[Email] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[UsersRoles]    Script Date: 21.12.2017 17:11:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UsersRoles](
	[UserId] [int] NOT NULL,
	[RoleId] [int] NOT NULL
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[RecipeDetails]  WITH CHECK ADD  CONSTRAINT [FK_RecipeDetails_Recipes] FOREIGN KEY([RecipeId])
REFERENCES [dbo].[Recipes] ([RecipeId])
GO
ALTER TABLE [dbo].[RecipeDetails] CHECK CONSTRAINT [FK_RecipeDetails_Recipes]
GO
ALTER TABLE [dbo].[Recipes]  WITH CHECK ADD  CONSTRAINT [FK_Recipes_Categories] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[Categories] ([CategoryId])
GO
ALTER TABLE [dbo].[Recipes] CHECK CONSTRAINT [FK_Recipes_Categories]
GO
ALTER TABLE [dbo].[Recipes]  WITH CHECK ADD  CONSTRAINT [FK_Recipes_Users] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([UserId])
GO
ALTER TABLE [dbo].[Recipes] CHECK CONSTRAINT [FK_Recipes_Users]
GO
ALTER TABLE [dbo].[RecipesIngredients]  WITH CHECK ADD  CONSTRAINT [FK_RecipesIngredients_Ingredients] FOREIGN KEY([IngredientId])
REFERENCES [dbo].[Ingredients] ([IngredientId])
GO
ALTER TABLE [dbo].[RecipesIngredients] CHECK CONSTRAINT [FK_RecipesIngredients_Ingredients]
GO
ALTER TABLE [dbo].[RecipesIngredients]  WITH CHECK ADD  CONSTRAINT [FK_RecipesIngredients_Recipes] FOREIGN KEY([RecipeId])
REFERENCES [dbo].[Recipes] ([RecipeId])
GO
ALTER TABLE [dbo].[RecipesIngredients] CHECK CONSTRAINT [FK_RecipesIngredients_Recipes]
GO
ALTER TABLE [dbo].[UsersRoles]  WITH CHECK ADD  CONSTRAINT [FK_UsersRoles_Roles] FOREIGN KEY([RoleId])
REFERENCES [dbo].[Roles] ([RoleId])
GO
ALTER TABLE [dbo].[UsersRoles] CHECK CONSTRAINT [FK_UsersRoles_Roles]
GO
ALTER TABLE [dbo].[UsersRoles]  WITH CHECK ADD  CONSTRAINT [FK_UsersRoles_Users] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([UserId])
GO
ALTER TABLE [dbo].[UsersRoles] CHECK CONSTRAINT [FK_UsersRoles_Users]
GO
USE [master]
GO
ALTER DATABASE [RecipeBook] SET  READ_WRITE 
GO


