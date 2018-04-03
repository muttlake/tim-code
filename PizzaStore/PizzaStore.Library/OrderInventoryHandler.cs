using PizzaStore.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaStore.Library
{
    class OrderInventoryHandler
    {
        public OrderHandler Oh { get; set; }

        public OrderInventoryHandler(OrderHandler oh)
        {
            Oh = oh;
        }

        public bool GetInventorySufficiency()
        {
            InventoryChecker ic = new InventoryChecker(Oh.LocationID);
            bool sufficientInventory = true;

            foreach(var pizza in Oh.Pizzas) //This is actually an error
            {
                sufficientInventory = ic.checkInventory(pizza.CrustId, pizza.SauceId.Value, GetCheeseIDs(pizza), GetToppingIDs(pizza), pizza.Quantity);
                if (!sufficientInventory)
                    return false;
            }
            return true;
        }

        private List<int> GetCheeseIDs(Pizza2 pizza)
        {
            List<int> cheeseIDs = new List<int>();

            if (pizza.Cheese1 != null)
                cheeseIDs.Add(pizza.Cheese1.Value);
            if (pizza.Cheese2 != null)
                cheeseIDs.Add(pizza.Cheese2.Value);

            return cheeseIDs;
        }

        private List<int> GetToppingIDs(Pizza2 pizza)
        {
            List<int> toppingIDs = new List<int>();

            if (pizza.Topping1 != null)
                toppingIDs.Add(pizza.Topping1.Value);
            if (pizza.Topping2 != null)
                toppingIDs.Add(pizza.Topping2.Value);
            if (pizza.Topping3 != null)
                toppingIDs.Add(pizza.Topping3.Value);

            return toppingIDs;
        }
    }
}
