
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

