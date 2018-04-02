using System;
using System.Collections.Generic;
using System.Linq;
using PizzaStore.Data;

namespace PizzaStore.Library
{
    public class InventoryChecker
    {
        private PizzaStoreContext dbContext = new PizzaStoreContext();
        public int InventoryID { get; set; }

        public InventoryChecker(int locID)
	    {
            InventoryID = dbContext.Location.Where(p => p.LocationId == locID).FirstOrDefault().InventoryId;
	    }

        public bool checkInventory(int crustID, int sauceID, List<int> cheeseIDs, List<int> toppingIDs, int pizzaQuantity)
        {
            bool crustsAvailable = CheckCrustAvailability(crustID, pizzaQuantity);
            bool saucesAvailable = CheckSauceAvailability(sauceID, pizzaQuantity);
            bool cheesesAvailable = true;
            foreach (var id in cheeseIDs)
            {
                if (!CheckCheeseAvailability(id, pizzaQuantity))
                    cheesesAvailable = false;
            }
            bool toppingsAvailable = true;
            foreach (var id in toppingIDs)
            {
                if (!CheckToppingAvailability(id, pizzaQuantity))
                    toppingsAvailable = false;
            }

            return crustsAvailable && saucesAvailable && cheesesAvailable && toppingsAvailable;
        }



        public bool CheckCrustAvailability(int CrustID, int amountDesired)
        {
            string crustName = dbContext.Crust.Where(p => p.CrustId == CrustID).FirstOrDefault().Crust1;
            int inventoryCount = 0;
            if (crustName == "Thin")
                inventoryCount = dbContext.Inventory.Where(p => p.InventoryId == InventoryID).FirstOrDefault().CrustThinCount;
            else if (crustName == "HandTossed")
                inventoryCount = dbContext.Inventory.Where(p => p.InventoryId == InventoryID).FirstOrDefault().CrustHandTossedCount;
            else if (crustName == "Thick")
                inventoryCount = dbContext.Inventory.Where(p => p.InventoryId == InventoryID).FirstOrDefault().CrustThickCount;

            return amountDesired <= inventoryCount;
        }

        public bool CheckSauceAvailability(int SauceID, int amountDesired)
        {
            string sauceName = dbContext.Sauce.Where(p => p.SauceId == SauceID).FirstOrDefault().Sauce1;
            int inventoryCount = 0;
            if (sauceName == "Tomato")
                inventoryCount = dbContext.Inventory.Where(p => p.InventoryId == InventoryID).FirstOrDefault().SauceTomatoCount;
            else if (sauceName == "Pesto")
                inventoryCount = dbContext.Inventory.Where(p => p.InventoryId == InventoryID).FirstOrDefault().SaucePestoCount;

            return amountDesired <= inventoryCount;
        }


        public bool CheckCheeseAvailability(int CheeseID, int amountDesired)
        {
            string cheeseName = dbContext.Cheese.Where(p => p.CheeseId == CheeseID).FirstOrDefault().Cheese1;
            int inventoryCount = 0;
            if (cheeseName == "Mozzarella")
                inventoryCount = dbContext.Inventory.Where(p => p.InventoryId == InventoryID).FirstOrDefault().CheeseMozzarellaCount;
            else if (cheeseName == "Colby")
                inventoryCount = dbContext.Inventory.Where(p => p.InventoryId == InventoryID).FirstOrDefault().CheeseColbyCount;
            else if (cheeseName == "Cheddar")
                inventoryCount = dbContext.Inventory.Where(p => p.InventoryId == InventoryID).FirstOrDefault().CheeseCheddarCount;

            return amountDesired <= inventoryCount;
        }

        public bool CheckToppingAvailability(int ToppingID, int amountDesired)
        {
            string toppingName = dbContext.Topping.Where(p => p.ToppingId == ToppingID).FirstOrDefault().Topping1;
            int inventoryCount = 0;
            if (toppingName == "Pepperoni")
                inventoryCount = dbContext.Inventory.Where(p => p.InventoryId == InventoryID).FirstOrDefault().ToppingPepperoniCount;
            else if (toppingName == "Green Pepper")
                inventoryCount = dbContext.Inventory.Where(p => p.InventoryId == InventoryID).FirstOrDefault().ToppingGreenPepperCount;
            else if (toppingName == "Onion")
                inventoryCount = dbContext.Inventory.Where(p => p.InventoryId == InventoryID).FirstOrDefault().ToppingOnionCount;
            else if (toppingName == "Meatball")
                inventoryCount = dbContext.Inventory.Where(p => p.InventoryId == InventoryID).FirstOrDefault().ToppingMeatballCount;
            else if (toppingName == "Mushroom")
                inventoryCount = dbContext.Inventory.Where(p => p.InventoryId == InventoryID).FirstOrDefault().ToppingMushroomCount;

            return amountDesired <= inventoryCount;
        }
    }
}
