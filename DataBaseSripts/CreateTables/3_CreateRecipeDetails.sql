USE [RecipeBook]
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