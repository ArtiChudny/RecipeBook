USE [RecipeBook]

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RecipesIngredients](
	[RecipeId] [int] NOT NULL,
	[IngredientId] [int] NOT NULL,
	[Weight] [nvarchar](50) NOT NULL
) ON [PRIMARY]
