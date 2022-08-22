USE [CoffeeStore]
GO

/****** Object:  StoredProcedure [dbo].[sp_most_popular products]    Script Date: 22.08.2022 16:46:26 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


-------------------------------------------------------------------------------------------------------------------------------
-- Хранимая прощедура списка купленных товаров с группировкой по продукту и сортировкой от наиболее часто покупаемых
-------------------------------------------------------------------------------------------------------------------------------

ALTER PROCEDURE [dbo].[sp_most_popular products]
	@dateFrom DATETIME2(7),
	@dateTo DATETIME2(7),
	@productTypeId UNIQUEIDENTIFIER
AS
BEGIN
	SET NOCOUNT ON;

	select ProductId, ProductName, sum(Amount) as Amount
	from (
  select ProductId, p.Name as ProductName, Amount, ModifiedDate, ProductTypeId
  from [dbo].[OrderDetails] od
  left join [dbo].[Orders]  o on od.OrderId=o.Id
  left join [dbo].[Products] p on od.ProductId=p.Id
  left join [dbo].[ProductTypes] pt on p.ProductTypeId=pt.Id
  where ModifiedDate between @dateFrom and @dateTo and ProductTypeId=@productTypeId) t
  group by ProductId, ProductName
  order by Amount desc

END
GO


