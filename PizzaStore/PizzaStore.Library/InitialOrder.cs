using System;
using System.Collections.Generic;
using System.Linq;
using PizzaStore.Data;

namespace PizzaStore.Library
{
    public class InitialOrder
    {
        private PizzaStoreContext dbContext = new PizzaStoreContext();
        public Order Order { get; set; }
        public Pizza BarePizza { get; set; }

        public bool ValidateLocation(int locID)
        {
            return dbContext.Location.Where(predicate: p => p.LocationId == locID).Count() == 1;
        }

        public bool ValidateCustomer(int locID)
        {
            return dbContext.Customer.Where(predicate: p => p.CustomerId == locID).Count() == 1;
        }

        public bool CreateInitialOrder(int locID, int custID)
        {
            if(ValidateCustomer(custID) && ValidateLocation(locID))
            {
                Order = new Order();
                Order.LocationId = locID;
                Order.TotalValue = 0.00;
                Order.OrderTime = System.DateTime.Now;
                Order.CustomerId = custID;
                Order.ModifiedDate = System.DateTime.Now;
                dbContext.Order.Add(Order);
                dbContext.SaveChanges();
                Console.WriteLine("Added Order: {0}", Order.OrderId);
                return true;
            }
            else
                return false;
        }

        

        public bool CreateBarePizza(int crustId, int sauceId, int orderID)
        {
            if(ValidateOrder(orderID) && ValidateCrust(crustId) && ValidateSauce(sauceId))
            {  
                BarePizza = new Pizza();
                BarePizza.OrderId = orderID;
                BarePizza.CrustId = crustId;
                BarePizza.SauceId = sauceId;
                BarePizza.TotalPizzaCost = 0.00;
                BarePizza.ModifiedDate = System.DateTime.Now;

                double crustCost = dbContext.Crust.Where(p => p.CrustId == crustId).FirstOrDefault().CrustCost;
                double sauceCost = dbContext.Sauce.Where(p => p.SauceId == sauceId).FirstOrDefault().SauceCost;

                BarePizza.TotalPizzaCost = crustCost + sauceCost;

                dbContext.Pizza.Add(BarePizza);
                dbContext.SaveChanges();

                Console.WriteLine("Added Pizza: {0} to Order: {1}", BarePizza.PizzaId, orderID);

                return true;
            }
            return false;
        }

        public bool CreateNewOrderWithBarePizza(int locID, int custID, int crustId, int sauceId)
        {
            if (CreateInitialOrder(locID, custID))
            {
                if(CreateBarePizza(crustId, sauceId, Order.OrderId))
                {
                    Console.WriteLine("Created Valid Order and Bare Pizza.");
                    return true;
                }
                else
                {
                    dbContext.Order.Where(p => p.OrderId == Order.OrderId).FirstOrDefault().Active = false; //Deactivate Order
                    dbContext.SaveChanges();
                    Console.WriteLine("Invalid Pizza.");
                    return false;
                }
            }
            else
            {
                Console.WriteLine("Invalid Order.");
                return false;
            }
        }



        public bool ValidateOrder(int orderId)
        {
            return dbContext.Order.Where(predicate: p => p.OrderId == orderId).Count() == 1;
        }

        public bool ValidateCrust(int crustID)
        {
            return dbContext.Crust.Where(predicate: p => p.CrustId == crustID).Count() == 1;
        }

        public bool ValidateSauce(int sauceId)
        {
            return dbContext.Sauce.Where(predicate: p => p.SauceId == sauceId).Count() == 1;
        }

        public bool CreateNewOrderWithSinglePizza(int locID, int custID, int crustId, int sauceId, List<int> cheeseIds, List<int> toppingIds)
        {
            double cheeseAndToppingCost = 0.00;
            if (CreateNewOrderWithBarePizza(locID, custID, crustId, sauceId))
            {
                cheeseAndToppingCost += AddCheeses(cheeseIds);
                cheeseAndToppingCost += AddToppings(toppingIds);
                double currentPizzaPrice = dbContext.Pizza.Where(p => p.PizzaId == BarePizza.PizzaId).FirstOrDefault().TotalPizzaCost.Value;
                currentPizzaPrice += cheeseAndToppingCost;
                dbContext.Pizza.Where(p => p.PizzaId == BarePizza.PizzaId).FirstOrDefault().TotalPizzaCost = currentPizzaPrice;
                dbContext.SaveChanges();
                return true;
            }
            return false;
        }

        public int GetOrderId()
        {
            return Order.OrderId;
        }

        

        public double AddCheeses(List<int> cheeseIds)
        {
            int numCheeses = Math.Min(cheeseIds.Count, 2); //Fix with json file should not be hardcoded
            List<int> cheesesAddedAlready = new List<int>();
            int numCheesesAdded = 0;
            double totalCheeseCost = 0.00;
            for(int i = 0; i < numCheeses; i++)
            {
                if(ValidateCheese(cheeseIds[i]) && !cheesesAddedAlready.Contains(cheeseIds[i]))
                {
                    cheesesAddedAlready.Add(cheeseIds[i]);
                    PizzaHasCheese pizzaHasCheese = new PizzaHasCheese();
                    pizzaHasCheese.CheeseId = cheeseIds[i];
                    pizzaHasCheese.PizzaId = BarePizza.PizzaId;
                    dbContext.PizzaHasCheese.Add(pizzaHasCheese);
                    dbContext.SaveChanges();

                    totalCheeseCost += dbContext.Cheese.Where(p => p.CheeseId == cheeseIds[i]).FirstOrDefault().CheeseCost;

                    Console.WriteLine("Added PizzaHasCheese with cheese {0} for pizza {1}", pizzaHasCheese.CheeseId, pizzaHasCheese.PizzaId);
                    numCheesesAdded += 1;
                }
            }
            Console.WriteLine("There were {0} cheeses added.", numCheesesAdded);
            return totalCheeseCost;
        }


        public double AddToppings(List<int> toppingIds)
        {
            int numToppings = Math.Min(toppingIds.Count, 3); //Fix with Json file, should not be hard-coded
            List<int> toppingsAddedAlready = new List<int>();
            int numToppingsAdded = 0;
            double totalToppingCost = 0.00;
            for (int i = 0; i < numToppings; i++)
            {
                if(ValidateTopping(toppingIds[i]) && !toppingsAddedAlready.Contains(toppingIds[i]))
                {
                    toppingsAddedAlready.Add(toppingIds[i]);
                    PizzaHasTopping pizzaHasTopping = new PizzaHasTopping();
                    pizzaHasTopping.ToppingId = toppingIds[i];
                    pizzaHasTopping.PizzaId = BarePizza.PizzaId;
                    dbContext.PizzaHasTopping.Add(pizzaHasTopping);
                    dbContext.SaveChanges();

                    totalToppingCost += dbContext.Topping.Where(p => p.ToppingId == toppingIds[i]).FirstOrDefault().ToppingCost;

                    Console.WriteLine("Added PizzaHasTopping with topping {0} for pizza {1}", pizzaHasTopping.ToppingId, pizzaHasTopping.PizzaId);
                    numToppingsAdded += 1;
                }
            }
            Console.WriteLine("There were {0} toppings added.", numToppingsAdded);
            return totalToppingCost;
        }

        public bool ValidateCheese(int cheeseID)
        {
            return dbContext.Cheese.Where(predicate: p => p.CheeseId == cheeseID).Count() == 1;
        }

        public bool ValidateTopping(int toppingID)
        {
            return dbContext.Topping.Where(predicate: p => p.ToppingId == toppingID).Count() == 1;
        }

        // public bool AssignOrder(int orderID)
        // {
        //     if(dbContext.Order.Where(predicate: p => p.OrderId == orderID).Count() != 1) //Invalid OrderID
        //         return false;
        //     Pizza.OrderId = orderID;
        //     return true;
        // }

        // public bool AddCrust(int crustID)
        // {
        //     if(dbContext.Crust.Where(predicate: p => p.CrustId == crustID).Count() != 1) //Invalid CrustID
        //         return false;
        //     Pizza.CrustId = crustID;
        //     PizzaPrice += dbContext.Crust.Where(p => p.CrustId == crustID).FirstOrDefault().CrustCost;
        //     return true;
        // }

        // public bool AddSauce(int sauceID)
        // {
        //     if(dbContext.Sauce.Where(predicate: p => p.SauceId == sauceID).Count() != 1) //Invalid SauceID
        //         return false;
        //     Pizza.SauceId = sauceID;
        //     PizzaPrice += dbContext.Sauce.Where(p => p.SauceId == sauceID).FirstOrDefault().SauceCost;
        //     return true;
        // }

    }
}