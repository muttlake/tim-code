using System;
using System.Collections.Generic;
using System.Linq;
using PizzaStore.Data;

namespace PizzaStore.Library
{
    class PizzaOrderInfo
    {
        public int CrustID { get; set; }
        public int SauceID { get; set; }
        public int PizzaQuantity { get; set; }
        public List<int> cheeseIDs { get; set; }
        public List<int> toppingIDs { get; set; }
    }

    public class CopyAnOrder
    {
        private readonly PizzaStoreContext dbContext = new PizzaStoreContext();
        private List<PizzaOrderInfo> pizzasOrderedInfo { get; set; }
        private List<int> pizzaQuantities { get; set; }

        public int OrderID { get; set; }
        public DateTime NewOrderTime { get; set; }


        public CopyAnOrder(int orderID, DateTime d)
        {
            OrderID = orderID;
            NewOrderTime = d;
            GetPizzaQuantities();
        }

        private List<Pizza> GetPizzasInOrder()
        {
            var ef = new EfData();
            return ef.GetPizzasForOrder(OrderID);
        }

        private void GetPizzasOrderedInfo()
        {
            pizzasOrderedInfo = new List<PizzaOrderInfo>();
            var ef = new EfData();

            int count = 0;
            foreach(var pizza in GetPizzasInOrder())
            {
                var poi = new PizzaOrderInfo();
                poi.CrustID = pizza.CrustId;
                poi.SauceID = pizza.SauceId;
                poi.cheeseIDs = ef.GetListCheesesByPizzaID(pizza.PizzaId).Select(p => p.CheeseId).ToList();
                poi.toppingIDs = ef.GetListCheesesByPizzaID(pizza.PizzaId).Select(p => p.CheeseId).ToList();
                poi.PizzaQuantity = pizzaQuantities.ElementAt(count);
                count += 1;
            }

        }

        private void GetPizzaQuantities()
        {
            var ef = new EfData();
            pizzaQuantities = new List<int>();

            List<int> pizzaIDs = ef.GetAllPizzaIDsForOrder(OrderID);
            int count = 0;
            string lastPizzaString = ef.GetPizzaStringByPizzaID(pizzaIDs.ElementAt(0));

            for (int i = 0; i < pizzaIDs.Count; i++)
            {
                string newPizzaString = ef.GetPizzaStringByPizzaID(pizzaIDs.ElementAt(i));
                if (!newPizzaString.Equals(lastPizzaString))
                {
                    pizzaQuantities.Add(count);
                    lastPizzaString = newPizzaString;
                    count = 1;
                }
                else
                    count += 1;

                if (i == pizzaIDs.Count - 1)
                    pizzaQuantities.Add(count);
            }
        }





//        var completeOrder = new CompleteOrderViewModel(custID, locID, crustID, sauceID, cheeseIDs, toppingIDs, pq);

//        double totalOrderCost = completeOrder.TotalOrderCost();

//            if (totalOrderCost > 1000)
//            {
//                Console.WriteLine("totalOrderCost exceeds 1000");
//                HttpContext.Session.SetInt32("CostOfOrder", (int) totalOrderCost);
//                return RedirectToAction("Index", "Pizza");
//        }
//        //Check inventory availability here
//        InventoryChecker ic = new InventoryChecker(locID);
//                if(!ic.checkInventory(crustID, sauceID, cheeseIDs, toppingIDs, pq))
//                {
//                    Console.WriteLine("Inventory not sufficient");
//                    ViewBag.PizzaProblem = "The Store does not have enough inventory to complete that order.";
//                    return RedirectToAction("Index", "Pizza");
//`````}



//            return View(completeOrder);

    }
}
