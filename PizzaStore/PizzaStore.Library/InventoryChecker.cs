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

        //int custID = HttpContext.Session.GetInt32("CustomerID").Value;
        //int locID = HttpContext.Session.GetInt32("LocationID").Value;
        //int crustID = HttpContext.Session.GetInt32("CrustID").Value;
        //int sauceID = HttpContext.Session.GetInt32("SauceID").Value;
        //int pq = HttpContext.Session.GetInt32("PizzaQuantity").Value;
        //List<int> cheeseIDs = ConvertSessionStringToList("CheeseIDs");
        //List<int> toppingIDs = ConvertSessionStringToList("ToppingIDs");

        public InventoryChecker(int inventoryID)
	    {
            InventoryID = inventoryID;
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

        //public bool CheckSauceAvailability(int SauceID, int amountDesired)
        //{
        //    string sauceName = dbContext.Crust.Where(p => p.CrustId == CrustID).FirstOrDefault().Crust1;
        //    int inventoryCount = 0;
        //    if (crustName == "Thin")
        //        inventoryCount = dbContext.Inventory.Where(p => p.InventoryId == InventoryID).FirstOrDefault().CrustThinCount;
        //    else if (crustName == "HandTossed")
        //        inventoryCount = dbContext.Inventory.Where(p => p.InventoryId == InventoryID).FirstOrDefault().CrustHandTossedCount;
        //    else if (crustName == "Thick")
        //        inventoryCount = dbContext.Inventory.Where(p => p.InventoryId == InventoryID).FirstOrDefault().CrustThickCount;

        //    return amountDesired <= inventoryCount;
        //}

    }
}
