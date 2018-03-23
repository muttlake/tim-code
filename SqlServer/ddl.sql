

use adventureworksdb
GO


-- Create DATABASE
-- create Database TimDB; -- Do not run this, you will get charged

-- Create SCHEMA
create schema Contact; -- Database and Schema just containers
GO

select * from person.person;


-- Create Table
create table Contact.Person
(
	PersonId int primary key identity(1,1) -- T SQL PRIMARY KEY Does not allow null, identity(1, 1) makes new PersonID automatically
	, PhoneID int foreign key references Contact.Phone(PhoneID) -- put here because only 1 phone number per person
	, FirstName nvarchar(150) not null -- nvarchar is Unicode, nvarchar stretches up to max
	, LastName nvarchar(150) not null
	, ModifedDate as sysutcdatetime() -- Does not allow you to set ModifiedDate
	, Active bit not null default(1)
);


-- Assume one person can have 1 phone number but many emails
create table Contact.Email
(
	EmailID int not null
	, PersonID int null -- put here because you can have many emails
	, [Address] nvarchar(100) not null -- Address and Number key words in TSQL, in case Microsoft wants to use them in the future
	, ModifedDate datetime2(0) not null
	--, ModifedDate as sysutcdatetime() persisted -- Does not allow you to set ModifiedDate
	, Active bit not null default(1)
	, primary key (EmailID) -- another way to do constraints
	, foreign key (PersonID) references Contact.Person(PersonID)
);

create table Contact.Phone
(
	PhoneID int not null
	, [Number] nvarchar(10) not null
	--, ModifedDate datetime2(0) not null
	, ModifedDate datetime2(0) not null -- Does not allow you to set ModifiedDate
	, Active bit not null default(1)
);

-- Fred Reccommendation:
-- ALTER Tables -- Alter is like Update for DDL
-- Can create a table and then give them constraints
-- Stagger scripts to see if thing you are trying to do even possible
-- Also order matters less
-- ALter is good for changing tables

alter table Contact.Phone
	add constraint PK_Phone_PhoneID primary key (PhoneID);

alter table Contact.Email
	add constraint CK_Email_Address check([Address] LIKE '%@%.%'); -- check will check for if Address inserted like this

alter table Contact.Email
	add constraint FK_Email_PersonID foreign key (PersonID) references Contact.Person(PersonID)
	on update cascade; -- wire email personID to Person personID, if Email Person ID is updated Update Person.PersonID
					   -- If Person.PersonID is Updated, Email.PersonID is Updated
					   -- on delete cascade is not used very often

alter table Contact.Person
	add FullName as FirstName + ' ' + LastName persisted; -- persisted means only change fullname if there is an update to FirstName or LastName

alter table Contact.Person
	alter column LastName varchar(100) not null; -- Does not work because FullName is persisted

-- DROP TABLES
drop table Contact.Phone; -- cannot happen because of foreign keys
drop table Contact.Person; -- Sayonara

-- TRUNCATE tables
truncate table Contact.Phone; -- removes reference to table
                              -- truncate also respects the hierarchy of things


SELECT *
FROM Contact.Person;
GO

-- TRIGGERS

-- Make sure you cannot delete a person

Create Trigger Contact.tr_Person ON Contact.Person
INSTEAD OF DELETE
as
begin
	update Contact.Person
	Set Active = 0
	Where PersonId in
	(
		select PersonId
		from deleted -- deleted table temporarily holds information to be deleted
	)
end
GO

-- trigger is listening to events
Create Trigger Contact.tr_PersonHistory ON Contact.Person
After DELETE
as
begin
	INSERT INTO Contact.NewHistory
	Select *
	from inserted;
	INSERT INTO Contact.OldHistory
	Select *
	from deleted;
end
GO
























