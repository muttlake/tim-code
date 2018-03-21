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

-- the 3 most popular first names
SELECT TOP 3 Count(*), FirstName
FROM Person.Person as pp
GROUP BY FirstName
ORDER BY Count(*) DESC;

-- the 3 least popular last names
SELECT TOP 3 Count(*), LastName
FROM Person.Person as pp
GROUP BY LastName
ORDER BY Count(*) ASC;

SELECT Count(*), LastName
FROM Person.Person as pp
GROUP BY LastName
ORDER BY Count(*) ASC;

-- INSERT

-- UPDATE

-- DELETE

