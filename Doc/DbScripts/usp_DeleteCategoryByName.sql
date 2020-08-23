USE [ShoppingEngine]
GO
/****** Object:  StoredProcedure [dbo].[usp_GetItemsByName]    Script Date: 22-08-2020 17:08:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_DeleteCategoryByName]
@CategoryName varchar(50)
AS
BEGIN
	SET NOCOUNT ON;
	SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED;
		Delete Item where SubCategoryId IN (Select SubCategory.Id from Category Inner join SubCategory on Category.Id=SubCategory.CategoryId
Where Category.Name=@CategoryName)
Delete SubCategory where CategoryId IN (Select Id from Category where Category.Name=@CategoryName)
Delete Category where Category.Name=@CategoryName

END