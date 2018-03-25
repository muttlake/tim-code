
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

select * from PizzaStore.Sauce;

-- Make States



