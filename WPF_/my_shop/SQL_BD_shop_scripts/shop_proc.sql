
----------процедура--------------

--select OutputOrders.Id from OutputOrders where OutputOrders.Status=2


--SELECT CONVERT(DATETIME, FLOOR(CONVERT(FLOAT, GETDATE()))) 

--	--declare @dateTime DATETIME
--	--set @dateTime = CONVERT(DATETIME, CONVERT(VARCHAR, GETDATE(), 112))

--create proc tes
--	@dateTime DATETIME
--as
--begin
--	set @dateTime = CONVERT(DATETIME, CONVERT(VARCHAR, GETDATE(), 112))
----	select * from OutputOrders
----	where OutputOrders.CreationTime <   @dateTime
--end

--tes

--drop proc tes

--	Update OutputOrders SET OutputOrders.Status = 1
--		where
--		OutputOrders.Status = 2 
--		select * from OutputOrders 