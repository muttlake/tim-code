
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
	OrderID int not null primary key identity(1,1)
	, LocationID int not null -- FK references Location
	, TotalValue float
	, OrderTime datetime2(3) not null
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
	, CrustID int not null -- FK references Crust
	, SauceID int not null -- FK references Sauce
	, TotalPizzaCost float
	, OrderID int not null -- FK references Order
	, ModifiedDate datetime2(3) not null
	, Active bit not null default(1)
);

-- drop table PizzaStore.Crust;
create table PizzaStore.Crust
(
	CrustID int not null primary key identity(1,1)
	, Crust varchar(20) not null
	, CrustCost float not null
	, ModifiedDate datetime2(3) not null
	, Active bit not null default(1)
);

-- drop table PizzaStore.Sauce;
create table PizzaStore.Sauce
(
	SauceID int not null primary key identity(1,1)
	, Sauce varchar(20) not null
	, SauceCost float not null
	, ModifiedDate datetime2(3) not null
	, Active bit not null default(1)
);

-- drop table PizzaStore.Cheese;
create table PizzaStore.Cheese
(
	CheeseID int not null primary key identity(1,1)
	, Cheese varchar(20) not null
	, CheeseCost float not null
	, ModifiedDate datetime2(3) not null
	, Active bit not null default(1)
);

-- drop table PizzaStore.Topping;
create table PizzaStore.Topping
(
	ToppingID int not null primary key identity(1,1)
	, Topping varchar(10) not null
	, ToppingCost float not null
	, ModifiedDate datetime2(3) not null
	, Active bit not null default(1)
);


create table PizzaStore.PizzaHasCheese -- Pizza can have more than one cheese
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
	, Sauce_Tomato_Count int not null
	, Sauce_Pesto_Count int not null
	, Cheese_Mozzarella_Count int not null
	, Cheese_Cheddar_Count int not null
	, Cheese_Colby_Count int not null
	, Topping_Pepperoni_Count int not null
	, Topping_Onion_Count int not null
	, Topping_GreenPepper_Count int not null
	, Topping_Meatball_Count int not null
	, Topping_Mushroom_Count int not null
);

----------------------------------------------------------------------------------


-- ALTER Foreign Keys

-- Foreign keys for order table
alter table PizzaStore.[Order]
	add constraint FK_Order_Location foreign key (LocationID) references PizzaStore.[Location](LocationID)
	on update cascade;

alter table PizzaStore.[Order]
	add constraint FK_Order_Customer foreign key (CustomerID) references PizzaStore.Customer(CustomerID)
	on update cascade;

-- Foreign keys for location table
alter table PizzaStore.[Location]
	add constraint FK_Location_Address foreign key (AddressID) references PizzaStore.[Address](AddressID)
	on update cascade;

alter table PizzaStore.[Location]
	add constraint FK_Location_Inventory foreign key (InventoryID) references PizzaStore.Inventory(InventoryID)
	on update cascade;

-- Foreign keys for customer table
alter table PizzaStore.Customer
	add constraint FK_Customer_Address foreign key (AddressID) references PizzaStore.[Address](AddressID)
	on update no action;

-- Foreign keys for pizza table
alter table PizzaStore.Pizza
	add constraint FK_Pizza_Crust foreign key (CrustID) references PizzaStore.Crust(CrustID)
	on update no action;

alter table PizzaStore.Pizza
	add constraint FK_Pizza_Sauce foreign key (SauceID) references PizzaStore.Sauce(SauceID)
	on update no action;

alter table PizzaStore.Pizza
	add constraint FK_Pizza_Order foreign key (OrderID) references PizzaStore.[Order](OrderID)
	on update no action;

-- Foreign keys for PizzaHasCheese table
alter table PizzaStore.PizzaHasCheese
	add constraint FK_PizzaHasCheese_Pizza foreign key (PizzaID) references PizzaStore.Pizza(PizzaID)
	on update no action;

alter table PizzaStore.PizzaHasCheese
	add constraint FK_PizzaHasCheese_Cheese foreign key (CheeseID) references PizzaStore.Cheese(CheeseID)
	on update no action;

-- Foreign keys for PizzaHasCheese table
alter table PizzaStore.PizzaHasTopping
	add constraint FK_PizzaHasTopping_Pizza foreign key (PizzaID) references PizzaStore.Pizza(PizzaID)
	on update no action;

alter table PizzaStore.PizzaHasTopping
	add constraint FK_PizzaHasTopping_Topping foreign key (ToppingID) references PizzaStore.Topping(ToppingID)
	on update no action;

/*
alter table PizzaStore.Inventory
	drop column LocationID
*/
----------------------------------------------------------------------------------

/*
-- drop all constraints
alter table PizzaStore.[Order]
	drop constraint FK_Order_Location;

alter table PizzaStore.[Order]
	drop constraint FK_Order_Customer;

-- Foreign keys for location table
alter table PizzaStore.[Location]
	drop constraint FK_Location_Address;

alter table PizzaStore.[Location]
	drop constraint FK_Location_Inventory;

-- Foreign keys for customer table
alter table PizzaStore.Customer
	drop constraint FK_Customer_Address;

-- Foreign keys for pizza table
alter table PizzaStore.Pizza
	drop constraint FK_Pizza_Crust;

alter table PizzaStore.Pizza
	drop constraint FK_Pizza_Sauce;

--alter table PizzaStore.Pizza drop constraint FK_Pizza_Order;
alter table PizzaStore.Pizza
	drop constraint FK_Pizza_Order;

-- Foreign keys for PizzaHasCheese table
alter table PizzaStore.PizzaHasCheese
	drop constraint FK_PizzaHasCheese_Pizza;

alter table PizzaStore.PizzaHasCheese
	drop constraint FK_PizzaHasCheese_Cheese;

-- Foreign keys for PizzaHasCheese table
alter table PizzaStore.PizzaHasTopping
	drop constraint FK_PizzaHasTopping_Pizza;

alter table PizzaStore.PizzaHasTopping
	drop constraint FK_PizzaHasTopping_Topping;

	*/

----------------------------------------------------------------------------------
-- Drop Schema
/*
drop table PizzaStore.[Address];
drop table PizzaStore.[Cheese];
drop table PizzaStore.Crust;
drop table PizzaStore.Customer;
drop table PizzaStore.Inventory;
drop table PizzaStore.[Location];
drop table PizzaStore.[Order];
drop table PizzaStore.Pizza;
drop table PizzaStore.PizzaHasCheese;
drop table PizzaStore.PizzaHasTopping;
drop table PizzaStore.Sauce;
drop table PizzaStore.Topping;

drop schema PizzaStore;
*/





