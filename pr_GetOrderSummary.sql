CREATE PROCEDURE pr_GetOrderSummary
(
	@StartDate DATE,
  	@EndDate DATE,
	@EmployeeID INT,
	@CustomerID NCHAR(10)
)

AS

--------------------------------------------------------------------------------------------------------------------
-- Purpose: Generate an Order Summary for the suppied parameters
--------------------------------------------------------------------------------------------------------------------

BEGIN
	
		SELECT E.TitleOfCourtesy + ' ' + E.FirstName + ' ' + E.LastName AS [EmployeeFullName]
			  ,S.CompanyName		AS [Shipper]
			  ,C.CompanyName		AS [Customer]
			  ,COUNT(distinct O.OrderId)	AS [NumberOfOders]
			  ,O.OrderDate			AS [Date]
			  ,O.Freight			AS [TotalFreightCost]
			  ,COUNT(OD.ProductID)		AS [NumberOfDifferentProducts]
			  ,ROUND((SUM((OD.UnitPrice * OD.Quantity) - (OD.Quantity * OD.Discount)) + O.Freight),2) [TotalOrderValue] -- dbo.udf_GetTotal(O.OrderID) function can be used instead, but inline functions are not efficient.
		FROM dbo.Employees E
			 JOIN dbo.Orders O ON E.EmployeeID = O.EmployeeID
			 JOIN dbo.Customers C ON C.CustomerID = O.CustomerID
			 JOIN dbo.Shippers S ON S.ShipperID = O.ShipVia
			 JOIN dbo.[Order Details] OD ON OD.OrderID = O.OrderID
		WHERE O.OrderDate between @StartDate AND @EndDate
			  AND E.EmployeeID = CASE WHEN @EmployeeID IS NULL THEN E.EmployeeID ELSE @EmployeeID END
			  AND C.CustomerID = CASE WHEN @CustomerID IS NULL ThEN C.CustomerID ELSE @CustomerID END
		GROUP BY O.OrderDate, E.TitleOfCourtesy, E.FirstName, E.LastName, S.CompanyName, C.CompanyName,O.Freight
		
END
