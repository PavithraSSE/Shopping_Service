USE [ShoppingEngine]
GO

/****** Object:  Table [dbo].[Item]    Script Date: 22-08-2020 21:39:58 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Item](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[SubCategoryId] [int] NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Description] [nvarchar](500) NOT NULL,
 CONSTRAINT [PK_Item] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[Item] ADD  CONSTRAINT [DF_Item_Name]  DEFAULT ('') FOR [Name]
GO

ALTER TABLE [dbo].[Item] ADD  CONSTRAINT [DF_Item_Description]  DEFAULT ('') FOR [Description]
GO

ALTER TABLE [dbo].[Item]  WITH CHECK ADD  CONSTRAINT [FK_Item_SubCategory] FOREIGN KEY([SubCategoryId])
REFERENCES [dbo].[SubCategory] ([Id])
GO

ALTER TABLE [dbo].[Item] CHECK CONSTRAINT [FK_Item_SubCategory]
GO


