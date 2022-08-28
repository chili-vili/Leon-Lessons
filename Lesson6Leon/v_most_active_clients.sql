 USE [CoffeeStore]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE VIEW [dbo].[v_most_active_clients]
AS
	select top 10 
	(Name +' '+ Surname) as Client, count(ClientId) as CountofOrders
  from dbo.OrderDetails od
  left join dbo.Orders o on od.OrderId=o.Id
  left join dbo.Clients c on o.ClientId=c.Id
  where OrderStatus='2'
  group by Name, Surname
  order by count(ClientId) desc
GO