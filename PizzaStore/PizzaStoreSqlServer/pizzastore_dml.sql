
-- Pizza Store Definition

USE adventureworksdb;
GO


-- Make Crusts
delete PizzaStore.Crust;
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



