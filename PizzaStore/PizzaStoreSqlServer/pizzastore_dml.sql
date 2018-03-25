
-- Pizza Store Definition

USE adventureworksdb;
GO


-- Make Crusts
INSERT INTO PizzaStore.Crust(Crust, CrustCost, ModifiedDate)
VALUES('Thick', 9.00, getdate());
GO

select * from PizzaStore.Crust;

-- Make Cheeses
INSERT INTO PizzaStore.Cheese(Cheese, CheeseCost, ModifiedDate)
VALUES('Cheddar', 1.00, getdate());
GO

select * from PizzaStore.Cheese;
GO

-- Make Toppings
INSERT INTO PizzaStore.Topping(Topping, ToppingCost, ModifiedDate)
VALUES('Mushroom', 1.00, getdate());
GO

select * from PizzaStore.Topping;

-- Make Sauces
INSERT INTO PizzaStore.Sauce(Sauce, SauceCost, ModifiedDate)
VALUES('Pesto', 1.00, getdate());
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



