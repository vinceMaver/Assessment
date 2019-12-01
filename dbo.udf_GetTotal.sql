CREATE FUNCTION dbo.udf_GetTotal
(
	@OrderId INT
)

--------------------------------------------------------------------------------------------------------------------
-- Summary: Calculates the total due for an order
-- Returns: Null if orderId does not exist
--------------------------------------------------------------------------------------------------------------------

RETURNS NUMERIC(10,2)

AS

BEGIN
	
	DECLARE @TotalDue NUMERIC(10,2)

	SELECT @TotalDue = SUM((OD.UnitPrice * OD.Quantity) - (OD.Quantity * OD.Discount)) + O.Freight
	FROM dbo.Orders O 
	JOIN dbo.[Order Details] OD ON OD.OrderID = O.OrderID
	WHERE O.OrderID = @OrderId
	GROUP BY O.Freight

	RETURN @TotalDue

END
