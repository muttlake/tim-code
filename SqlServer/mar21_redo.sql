Use adventureworksdb;
GO

-- the 3 most popular first names, Trap because it is top 3 and ties to 3rd
SELECT Top 4 Count(FirstName), FirstName
From Person.Person as pp
Group By FirstName
Order By Count(FirstName) Desc;
-- Must do top 4 because 3rd place has ties


-- the 3 least popular last names
SELECT Count(LastName), LastName
From Person.Person as pp
Group By LastName
Order By Count(LastName) Asc;
-- The answer is all the names that tied for first place

-- INSERT
SELECT * FROM Person.Address;

-- Check what cannot be null, Fred called this Normal Insert
INSERT INTO Person.Address(AddressLine1, City, StateProvinceID, PostalCode, rowguid)
VALUES('2000 Rockefeller Center', 'New Yorkers', 79, 78787, 'E5946C78-4BCC-477F-9FA1-CC09DE16A881');

SELECT * From Person.Address WHERE City = 'New Yorkers';

-- UPDATE
SELECT * FROM Person.Address WHERE City = 'Seattle';


-- Normal Update
UPDATE Person.Address
SET AddressLine2 = '# 44'
WHERE City = 'Seattle' and AddressLine2 is NULL;

-- Enhanced Update
UPDATE pa
Set AddressLine2 = '# 99'
FROM Person.Address as pa
WHERE City = 'Seattle' and AddressLine2 = '# 44';


-- DELETE

INSERT INTO Person.Address(AddressLine1, City, StateProvinceID, PostalCode, rowguid)
VALUES('2000 Rockefeller Center', 'New Workington', 79, 78787, 'E5946C78-4BCC-477F-9FA1-CC09DE16A882');

SELECT * FROM PERSON.Address WHERE City = 'New Workington'; -- 1 row result

-- Normal Delete
DELETE FROM Person.Address
WHERE City = 'New Workington';

SELECT * FROM PERSON.Address WHERE City = 'New Workington'; -- 0 row result

-- Enhanced Delete
INSERT INTO Person.Address(AddressLine1, City, StateProvinceID, PostalCode, rowguid)
VALUES('2000 Rockefeller Center', 'New Workington', 79, 78787, 'E5946C78-4BCC-477F-9FA1-CC09DE16A882');

SELECT * FROM PERSON.Address WHERE City = 'New Workington'; -- 1 row result

Delete pa
From Person.Address as pa
WHERE City = 'New Workington';

SELECT * FROM PERSON.Address WHERE City = 'New Workington'; -- 0 row result


-- JOIN

-- Try to Join: Person Name and Address, Get all People Regardless of if they have an address

SELECT * FROM sys.tables; -- Shows all Tables

SELECT * FROM Person.Person; -- 19972 address
SELECT * FROM Person.BusinessEntityAddress;
SELECT * FROM Person.Address;

Select FirstName, MiddleName, LastName, address.AddressLine1, City, StateProvinceID, PostalCode -- 19996 rows
FROM Person.Person as person
LEFT JOIN
(
	Select *
	FROM Person.BusinessEntityAddress
) as pba on person.BusinessEntityID = pba.BusinessEntityID
LEFT JOIN
( -- subquery
	Select *
	FROM Person.Address
) as address on pba.AddressID = address.AddressID;


-- Find all First Names that are also Last Names
Select FirstName
From Person.Person

intersect

Select LastName
From Person.Person; -- This gives 64 rows
-- Intersect gives the results in common between two queries

Select Distinct FirstName  -- This gives 1018 rows
From Person.Person;

Select Distinct LastName  -- This give 1206 rows
From Person.Person;

-- The union should be 1018 + 1206 - 64 rows
Select 1018 + 1206 - 64; -- 2160

Select FirstName -- TRUE it is 2160 rows
From Person.Person

UNION

Select LastName
From Person.Person;

-- The Union All SHould be 1018 + 1206 ?

Select FirstName -- No it is 39944 Rows, which is twice the number of Rows in Person.Person
From Person.Person

UNION ALL

Select LastName
From Person.Person;

Select 39944 / 2;

-- Except 

-- Try Unique First Names - Unique Last Names using Except
-- Should give 1018 - 64
SELECT 1018 - 64; -- 954

SELECT DISTINCT FirstName
From Person.Person

EXCEPT

SELECT DISTINCT LastName
From Person.Person; -- TRUE This is 954 rows


-- Get everyone who lives on a street, in WA, first name starts with j
Select FirstName, MiddleName, LastName, address.AddressLine1, City, StateProvinceCode, PostalCode -- 15 rows
FROM Person.Person as person
LEFT JOIN
( -- subquery
	Select *
	FROM Person.BusinessEntityAddress
) as pba on person.BusinessEntityID = pba.BusinessEntityID
INNER JOIN
( -- subquery
	Select *
	FROM Person.Address
	WHERE AddressLine1 LIKE '%Street%'
) as address on pba.AddressID = address.AddressID
INNER JOIN
( -- subquery
	Select *
	FROM Person.StateProvince
	WHERE StateProvinceCode = 'WA'
) as sp on address.StateProvinceID = sp.StateProvinceID
WHERE FirstName >= 'j' AND FirstName < 'k'; -- All Names That Start with J

-- Common Table Expression

WITH addr(aid, al1, city, spi, pc) as -- CORRECT, Output is 15 rows
(
	Select AddressID, AddressLine1, City, StateProvinceID, PostalCode
	FROM Person.Address
	WHERE AddressLine1 LIKE '%Street%'
),
psp (spi, spc) as
(
	Select StateProvinceID, StateProvinceCode
	FROM Person.StateProvince
	WHERE StateProvinceCode = 'WA'
)
Select FirstName, MiddleName, LastName, address.al1, city, sp.spc, pc -- 15 rows
FROM Person.Person as person
LEFT JOIN
( -- subquery
	Select *
	FROM Person.BusinessEntityAddress
) as pba on person.BusinessEntityID = pba.BusinessEntityID
INNER JOIN addr as address on pba.AddressID = address.aid
INNER JOIN psp as sp on address.spi = sp.spi
WHERE FirstName >= 'j' AND FirstName < 'k'; -- All Names That Start with J

-- Fix Nulls

Select FirstName + ' ' + isNull(MiddleName + ' ', '') + LastName
FROM Person.Person as person
WHERE FirstName >= 'j' AND FirstName < 'k';


Select FirstName + ' ' + Coalesce(NULL, NULL, MiddleName + ' ', '') + LastName -- Coalesce chooses first thing that is not NULL, like a switch statement
FROM Person.Person as person
WHERE FirstName >= 'j' AND FirstName < 'k';


Select FirstName + ' ' + isNull(MiddleName + ' ', '') + LastName
FROM Person.Person as person
WHERE FirstName in ('Jack', 'Jill');


Select ppa.FirstName -- This Works
From Person.Person as ppa
Where exists
(
	Select LastName
	From Person.Person as ppb
	WHERE ppa.FirstName = ppb.LastName
);

/*
SELECT a.FirstName, a.LastName  
FROM Person.Person AS a  
WHERE EXISTS  
(SELECT *   
    FROM HumanResources.Employee AS b  
    WHERE a.BusinessEntityID = b.BusinessEntityID  
    AND a.LastName = 'Johnson');  
GO  
*/

-- List all employees that bought a product







