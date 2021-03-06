USE [RecipeBook]
GO
/****** Object:  Table [dbo].[RecipeDetails]    Script Date: 15.12.2017 2:02:15 ******/
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
ALTER TABLE [dbo].[RecipeDetails]  WITH CHECK ADD  CONSTRAINT [FK_RecipeDetails_Recipes] FOREIGN KEY([RecipeId])
REFERENCES [dbo].[Recipes] ([RecipeId])
GO
ALTER TABLE [dbo].[RecipeDetails] CHECK CONSTRAINT [FK_RecipeDetails_Recipes]
GO
