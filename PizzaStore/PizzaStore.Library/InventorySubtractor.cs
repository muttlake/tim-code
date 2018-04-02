using System;
using System.Collections.Generic;
using System.Linq;
using PizzaStore.Data;

namespace PizzaStore.Library
{
    public class InventorySubtractor
    {
        private PizzaStoreContext dbContext = new PizzaStoreContext();
        public int InventoryID { get; set; }

        public InventorySubtractor(int locID)
    	{	
            InventoryID = dbContext.Location.Where(p => p.LocationId == locID).FirstOrDefault().InventoryId;
	    }

        public void SubtractInventory(int crustID, int sauceID, List<int> cheeseIDs, List<int> toppingIDs, int pizzaQuantity)
        {
            SubtractCrusts(crustID, pizzaQuantity);
            SubtractSauces(sauceID, pizzaQuantity);
            foreach (var id in cheeseIDs)
                SubtractCheese(id, pizzaQuantity);
            foreach (var id in toppingIDs)
                SubtractTopping(id, pizzaQuantity);
            dbContext.SaveChanges();
        }

        public void SubtractCrusts(int crustID, int amount)
        {
            string crustName = dbContext.Crust.Where(p => p.CrustId == crustID).FirstOrDefault().Crust1;
            if (crustName == "Thin")
                dbContext.Inventory.Where(p => p.InventoryId == InventoryID).FirstOrDefault().CrustThinCount -= amount;
            else if (crustName == "HandTossed")
                dbContext.Inventory.Where(p => p.InventoryId == InventoryID).FirstOrDefault().CrustHandTossedCount -= amount;
            else if (crustName == "Thick")
                dbContext.Inventory.Where(p => p.InventoryId == InventoryID).FirstOrDefault().CrustThickCount -= amount;
        }

        public void SubtractSauces(int sauceID, int amount)
        {
            string sauceName = dbContext.Sauce.Where(p => p.SauceId == sauceID).FirstOrDefault().Sauce1;
            if (sauceName == "Tomato")
                dbContext.Inventory.Where(p => p.InventoryId == InventoryID).FirstOrDefault().SauceTomatoCount -= amount;
            else if (sauceName == "Pesto")
                dbContext.Inventory.Where(p => p.InventoryId == InventoryID).FirstOrDefault().SaucePestoCount -= amount;
        }

        public void SubtractCheese(int cheeseID, int amount)
        {
            string cheeseName = dbContext.Cheese.Where(p => p.CheeseId == cheeseID).FirstOrDefault().Cheese1;
            if (cheeseName == "Mozzarella")
                dbContext.Inventory.Where(p => p.InventoryId == InventoryID).FirstOrDefault().CheeseMozzarellaCount -= amount;
            else if (cheeseName == "Colby")
                dbContext.Inventory.Where(p => p.InventoryId == InventoryID).FirstOrDefault().CheeseColbyCount -= amount;
            else if (cheeseName == "Cheddar")
                dbContext.Inventory.Where(p => p.InventoryId == InventoryID).FirstOrDefault().CheeseCheddarCount -= amount;
        }

        public void SubtractTopping(int toppingID, int amount)
        {
            string toppingName = dbContext.Topping.Where(p => p.ToppingId == toppingID).FirstOrDefault().Topping1;
            if (toppingName == "Pepperoni")
                dbContext.Inventory.Where(p => p.InventoryId == InventoryID).FirstOrDefault().ToppingPepperoniCount -= amount;
            else if (toppingName == "Green Pepper")
                dbContext.Inventory.Where(p => p.InventoryId == InventoryID).FirstOrDefault().ToppingGreenPepperCount -= amount;
            else if (toppingName == "Onion")
                dbContext.Inventory.Where(p => p.InventoryId == InventoryID).FirstOrDefault().ToppingOnionCount -= amount;
            else if (toppingName == "Meatball")
                dbContext.Inventory.Where(p => p.InventoryId == InventoryID).FirstOrDefault().ToppingMeatballCount -= amount;
            else if (toppingName == "Mushroom")
                dbContext.Inventory.Where(p => p.InventoryId == InventoryID).FirstOrDefault().ToppingMushroomCount -= amount;
        }

    }
}
