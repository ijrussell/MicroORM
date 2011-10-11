CREATE PROCEDURE SalesSummary
	@Year INT
AS
BEGIN
	WITH Summary
	AS 
	(
		SELECT CustomerId,
			COUNT(InvoiceId) As NumberOfOrders,
			SUM(Total) AS TotalSales
		FROM Invoice
		WHERE DATEPART(year, InvoiceDate) = @Year
		GROUP BY CustomerId
	)
	SELECT c.CustomerId,
		c.FirstName,
		c.LastName,
		c.Company,
		s.NumberOfOrders,
		s.TotalSales
	FROM Customer c
		LEFT JOIN Summary s	
			ON s.CustomerId = c.CustomerId
	ORDER BY TotalSales DESC
END
GO