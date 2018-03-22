

USE adventureworksdb;
GO

-- Create a View, now view is part of the Database
-- VIEWS are fully in database
CREATE VIEW Person.vw_FullName with SCHEMABINDING -- SCHEMABINDING: COlumns from actual Tables cannot change
AS                                                -- e.g. You Cannot Delete column MiddleName
SELECT FirstName, MiddleName, Lastname
FROM Person.Person;
GO

SELECT *
FROM Person.vw_FullName;
GO

-- Tabular functions and scalar functions

-- This is a tabular function
-- This tabular function
CREATE FUNCTION Person.fn_FullName(@name varchar(max))
RETURNS TABLE
AS
	RETURN
	SELECT FirstName, MiddleName, Lastname
	FROM Person.Person
	WHERE FirstName = @name or LastName = @name;
GO

SELECT *
FROM Person.fn_FullName('fred');
GO

-- We also have scalar function
CREATE FUNCTION Person.fn_PrintFullName(@first varchar(max), @middle varchar(max), @last varchar(max))
RETURNS varchar(max)
AS
BEGIN
	RETURN @first + ' ' + coalesce(@middle + ' ', '') + @last
END
GO

-- Now have everybody's full name with a function
SELECT Person.fn_PrintFullName(FirstName, MiddleName, LastName) as Name
FROM Person.Person;
GO

-- Stored Procedures, can take parameters or no parameters
-- Procedure is like a true method
create procedure Person.sp_UpdateName(@id int, @name varchar(max))
as
begin
	update Person.Person
	set FirstName = @name
	where BusinessEntityID = @id
end
go

SELECT * from Person.Person
WHERE BusinessEntityID = 1;
GO

execute Person.sp_UpdateName 1, 'Billingston';  -- Execute does not need parentheses

-- Give a report of all products not sold in 2015: Got 504 rows
SELECT product.ProductID, product.Name -- 266 rows for 2013, 324 rows for 2014, 504 rows for 2015
FROM Production.product as product
Where product.ProductID not in
(
	SELECT product.ProductID
	FROM Production.Product as product
	INNER JOIN
	(
		SELECT *
		FROM Sales.SalesOrderDetail
	) as salesdetail ON product.ProductID = salesdetail.ProductID
	INNER JOIN
	(
		SELECT OrderDate, SalesOrderID
		FROM Sales.SalesOrderHeader
		WHERE year(OrderDate) = 2013
	) as salesheader ON salesdetail.SalesOrderID = salesheader.SalesOrderID
);


SELECT DISTINCT product.ProductID, product.Name -- No Products Sold in 2015, there are 504 total products
FROM Production.product as product;



SELECT DISTINCT product.ProductID, product.Name -- 238  rows for 2013, 180 rows in 2014, 0 rows in 2015
FROM Production.Product as product
INNER JOIN
(
	SELECT *
	FROM Sales.SalesOrderDetail
) as salesdetail ON product.ProductID = salesdetail.ProductID
INNER JOIN
(
	SELECT OrderDate, SalesOrderID
	FROM Sales.SalesOrderHeader
	WHERE year(OrderDate) = 2015
) as salesheader ON salesdetail.SalesOrderID = salesheader.SalesOrderID;


SELECT 180 + 324;

-- You can also do this with except
SELECT product.ProductID, product.Name -- 266 rows for 2013, 324 rows for 2014, 504 rows for 2015
FROM Production.product as product

except 


SELECT product.ProductID, product.Name
FROM Production.Product as product
INNER JOIN
(
	SELECT *
	FROM Sales.SalesOrderDetail
) as salesdetail ON product.ProductID = salesdetail.ProductID
INNER JOIN
(
	SELECT OrderDate, SalesOrderID
	FROM Sales.SalesOrderHeader
	WHERE year(OrderDate) = 2013
) as salesheader ON salesdetail.SalesOrderID = salesheader.SalesOrderID;



