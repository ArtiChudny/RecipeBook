USE [RecipeBook]
GO
/****** Object:  Table [dbo].[Recipes]    Script Date: 15.12.2017 2:02:15 ******/
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
