
-- Mar 22 REDO

USE adventureworksdb;
GO


-- Make a Schemabinding view, For Full name.  Schema binding: Columns in View cannot be deleted

alter view Person.vw_FullName with schemabinding
as
select (firstname + ' ' + coalesce(middlename + ' ', '') + lastname) as FullName
from Person.Person;
GO


select *
FROM Persons;
GO

-- Tabular and scalar functions

alter function Person.fn_FullName(@name varchar(max))
returns table
as
	return
	select (firstname + ' ' + coalesce(middlename + ' ', '') + lastname) as FullName
	from Person.Person
	where firstname = @name or lastname = @name;
GO



Select *
FROM Person.fn_FullName('Miguel');
GO

-- Make a scalar function that just returns a value

alter function Person.fn_PrintFullName(@firstname varchar(max), @middlename varchar(max), @lastname varchar(max))
returns varchar(max)
as
begin
	return @firstname + ' ' + coalesce(@middlename + ' ', '') + @lastname
end
GO


select Person.fn_PrintFullName(firstname, middlename, lastname) as FullName
from Person.Person;
GO

-- Stored Procedures
create procedure Person.sp_UpdateFirstName(@id int, @newFirstName varchar(max))
as
begin
	update Person.Person
	set FirstName = @newFirstName
	where BusinessEntityID = @id
end
GO

select * from person.person where FirstName LIKE '%Fratry%';

execute Person.sp_UpdateFirstName 19472, 'Fratry'; -- this worked
GO

-- Now Let's do a stored procedure with error catching
alter procedure Person.sp_AddApartment(@street varchar(max), @apartment varchar(max))
as
begin
	declare @id int;

	select @id = AddressID
	from Person.Address
	where AddressLine1 = @street

	begin transaction
		begin try
			if (@id is not null)
			begin
				update Person.Address
				set AddressLine2 = @apartment
				where AddressID = @id
				commit transaction
			end
			else
			begin
				-- RAISERROR('There is no address there', 16, 50000) -- Both Raiserror and throw work
				THROW 50001, 'There really isnt an address there fool.', 16;
			end
		end try
		begin catch
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


select * from Person.Address where AddressLine1 like '%Whitehall%';

execute Person.sp_AddApartment '5274 Whitehall Drive', 'CCCC';
GO

-- CREATE


-- Create Database
-- create database newdb2; -- do not run

-- Create Schema
create schema PizzaStore;
GO
-- CREATE Tables
create table PizzaStore.Pizza
(
	PizzaID int not null primary key identity(1,1)
	, Crust VARCHAR(10) NOT NULL CHECK (Crust IN('Thin', 'HandTossed', 'Thick'))
	, LocationID int not null
	, ModifiedDate datetime2(3) not null
	, Active bit not null default(1)
);
GO

create table PizzaStore.Cheese
(
	CheeseID int not null primary key identity(1,1)
	, Cheese varchar(10) not null check(Cheese in ('Mozzarella', 'Cheddar', 'Colby'))
	, ModifiedDate datetime2(3) not null
	, Active bit not null default(1)
);

-- drop table PizzaStore.PizzaCheese;

create table PizzaStore.PizzaCheese -- transition table
(
	PizzaCheeseID int not null primary key identity(1,1)
	, PizzaID int not null
	, CheeseID int not null
);

alter table PizzaStore.PizzaCheese
	add constraint FK_PizzaCheese_Pizza foreign key (PizzaID) references PizzaStore.Pizza(PizzaID)
	on update cascade;

alter table PizzaStore.PizzaCheese
	add constraint FK_PizzaCheese_Cheese foreign key (CheeseID) references PizzaStore.Cheese(CheeseID)
	on update cascade;
GO			  


create table PizzaStore.Topping
(
	ToppingID int not null primary key identity(1,1)
	, Topping varchar(10) not null check(Topping in ('Pepperoni', 'Onion', 'GreenPepper', 'Meatball', 'Mushroom'))
	, ModifiedDate datetime2(3) not null
	, Active bit not null default(1)
);

create table PizzaStore.PizzaTopping
(
	PizzaToppingID int not null primary key identity(1,1)
	, PizzaID int not null
	, ToppingID int not null
);

alter table PizzaStore.PizzaTopping
	add constraint FK_PizzaTopping_Pizza foreign key (PizzaID) references PizzaStore.Pizza(PizzaID)
	on update cascade;

alter table PizzaStore.PizzaTopping
	add constraint FK_PizzaTopping_Topping foreign key (ToppingID) references PizzaStore.Topping(ToppingID)
	on update cascade;
GO			  


create table PizzaStore.Location
(
	LocationID int not null primary key identity(1,1)
	, AddressID int not null
);

create table PizzaStore.Address
(
	AddressID int not null primary key identity(1,1)
	, Street varchar(150)
	, City varchar(100)
	, State varchar(2)
	, ZipCode varchar(5)
);

alter table PizzaStore.Location
	add constraint FK_PizzaTopping_Pizza foreign key (PizzaID) references PizzaStore.Pizza(PizzaID)
	on update cascade;


/*
Create Trigger Pizza.tr_AddPizzaCheese ON Pizza.PizzaCheese
INSTEAD OF DELETE
as
begin
    declare @numberOfCheesesOnPizza int  
    declare @insertedPizzaID int
	  
    SET NOCOUNT ON;  
    SELECT @insertedPizzaID = PizzaID from inserted

	update Contact.Person
	Set Active = 0
	Where PersonId in
	(
		select PersonId
		from deleted -- deleted table temporarily holds information to be deleted
	)
end
GO
*/




































