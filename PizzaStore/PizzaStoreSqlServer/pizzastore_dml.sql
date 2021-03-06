
-- Pizza Store Definition

USE pizzastoredb;
GO

-- Make Crusts
-- delete PizzaStore.Crust;
delete PizzaStore.Crust where Crust = 'Fake';
INSERT INTO PizzaStore.Crust(Crust, CrustCost, ModifiedDate)
VALUES
('Thin', 9.00, getdate()),
('HandTossed', 9.00, getdate()),
('Thick', 9.00, getdate());
GO

select * from PizzaStore.Crust;

-- Make Cheeses
delete PizzaStore.Cheese;
INSERT INTO PizzaStore.Cheese(Cheese, CheeseCost, ModifiedDate)
VALUES
('Mozzarella', 1.00, getdate()),
('Colby', 1.00, getdate()),
('Cheddar', 1.00, getdate());
GO

select * from PizzaStore.Cheese;
GO

-- Make Toppings
delete PizzaStore.Topping;
alter table pizzastore.topping
	drop column topping;
alter table pizzastore.topping
	add Topping nvarchar(120);
INSERT INTO PizzaStore.Topping(Topping, ToppingCost, ModifiedDate)
VALUES
('Pepperoni', 1.00, getdate()),
('Green Pepper', 1.00, getdate()),
('Onion', 1.00, getdate()),
('Meatball', 1.00, getdate()),
('Mushroom', 1.00, getdate());
GO

select * from PizzaStore.Topping;

-- Make Sauces
delete PizzaStore.Sauce;
INSERT INTO PizzaStore.Sauce(Sauce, SauceCost, ModifiedDate)
VALUES
('Tomato', 1.00, getdate()),
('Pesto', 1.00, getdate());
GO

select * from PizzaStore.[State];

-- Make States
INSERT INTO PizzaStore.[State](StateAbb)
VALUES
('AL'),
('AK'),
('AZ'),
('AR'),
('CA'),
('CO'),
('CT'),
('DE'),
('FL'),
('GA'),
('HI'),
('ID'),
('IL'),
('IN'),
('IA'),
('KS'),
('KY'),
('LA'),
('ME'),
('MD'),
('MA'),
('MI'),
('MN'),
('MS'),
('MO'),
('MT'),
('NE'),
('NV'),
('NH'),
('NJ'),
('NM'),
('NY'),
('NC'),
('ND'),
('OH'),
('OK'),
('OR'),
('PA'),
('RI'),
('SC'),
('SD'),
('TN'),
('TX'),
('UT'),
('VT'),
('VA'),
('WA'),
('WV'),
('WI'),
('WY'),
('GU'),
('PR'),
('VI');
-- FL is number 9

/*
delete PizzaStore.[State]
where StateID > 53;
select * from PizzaStore.[State];
*/


-- Make Addresses
insert into PizzaStore.[Address](Street, City, StateID, ZipCode, ModifiedDate)
values
('17631 Bruce B Downs Blvd', 'Tampa', 9, '33647', getdate()),
('14917 Bruce B Downs Blvd', 'Tampa', 9, '33613', getdate()),
('9340 N Florida Ave', 'Tampa', 9, '33612', getdate()),
('4103 Fir Street', 'Tampa', 9, '33620', getdate()),
('3233 Cedar Circle', 'Tampa', 9, '33620', getdate()),
('2311 Nebraska Avenue', 'Tampa', 9, '33620', getdate()),
('143 Palm Shadow Way', 'Tampa', 9, '33620', getdate()),
('5543 W Tampa Palms', 'Tampa', 9, '33620', getdate());

select * from PizzaStore.[Address];

-- Make Inventories

insert into PizzaStore.Inventory(Crust_Thin_Count, Crust_HandTossed_Count, Crust_Thick_Count, Sauce_Tomato_Count, Sauce_Pesto_Count, Cheese_Mozzarella_Count, Cheese_Cheddar_Count, Cheese_Colby_Count, Topping_Pepperoni_Count, Topping_Onion_Count, Topping_GreenPepper_Count, Topping_Meatball_Count, Topping_Mushroom_Count)
values
(1000, 1000, 1000, 1000, 1000, 1000, 1000, 1000, 1000, 1000, 1000, 1000, 1000),
(1000, 1000, 1000, 1000, 1000, 1000, 1000, 1000, 1000, 1000, 1000, 1000, 1000),
(1000, 1000, 1000, 1000, 1000, 1000, 1000, 1000, 1000, 1000, 1000, 1000, 1000);

select * from PizzaStore.Inventory;

-- Make Locations
insert into PizzaStore.[Location](AddressID, InventoryID, ModifiedDate)
values
(1, 1, getdate()),
(2, 2, getdate()),
(3, 3, getdate());

select * from PizzaStore.[Location];

select * from PizzaStore.[Address];



-- Make Customers
insert into PizzaStore.Customer(FirstName, LastName, AddressID, Phone, Email, ModifiedDate)
values
('Jerry', 'West', 4, '2222222222', 'jerrywest@email.com', getdate()),
('Michael', 'Jordan', 5, '2222222222', 'mj@email.com', getdate()),
('LeBron', 'James', 6, '2222222222', 'lj@email.com', getdate()),
('Stephen', 'Curry', 7, '2222222222', 'sc@email.com', getdate());

select * from PizzaStore.Customer;


-- Making Orders from C#
select * from PizzaStore.Cheese;
select * from PizzaStore.Pizza;

select * from PizzaStore.Sauce;


select FirstName, LastName, OrderID
from PizzaStore.[Order] as ord
inner join
(
	select CustomerID, FirstName, LastName
	From PizzaStore.Customer
) as cust on cust.CustomerID = ord.CustomerID;


Select FirstName, LastName, Email, ord.OrderId, pizza.TotalPizzaCost, crust.Crust, sauce.Sauce, ord.OrderTime, Loc.LocationID, addr.Street, addr.City, addr.ZipCode, cheese.Cheese, topping.Topping
from PizzaStore.Pizza as pizza
inner join
(
	select *
	from PizzaStore.[Order]
) as ord on pizza.OrderID = ord.OrderID
inner join
(
	select *
	from PizzaStore.Customer
) as cust on ord.CustomerID = cust.CustomerID
inner join
(
	select *
	from PizzaStore.[Location]
) as loc on loc.LocationID = ord.LocationID
inner join
(
	select *
	from PizzaStore.[Address]
) as addr on addr.AddressID = loc.AddressID
left join
(
	select *
	from PizzaStore.Crust
) as crust on pizza.CrustID = crust.CrustID
left join
(
	select * 
	from PizzaStore.Sauce
) as sauce on pizza.SauceID = sauce.SauceID
left join
(
	select *
	from PizzaStore.PizzaHasCheese
) as pizzaCheese on pizzaCheese.PizzaID = pizza.PizzaID
left join
(
	select *
	from PizzaStore.Cheese
) as cheese on pizzaCheese.CheeseID = cheese.CheeseID
left join
(
	select *
	from PizzaStore.PizzaHasTopping
) as pizzaTopping on pizzaTopping.PizzaID = pizza.PizzaID
left join
(
	select *
	from PizzaStore.Topping
) as topping on topping.ToppingID = pizzaTopping.ToppingID;





select ord.OrderID, ord.LocationID, ord.CustomerID, (customer.FirstName + ' ' + customer.LastName) as CustomerName,ord.OrderTime, ord.TotalValue, pizza.PizzaID, pizza.TotalPizzaCost, crust.Crust, sauce.Sauce,
       (addr.Street + ', ' + addr.City + ', ' + stat.StateAbb + ', ' + addr.ZipCode) as [Address], cheese.Cheese, topping.Topping
from PizzaStore.[Order] as ord
inner join
PizzaStore.Pizza as pizza
on pizza.OrderID = ord.OrderID
inner join 
PizzaStore.Crust as crust
on crust.CrustID = pizza.CrustID
inner join
PizzaStore.Sauce as sauce
on sauce.SauceID = pizza.SauceID
inner join
PizzaStore.[Location] as loc
on loc.LocationID = ord.LocationID
inner join
PizzaStore.[Address] as addr
on addr.AddressID = loc.AddressID
inner join
PizzaStore.[State] as stat
on stat.StateID = addr.StateID
inner join
PizzaStore.PizzaHasCheese as pizzaCheese
on  pizzaCheese.PizzaID = pizza.PizzaID
inner join
PizzaStore.Cheese as cheese
on cheese.CheeseID = pizzaCheese.CheeseID
inner join
PizzaStore.PizzaHasTopping as pizzaTopping
on pizzaTopping.PizzaID = pizza.PizzaID
inner join
PizzaStore.Topping as topping
on pizzaTopping.ToppingID = topping.ToppingID
inner join
PizzaStore.Customer as customer
on customer.CustomerID = ord.CustomerID
where ord.OrderID = 23;


select * 
from PizzaStore.[Location] as loc
inner join
(
	select *
	from PizzaStore.[Address]
) as addr on Loc.AddressID = addr.AddressID;





select * from PizzaStore.Cheese;
select * from PizzaStore.Crust;
select * from PizzaStore.Sauce;
select * from PizzaStore.Topping;



select * from PizzaStore.Customer;
select * from PizzaStore.[Order]
where OrderID = 14;



select * from PizzaStore.[Location];
select * from PizzaStore.Inventory;

update PizzaStore.Inventory
set Crust_Thick_Count = 0
Where InventoryID = 1;



select *
from PizzaStore.vw_AllOrderInformation;

select *
from PizzaStore.vw_AllOrderInformation
where CustomerId = 2;


select * from PizzaStore.Crust;

update PizzaStore.[Order]
set Active = 0;


 

insert into PizzaStore.Customer(FirstName, LastName, AddressID, Phone, Email, ModifiedDate)
values
('Test5', 'Test5', 5, '2222222222', 't5@email.com', getdate());

insert into PizzaStore.Customer(FirstName, LastName, AddressID, Phone, Email, ModifiedDate)
values
('test88', 'test88', 5, '2222222222', 't55@email.com', getdate()),
('test99', 'test99', 5, '2222222222', 't66@email.com', getdate());



select * from PizzaStore.Pizza2;


select * from PizzaStore.[Order];


select * from PizzaStore.Inventory;



USE pizzastoredb;
GO

select *  from PizzaStore.[Location]


--delete
--from PizzaStore.[Location]
--Where LocationID > 3;


select * from PizzaStore.Cheese;

delete 
from PizzaStore.Cheese
WHere CheeseID > 3;


