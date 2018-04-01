using System;
using System.Collections.Generic;
using System.Linq;
using PizzaStore.Data;

namespace PizzaStore.Library
{
    public class AddAdditionalPizza
    {
        private PizzaStoreContext dbContext = new PizzaStoreContext();

        public Pizza Pizza { get; set; }

        public AddAdditionalPizza()
        {
        }

        public bool AddPizzaToOrder(int orderId, int crustId, int sauceId, List<int> cheeseIds, List<int> toppingIds)
        {
            double cheeseAndToppingCost = 0.00;
            if (CreateBarePizza(crustId, sauceId, orderId))
            {
                cheeseAndToppingCost += AddCheeses(cheeseIds);
                cheeseAndToppingCost += AddToppings(toppingIds);
                double currentPizzaPrice = dbContext.Pizza.Where(p => p.PizzaId == Pizza.PizzaId).FirstOrDefault().TotalPizzaCost.Value;
                currentPizzaPrice += cheeseAndToppingCost;
                dbContext.Pizza.Where(p => p.PizzaId == Pizza.PizzaId).FirstOrDefault().TotalPizzaCost = currentPizzaPrice;
                dbContext.SaveChanges();
                return true;
            }
            return false;
        }


        public bool CreateBarePizza(int crustId, int sauceId, int orderID)
        {
            if (ValidateOrder(orderID) && ValidateCrust(crustId) && ValidateSauce(sauceId))
            {
                Pizza = new Pizza();
                Pizza.OrderId = orderID;
                Pizza.CrustId = crustId;
                Pizza.SauceId = sauceId;
                Pizza.TotalPizzaCost = 0.00;
                Pizza.ModifiedDate = System.DateTime.Now;

                double crustCost = dbContext.Crust.Where(p => p.CrustId == crustId).FirstOrDefault().CrustCost;
                double sauceCost = dbContext.Sauce.Where(p => p.SauceId == sauceId).FirstOrDefault().SauceCost;

                Pizza.TotalPizzaCost = crustCost + sauceCost;

                dbContext.Pizza.Add(Pizza);
                dbContext.SaveChanges();

                Console.WriteLine("Added Pizza: {0} to Order: {1}", Pizza.PizzaId, orderID);

                return true;
            }
            return false;
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

        public double AddCheeses(List<int> cheeseIds)
        {
            int numCheeses = Math.Min(cheeseIds.Count, 2); //Fix with json file should not be hardcoded
            List<int> cheesesAddedAlready = new List<int>();
            int numCheesesAdded = 0;
            double totalCheeseCost = 0.00;
            for (int i = 0; i < numCheeses; i++)
            {
                if (ValidateCheese(cheeseIds[i]) && !cheesesAddedAlready.Contains(cheeseIds[i]))
                {
                    cheesesAddedAlready.Add(cheeseIds[i]);
                    PizzaHasCheese pizzaHasCheese = new PizzaHasCheese();
                    pizzaHasCheese.CheeseId = cheeseIds[i];
                    pizzaHasCheese.PizzaId = Pizza.PizzaId;
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
                if (ValidateTopping(toppingIds[i]) && !toppingsAddedAlready.Contains(toppingIds[i]))
                {
                    toppingsAddedAlready.Add(toppingIds[i]);
                    PizzaHasTopping pizzaHasTopping = new PizzaHasTopping();
                    pizzaHasTopping.ToppingId = toppingIds[i];
                    pizzaHasTopping.PizzaId = Pizza.PizzaId;
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
    }
}
