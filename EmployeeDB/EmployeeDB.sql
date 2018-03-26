
-- Employee Database
USE adventureworksdb;
GO

-- Create Database
-- create database EmployeeDB;
GO

-- Create Schema
create schema Employee;
GO

-- Create Tables

create table Employee.Department
(
	DepartmentID int not null primary key identity(1,1)
	, [Name] nvarchar(150) not null
	, [Location] nvarchar(300)
	, ModifiedDate datetime2(3) not null
	, Active bit not null default(1)
);

create table Employee.Employee
(
	EmployeeID int not null primary key identity(1,1)
	, FirstName nvarchar(150) not null
	, LastName nvarchar(150) not null
	, SSN int not null
	, DeptID int -- FK references Department
	, ModifiedDate datetime2(3) not null
	, Active bit not null default(1)
);

create table Employee.EmpDetails
(
	EmpDetailsID int not null primary key identity(1,1)
	, EmployeeID int -- FK references Employee
	, Salary float
	, AdressLine1 nvarchar(300)
	, AdressLine2 nvarchar(300)
	, City nvarchar(100)
	, [State] nvarchar(2)
	, Country nvarchar(100)
	, ModifiedDate datetime2(3) not null
	, Active bit not null default(1)
);

-- ALTER Foreign Keys

-- Foreign keys for Employee table
alter table Employee.Employee
	add constraint FK_Employee_DeptID foreign key (DeptID) references Employee.Department(DepartmentID)
	on update cascade;

-- Foreign keys for EmpDetails table
alter table Employee.EmpDetails
	add constraint FK_EmpDetails_EmployeeID foreign key (EmployeeID) references Employee.Employee(EmployeeID)
	on update cascade;

-- add at least 3 records into each table
INSERT INTO Employee.Department([Name], [Location], ModifiedDate)
VALUES
('Accounting', '4202 E Fowler Ave, Tampa, FL 33620', getdate()),
('Marketing', '4203 E Fowler Ave, Tampa, FL 33620', getdate()),
('Sales', '4204 E Fowler Ave, Tampa, FL 33620', getdate());
GO

INSERT INTO Employee.Employee(FirstName, LastName, SSN, DeptID, ModifiedDate)
VALUES
('Jimmy', 'John', 222222221, 1, getdate()),
('Allison', 'Arnold', 222222222, 1, getdate()),
('Miguel', 'Angel', 222222223, 1, getdate()),
('Susan', 'Price', 222222224, 2, getdate()),
('Cotrik', 'Xu', 222222225, 2, getdate()),
('Peter', 'Goodman', 222222226, 2, getdate()),
('Levi', 'Price', 222222227, 3, getdate()),
('Emily', 'Xu', 222222228, 3, getdate()),
('Daryl', 'Goodman', 222222229, 3, getdate());
GO

INSERT INTO Employee.EmpDetails(EmployeeID, Salary, AdressLine1, City, [State], Country, ModifiedDate)
VALUES
(1, 40000, '222 Bleeker St', 'Tampa', 'FL', 'United States', getdate()),
(2, 45000, '222 Bleeker St', 'Tampa', 'FL', 'United States', getdate()),
(3, 30000, '222 Bleeker St', 'Tampa', 'FL', 'United States', getdate()),
(4, 40000, '222 Bleeker St', 'Tampa', 'FL', 'United States', getdate()),
(5, 60000, '222 Bleeker St', 'Tampa', 'FL', 'United States', getdate()),
(6, 47000, '222 Bleeker St', 'Tampa', 'FL', 'United States', getdate()),
(7, 80000, '222 Bleeker St', 'Tampa', 'FL', 'United States', getdate()),
(8, 100000, '222 Bleeker St', 'Tampa', 'FL', 'United States', getdate()),
(9, 41000, '222 Bleeker St', 'Tampa', 'FL', 'United States', getdate());
GO

-- add employee Tina Smith
INSERT INTO Employee.Employee(FirstName, LastName, SSN, DeptID, ModifiedDate)
VALUES
('Tina', 'Smith', 322222221, 2, getdate());
GO

INSERT INTO Employee.EmpDetails(EmployeeID, Salary, AdressLine1, City, [State], Country, ModifiedDate)
VALUES
(10, 40000, '222 Bleeker St', 'Tampa', 'FL', 'United States', getdate());
GO


-- add department Marketing
INSERT INTO Employee.Department([Name], [Location], ModifiedDate)
VALUES
('Marketing2', '4220 E Fowler Ave, Tampa, FL 33620', getdate());


-- list all employees in Marketing
select FirstName, LastName, SSN, dep.[Name], dep.[Location]
FROM Employee.Employee as emp
inner join Employee.Department as dep
on emp.DeptID = dep.DepartmentID
where dep.[Name] = 'Marketing';
GO

-- report total salary of Marketing
select SUM(Salary) as 'Total Salary Marketing'
FROM Employee.Employee as emp
left join 
(
	select EmployeeID, Salary
	From Employee.EmpDetails
) as det on emp.EmployeeID = det.EmployeeID
inner join
(
	select DepartmentID, [Name]
	from Employee.Department
	where [Name] = 'Marketing'
) as dep on emp.DeptID = dep.DepartmentID;


-- report total employees by department
select Count(dep.[Name]) as 'Number of Employees', dep.[Name] as 'Department Name'
FROM Employee.Employee as emp
inner join 
(
	select DepartmentID, [Name]
	from Employee.Department
) as dep on emp.DeptID = dep.DepartmentID
group by dep.[Name];


-- increase salary of Tina Smith to $90,000
select EmployeeID from Employee.Employee where FirstName = 'Tina' and LastName = 'Smith';

Update Employee.EmpDetails
Set Salary = 90000
Where EmpDetails.EmployeeID in
(
	select EmployeeID from Employee.Employee where FirstName = 'Tina' and LastName = 'Smith'
);

