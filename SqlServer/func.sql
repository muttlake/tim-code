

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
GO
-- Want to Add Address if it does not exist, if it exists, change Addressline2
alter procedure Person.sp_AddAddress(@street1 varchar(max), @street2 varchar(max), @city varchar(max))
as
begin
	declare @id int;

	select @id = AddressID -- Grabs last AddressID that fits in there if there is more than one matching AddressLine1
	FROM Person.Address    -- We want to make sure SELECT Never fails
	WHERE AddressLine1 = @street1;

	begin transaction -- makes sure everything works, both inserts in each if block, now our transaction is Acid
		begin try -- you usually don't see a transaction without a try
			if (@id is null) -- @ means local variable
			begin
				-- RAISERROR('There is no address there', 16, 50000) -- way to throw errors, we take 50000 up in errors
				INSERT INTO Person.Address(AddressLine1, AddressLine2, City, ModifiedDate, StateProvinceID, PostalCode, rowguid)
				VALUES(@street1, @street2, @city, GETDATE(), 79, 78787, 'E5946C78-4BCC-477F-9FA1-CC09EE16A89f') -- sometimes you have to do more than one inser to keep db consistent
				-- inser into Person.BusinessEntityAddress  -- if first insert does not work, second insert would still happen, not good for consistency
				commit transaction -- commit ends begin transaction
			end
			else
			begin -- begin and end act like brackets
				-- THROW 50001, 'The record does not exist.', 16;  
				UPDATE Person.Address -- Both inserts need to work
				SET AddressLine2 = @street2, City = @city
				WHERE AddressID = @id
				-- UPDATE Person.BusinessEntityAddress
				commit transaction
			end
			end try
		begin catch -- At this point it doesn't matter the error
		    -- THROW 51000, 'The record does not exist.', 1
			print error_message();
			print error_severity();
			print error_number(); 
			print error_state();
			print @@trancount; -- @@ means global variable
			print @@rowcount;
			rollback transaction
		end catch
end
go


execute Person.sp_AddAddress '332 Blinker St', 'GRANT', 'Orlando';
GO

SELECT * From Person.Address where City = 'Orlando';


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



-- List all employees that bought a product


SELECT (FirstName + isNull(MiddleName + ' ', '') + LastName) as Name, PersonType, product.ProductID, product.Name as ProductName, salesheader.SalesOrderID, salesdetail.SalesOrderID, salesDetail.SalesOrderDetailID
FROM Person.Person as person
INNER JOIN
(
	Select SalesOrderID, CustomerID
	From Sales.SalesOrderHeader
) as salesheader ON person.BusinessEntityID = salesheader.CustomerID
LEFT JOIN
(
	Select SalesOrderID, SalesOrderDetailID, ProductID
	FROM Sales.SalesOrderDetail
) as salesdetail ON salesheader.SalesOrderID = salesdetail.SalesOrderID
LEFT JOIN
(
	Select ProductID, Name
	FROM Production.Product
) as product ON product.ProductID = salesdetail.ProductID
ORDER BY PersonType, Name;

SELECT * From Person.Person;
GO
-- More Stored Procedures

-- Want to Add Address if it does not exist, if it exists, change Addressline2
alter procedure Person.sp_UpdateMiddleName(@firstName varchar(max), @lastName varchar(max), @newMiddleName varchar(max))
as
begin
	declare @id int;
	declare @currentMiddleName varchar(max)

	select @id = BusinessEntityID, @currentMiddleName = MiddleName 
	FROM Person.Person    -- We want to make sure SELECT Never fails
	WHERE FirstName = @firstName AND LastName = @lastName

	begin transaction -- makes sure everything works, both inserts in each if block, now our transaction is Acid
		begin try -- you usually don't see a transaction without a try
			if (@id is null) -- @ means local variable
			begin
				RAISERROR('There is no such person to add a middle name to.', 16, 50000) -- way to throw errors, we take 50000 up in errors
				commit transaction
			end
			else if (@currentMiddleName is not null)
			begin
				RAISERROR('There is already a middle name for this person.', 16, 50000) -- way to throw errors, we take 50000 up in errors
			end
			else
			begin -- begin and end act like brackets
				UPDATE Person.Person
				SET MiddleName = @newMiddleName
				WHERE BusinessEntityID = @id
				commit transaction
			end
			end try
		begin catch -- At this point it doesn't matter the error
			print error_message();
			print error_severity();
			print error_number(); 
			print error_state();
			print @@trancount; -- @@ means global variable
			print @@rowcount;
			rollback transaction
		end catch
end
go

SELECT * FROM Person.Person where LastName = 'Rodriguez';
GO

execute Person.sp_UpdateMiddleName 'Alexandrs', 'Rodriguez', 'Jiffy';