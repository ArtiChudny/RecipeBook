USE [RecipeBook]
GO
/****** Object:  Table [dbo].[Categories]    Script Date: 30.11.2017 1:08:53 ******/
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
/****** Object:  Table [dbo].[Ingredients]    Script Date: 30.11.2017 1:08:54 ******/
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
/****** Object:  Table [dbo].[RecipeDetails]    Script Date: 30.11.2017 1:08:54 ******/
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
/****** Object:  Table [dbo].[Recipes]    Script Date: 30.11.2017 1:08:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Recipes](
	[RecipeId] [int] IDENTITY(1,1) NOT NULL,
	[RecipeName] [nvarchar](50) NOT NULL,
	[CategoryId] [int] NOT NULL,
	[PhotoUrl] [nvarchar](50) NULL,
 CONSTRAINT [PK_Recipes] PRIMARY KEY CLUSTERED 
(
	[RecipeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[RecipesIngedients]    Script Date: 30.11.2017 1:08:54 ******/
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