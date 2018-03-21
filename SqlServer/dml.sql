USE adventureworksdb;
GO -- Go because You want it to run within its own stack

-- SELECT
SELECT * FROM sys.databases;
-- master is Database of Databases, knows all the databases
-- This command ran in Master

SELECT * FROM sys.schemas;
SELECT * FROM sys.tables;

SELECT 'hello sql';
-- SELECT is nothing more than Console.WriteLine();

SELECT *
FROM Person.Person;
-- Do not use SELECT * most of the time

SELECT FirstName, MiddleName, LastName
FROM Person.Person;
-- What if FirstName does not work for you

SELECT FirstName GivenName, MiddleName 'Name Middle', LastName as Surname, LastName as [Family Name]
FROM Person.Person;
-- These are the ways to create an alias, but as Blank is the only one
-- that is considered good form.  So always do "as"

SELECT FirstName as First, MiddleName as 'Middle Name', LastName as [sur name]
FROM Person.Person;
-- quotes are sql standard
-- [] are microsoft sql server

-- SELECT is a filter on columns
-- WHERE is a filter on rows

SELECT FirstName, MiddleName, LastName
FROM Person.Person
WHERE FirstName = 'john' or MiddleName = 'john' or LastName = 'john';
-- Case does not matter 'john' is not case sensitive
-- SQL saves information in a Collation  Case Insensite, Accent Sensitive CI_AS
-- You can set the collation:
-- COLLATE SQL_Latin1_...
-- Usually we do not change to collation.
-- Code that you write is also within Collation, so Case Insensitive

SELECT FirstName, MiddleName, LastName
FROM Person.Person
WHERE FirstName = 'john' or MiddleName = 'john' or LastName = 'john'
COLLATE Latin1_General_CS_AS_KS_WS; -- Not working, still shows 'John'

-- How to find anybody that has 'john' in their name
SELECT FirstName, MiddleName, LastName
FROM Person.Person
WHERE FirstName LIKE '%john%';
-- You get all forms of John


-- You want names that start with j and are four letters long
SELECT FirstName, MiddleName, LastName
FROM Person.Person
WHERE FirstName LIKE 'j[a-z][a-z][a-z]';
SELECT FirstName, MiddleName, LastName
FROM Person.Person
WHERE FirstName LIKE 'j___';
-- You get all forms of J letter letter letter

-- Want four letters last three a-k
SELECT FirstName, MiddleName, LastName
FROM Person.Person
WHERE FirstName LIKE 'j[a-k][a-k][a-k]';

SELECT Count(FirstName), FirstName -- outputs a count, firstname for each group
FROM Person.Person
WHERE LastName = 'Smith'
GROUP BY FirstName;  -- Rolls up each unique FirstName into a Group


SELECT Count(FirstName), FirstName, MiddleName
FROM Person.Person
WHERE LastName = 'Smith'
GROUP BY FirstName, MiddleName;  -- Groups Unique FirstName, MiddleName pairs


-- Only get groups with counts > 1
SELECT Count(*), FirstName, MiddleName
FROM Person.Person
WHERE LastName = 'Smith'
GROUP BY FirstName, MiddleName
HAVING Count(*) > 1;

-- Only get groups with counts = 1 order by MiddleName Ascending, FirstName Descending
-- This is a complete select statement
SELECT Count(*), FirstName, MiddleName as MN
FROM Person.Person as pp
WHERE LastName = 'Smith'
GROUP BY FirstName, MiddleName
HAVING Count(*) = 1
ORDER BY MN ASC, FirstName DESC;

-- The Select statement works this way
-- from > where > group by > having > select > order by


-- Select all persons with no middle name
SELECT * 
FROM Person.Person
WHERE MiddleName = '';


-- select all persons with modified date in the latest year.
SELECT FirstName, LastName, ModifiedDate
FROM Person.Person
WHERE ModifiedDate >= '2015-01-01';


SELECT FirstName, LastName, ModifiedDate
FROM Person.Person;

-- select the full name of each person like "fred t. belotte"
SELECT Name = FirstName + ' ' + MiddleName + ' ' + LastName
FROM Person.Person;
-- This is technically an error because there are so many NULL
-- WHERE MiddleName is Not NULL AND FirstName is Not NULL and LastName is Not NULL;

-- the 3 most popular first names, Trap because it is top 3 and ties to 3rd
SELECT TOP 6 Count(*), FirstName
FROM Person.Person as pp
GROUP BY FirstName
ORDER BY Count(*) DESC;
-- TOP is dangerous because ties are ignored, TOP3 is (Richard, Katherine, James and Marcus)

-- the 3 least popular last names
-- SELECT TOP 3 Count(*), LastName
SELECT Count(*), LastName
FROM Person.Person as pp
GROUP BY LastName
ORDER BY Count(*) ASC;

SELECT Count(*), LastName
FROM Person.Person as pp
GROUP BY LastName
ORDER BY Count(*) ASC;


-- INSERT
SELECT * FROM Person.Address;

-- This is called Simple Insert
INSERT INTO Person.Address
Values('123 main st', null, 'Tampa', 79, 98011, 0xE6100000010C61C64D8ABBD94740C460EA3FD8855EC0, '0B6B739D-8EB6-4378-8D55-FE196AF34C0B', '2018-03-21');

SELECT * FROM Person.Address where City = 'Tampa';

-- Normal Insert list value types
INSERT INTO Person.Address(City, AddressLine2, AddressLine1, StateProvinceID, PostalCode, ModifiedDate, rowguid, SpatialLocation)
Values('Tampa', NULL, '334 Fastball St', 79, 22222, '2018-03-20', '0B6B739D-8EB6-4378-8D55-FE196AF34C2F', 0xE6100000010C61C64D8ABBD94740C460EA3FD8855EC0);

SELECT * FROM Person.Address where City = 'Tampa';

-- This should work but it is blocked by an index
-- We are moving data from one table into this table using Select
-- This is "Enhanced Insert"
INSERT INTO Person.Address(City, AddressLine2, AddressLine1, StateProvinceID, PostalCode, ModifiedDate, SpatialLocation)
SELECT City, AddressLine2, AddressLine1, StateProvinceID, PostalCode, ModifiedDate, SpatialLocation
FROM Person.Address
-- FROM DB2.Person.Address
WHERE AddressID < 10;

BULK INSERT Person.Address
FROM 'https://s3.us-east-2.amazonaws.com/1803-mar12-net-44/data.csv'
WITH (rowterminator = '\n', fieldterminator=','); -- Some Restriction


-- UPDATE
-- UPDATE Person.Address
-- Set AddressLine1 = '987 fowler ave'; -- Run this and your fired because it will change everyone's address
-- Always make sure there is a where
SELECT * FROM Person.Address Where City = 'Tampa';

-- It would not allow to change all Tampa addresses because you cannot have duplicate addresses
-- This is the Normal Update
UPDATE Person.Address
Set AddressLine1 = '980 fowler ave'
Where City = 'Tampa' and StateProvinceID = 15;


-- This is the Enhanced Update
-- Only update this address if some condition from some other table is true
UPDATE pa
Set AddressLine1 = '922 Hooch st'
from Person.Address as pa
Where City = 'Tampa' and PostalCode = 98011;

-- UPDATE pa
-- Set AddressLine1 = '922 Hooch st'
-- from Person.Address as pa, Person.Person as pp -- Do not do this because you are pulling from two tables
-- Where City = 'Tampa' and pa.PostalCode = 98011; -- These are not related, Will cause slowdown because FROM will bring both entire tables up


-- DELETE
-- DELETE Person.Address; Would delete the whole table

DELETE FROM Person.Address
WHERE AddressLine1 = '333 Slap St';
-- Both "Delete" and "Delete" From Work

SELECT *
FROM Person.Address
WHERE City = 'Tampa';

DELETE pa
FROM Person.Address as pa, Person.Person as pp 
WHERE AddressLine1 = '333 Slap St';

-- JOIN

-- Try to Join: Person Name and Address

SELECT * FROM sys.tables; -- Shows all Tables

SELECT * FROM Person.Person; -- 19972 address
SELECT * FROM Person.BusinessEntityAddress;

-- We Will need Transition Table BusinessEntityAddress, 19996 because maybe people have more than one address
SELECT FirstName, LastName, AddressLine1, City, StateProvinceID, PostalCode
FROM Person.Person as pp
LEFT JOIN Person.BusinessEntityAddress as pb ON pp.BusinessEntityID = pb.BusinessEntityID 
LEFT JOIN Person.Address as pa ON pa.AddressID = pb.AddressID;


-- We Will need Transition Table BusinessEntityAddress, 18798 rows
SELECT FirstName, LastName, AddressLine1, City, ps.StateProvinceCode, PostalCode
FROM Person.Person as pp
LEFT JOIN Person.BusinessEntityAddress as pb ON pp.BusinessEntityID = pb.BusinessEntityID 
LEFT JOIN Person.Address as pa ON pa.AddressID = pb.AddressID
INNER JOIN Person.StateProvince as ps on ps.StateProvinceID = pa.StateProvinceID; -- We lost people because of Inner Join 

-- We Will need Transition Table BusinessEntityAddress, 19996 because maybe people have more than one address
SELECT FirstName, LastName, AddressLine1, City, ps.StateProvinceCode, PostalCode
FROM Person.Person as pp
LEFT JOIN Person.BusinessEntityAddress as pb ON pp.BusinessEntityID = pb.BusinessEntityID 
LEFT JOIN Person.Address as pa ON pa.AddressID = pb.AddressID
LEFT JOIN Person.StateProvince as ps on ps.StateProvinceID = pa.StateProvinceID -- We do not lose people because LEFT JOIN
ORDER BY LastName ASC, FirstName ASC;

-- Find people with Addresses in WASHINGTON State
-- We Will need Transition Table BusinessEntityAddress, 2560 rows in result
SELECT FirstName, LastName, AddressLine1, City, ps.StateProvinceCode, PostalCode
FROM Person.Person as pp
LEFT JOIN Person.BusinessEntityAddress as pb ON pp.BusinessEntityID = pb.BusinessEntityID 
LEFT JOIN Person.Address as pa ON pa.AddressID = pb.AddressID
LEFT JOIN Person.StateProvince as ps on ps.StateProvinceID = pa.StateProvinceID -- We do not lose people because LEFT JOIN
WHERE ps.StateProvinceID = 79
ORDER BY LastName ASC, FirstName ASC;

-- Find people with Addresses in WASHINGTON State, Only with Street as Part of Address
-- We Will need Transition Table BusinessEntityAddress, 96 rows result
SELECT FirstName, LastName, AddressLine1, City, ps.StateProvinceCode, PostalCode
FROM Person.Person as pp
LEFT JOIN Person.BusinessEntityAddress as pb ON pp.BusinessEntityID = pb.BusinessEntityID 
LEFT JOIN Person.Address as pa ON pa.AddressID = pb.AddressID
LEFT JOIN Person.StateProvince as ps on ps.StateProvinceID = pa.StateProvinceID -- We do not lose people because LEFT JOIN
WHERE ps.StateProvinceID = 79 AND (pa.AddressLine1 LIKE '%Street%' or pa.AddressID LIKE '%St.%')
ORDER BY LastName ASC, FirstName ASC;


-- Find people with Addresses in WASHINGTON State, Only with Street as Part of Address, Any FirstName that starts with J
-- We Will need Transition Table BusinessEntityAddress, 15 rows result
SELECT FirstName, LastName, AddressLine1, City, ps.StateProvinceCode, PostalCode
FROM Person.Person as pp
LEFT JOIN Person.BusinessEntityAddress as pb ON pp.BusinessEntityID = pb.BusinessEntityID 
LEFT JOIN Person.Address as pa ON pa.AddressID = pb.AddressID
LEFT JOIN Person.StateProvince as ps on ps.StateProvinceID = pa.StateProvinceID -- We do not lose people because LEFT JOIN
WHERE ps.StateProvinceID = 79 AND (pa.AddressLine1 LIKE '%Street%') AND FirstName LIKE 'J%'
ORDER BY LastName ASC, FirstName ASC;

-- Find people with Addresses in WASHINGTON State, Only with Street as Part of Address, Any FirstName that has j + another letter at least
-- We Will need Transition Table BusinessEntityAddress, 58 rows result
SELECT FirstName, LastName, AddressLine1, City, ps.StateProvinceCode, PostalCode
FROM Person.Person as pp
LEFT JOIN Person.BusinessEntityAddress as pb ON pp.BusinessEntityID = pb.BusinessEntityID 
LEFT JOIN Person.Address as pa ON pa.AddressID = pb.AddressID
LEFT JOIN Person.StateProvince as ps on ps.StateProvinceID = pa.StateProvinceID -- We do not lose people because LEFT JOIN
WHERE ps.StateProvinceID = 79 AND (pa.AddressLine1 LIKE '%Street%') AND FirstName > 'j'
ORDER BY FirstName ASC, LastName ASC;

-- Find people with Addresses in WASHINGTON State, Only with Street as Part of Address, Any FirstName that has j + another letter at least
-- We Will need Transition Table BusinessEntityAddress, 15 rows result
SELECT FirstName, LastName, AddressLine1, City, ps.StateProvinceCode, PostalCode
FROM Person.Person as pp
LEFT JOIN Person.BusinessEntityAddress as pb ON pp.BusinessEntityID = pb.BusinessEntityID 
LEFT JOIN Person.Address as pa ON pa.AddressID = pb.AddressID
LEFT JOIN Person.StateProvince as ps on ps.StateProvinceID = pa.StateProvinceID -- We do not lose people because LEFT JOIN
WHERE ps.StateProvinceID = 79 AND (pa.AddressLine1 LIKE '%Street%') AND FirstName >= 'j' AND FIRSTNAME < 'k'
ORDER BY FirstName ASC, LastName ASC;



-- Find people with Addresses in WASHINGTON State, Only with Street as Part of Address, Any FirstName that has j + another letter at least
-- We Will need Transition Table BusinessEntityAddress, Now do with subqueries, 2468 rows not equal to 15 rows
SELECT FirstName, LastName, AddressLine1, City, ps.StateProvinceCode, PostalCode
FROM Person.Person as pp
LEFT JOIN Person.BusinessEntityAddress as pb ON pp.BusinessEntityID = pb.BusinessEntityID 
LEFT JOIN 
(
	SELECT AddressLine1, AddressID, StateProvinceID, City, PostalCode
	FROM PERSON.Address
	Where AddressLine1 LIKE '%Street%' -- Where is only applying to subquery, you will have lots of nulls
) as pa on pa.AddressID = pb.AddressID
LEFT JOIN 
(
	SELECT StateProvinceID, StateProvinceCode
	FROM Person.StateProvince
	WHERE StateProvinceCode = 'WA'
) as ps on ps.StateProvinceID = pa.StateProvinceID -- We do not lose people because LEFT JOIN
WHERE FirstName >= 'j' AND FIRSTNAME < 'k'
ORDER BY FirstName ASC, LastName ASC;


-- Find people with Addresses in WASHINGTON State, Only with Street as Part of Address, Any FirstName that has j + another letter at least
-- We Will need Transition Table BusinessEntityAddress, Now do with subqueries, 15 rows equal to 15 rows
SELECT FirstName, LastName, AddressLine1, City, ps.StateProvinceCode, PostalCode
FROM Person.Person as pp
LEFT JOIN Person.BusinessEntityAddress as pb ON pp.BusinessEntityID = pb.BusinessEntityID 
INNER JOIN -- Changed to Inner Join because you only want records that match the subquery, we are saving ourselves from loading 4 tables
( -- subqueries improve performance, allow pre-filtering 
	SELECT AddressLine1, AddressID, StateProvinceID, City, PostalCode
	FROM PERSON.Address
	Where AddressLine1 LIKE '%Street%' -- Where is only applying to subquery, you will have lots of nulls
) as pa on pa.AddressID = pb.AddressID
INNER JOIN 
(
	SELECT StateProvinceID, StateProvinceCode
	FROM Person.StateProvince
	WHERE StateProvinceCode = 'WA'
) as ps on ps.StateProvinceID = pa.StateProvinceID -- We do not lose people because LEFT JOIN
WHERE FirstName >= 'j' AND FIRSTNAME < 'k'
ORDER BY AddressLine1 ASC, LastName ASC;


-- Now we will re-write this as a Common Table Expression, CTEs are like mini-methods
WITH addr(al1, ai, spi, c, pc) as 
(
	SELECT AddressLine1, AddressID, StateProvinceID, City, PostalCode
	FROM PERSON.Address
	Where AddressLine1 LIKE '%Street%' -- Where is only applying to subquery, you will have lots of nulls
),
prov(spi, spc) as
(
	SELECT StateProvinceID, StateProvinceCode
	FROM Person.StateProvince
	WHERE StateProvinceCode = 'WA'
)
-- Find people with Addresses in WASHINGTON State, Only with Street as Part of Address, Any FirstName that has j + another letter at least
-- We Will need Transition Table BusinessEntityAddress, Now do with Common Table Expressions, 15 rows equal to 15 rows
SELECT FirstName, LastName, al1, c, spc, pc
FROM Person.Person as pp
LEFT JOIN Person.BusinessEntityAddress as pb ON pp.BusinessEntityID = pb.BusinessEntityID 
INNER JOIN addr on addr.ai = pb.AddressID
INNER JOIN prov on prov.spi = addr.spi
WHERE FirstName >= 'j' AND FIRSTNAME < 'k'
ORDER BY al1 ASC, LastName ASC;

