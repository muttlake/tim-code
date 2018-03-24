
-- Pizza Store Definition

USE adventureworksdb;
GO

/*
drop table PizzaStore.Address;
drop table PizzaStore.PizzaCheese;
drop table PizzaStore.Cheese;
drop table PizzaStore.Location;
drop table PizzaStore.PizzaTopping;
drop table PizzaStore.Topping;
drop table PizzaStore.Pizza;
drop schema PizzaStore;*/
GO

-- Create Schema
create schema PizzaStore;
GO
-- CREATE Tables
----------------------------------------------------------------------------------
create table PizzaStore.[Order]
(
	PizzaID int not null primary key identity(1,1)
	, LocationID int not null -- FK references Location
	, TotalValue float
	, OrderTime, datetime2(3) not null
	, CustomerID int not null -- FK references Customer
	, ModifiedDate datetime2(3) not null
	, Active bit not null default(1)
);

create table PizzaStore.[Location]
(
	LocationID int not null primary key identity(1,1)
	, AddressID int not null -- FK references Address
	, InventoryID int not null -- FK references Inventory
	, ModifiedDate datetime2(3) not null
	, Active bit not null default(1)
);


create table PizzaStore.Customer
(
	CustomerID int not null primary key identity(1,1)
	, AddressID int not null -- FK references Address
	, Phone nvarchar(10)
	, Email nvarchar(100) not null
	, ModifiedDate datetime2(3) not null
	, Active bit not null default(1)
);


create table PizzaStore.[Address]
(
	AddressID int not null primary key identity(1,1)
	, Street nvarchar(150)
	, City nvarchar(100)
	, State nvarchar(2)
	, ZipCode nvarchar(5)
	, ModifiedDate datetime2(3) not null
	, Active bit not null default(1)
);


create table PizzaStore.Pizza
(
	PizzaID int not null primary key identity(1,1)
	, Crust VARCHAR(20) NOT NULL CHECK (Crust IN('Thin', 'HandTossed', 'Thick'))
	, Sauce VARCHAR(20) NOT NULL CHECK (Sauce IN('Tomato', 'Pesto'))
	, TotalPizzaCost float
	, OrderID int not null -- FK references Order
	, ModifiedDate datetime2(3) not null
	, Active bit not null default(1)
);

create table PizzaStore.Cheese
(
	CheeseID int not null primary key identity(1,1)
	, Cheese varchar(20) not null check(Cheese in ('Mozzarella', 'Cheddar', 'Colby'))
	, CheeseCost float not null
	, ModifiedDate datetime2(3) not null
	, Active bit not null default(1)
);


create table PizzaStore.Topping
(
	ToppingID int not null primary key identity(1,1)
	, Topping varchar(10) not null check(Topping in ('Pepperoni', 'Onion', 'GreenPepper', 'Meatball', 'Mushroom'))
	, ToppingCost float not null
	, ModifiedDate datetime2(3) not null
	, Active bit not null default(1)
);


create table PizzaStore.PizzaHasCheese
(
	PizzaHasCheeseID int not null primary key identity(1,1)
	, PizzaID int not null -- FK references Pizza
	, CheeseID int not null -- FK references Cheese
);

create table PizzaStore.PizzaHasTopping
(
	PizzaHasToppingID int not null primary key identity(1,1)
	, PizzaID int not null -- FK references Pizza
	, ToppingID int not null -- FK references Topping
);


create table PizzaStore.Inventory
(
	InventoryID int not null primary key identity(1,1)
	, LocationID int not null -- FK references Location
	, Crust_Thin_Count int not null
	, Crust_HandTossed_Count int not null
	, Crust_Thick_Count int not null
	, Crust_Thick_Count int not null
	, Crust_Thick_Count int not null
);

----------------------------------------------------------------------------------

create table PizzaStore.Pizza
(
	PizzaID int not null primary key identity(1,1)
	, Crust VARCHAR(10) NOT NULL CHECK (Crust IN('Thin', 'HandTossed', 'Thick'))
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




































