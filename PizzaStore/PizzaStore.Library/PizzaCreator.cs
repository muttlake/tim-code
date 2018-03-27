

using System;
using System.Linq;
using PizzaStore.Data;

namespace PizzaStore.Library
{
    public class PizzaCreator
    {
        public Pizza Pizza { get; set; }
        public double PizzaPrice { get; set; }


        private int _pizzaID;

        private PizzaStoreContext dbContext = new PizzaStoreContext();


        public PizzaCreator()
        {
            Pizza = new Pizza();
            PizzaPrice = 0.00;
        }

        public bool AssignOrder(int orderID)
        {
            if(dbContext.Order.Where(predicate: p => p.OrderId == orderID).Count() != 1) //Invalid OrderID
                return false;
            Pizza.OrderId = orderID;
            return true;
        }

        public bool AddCrust(int crustID)
        {
            if(dbContext.Crust.Where(predicate: p => p.CrustId == crustID).Count() != 1) //Invalid CrustID
                return false;
            Pizza.CrustId = crustID;
            PizzaPrice += dbContext.Crust.Where(p => p.CrustId == crustID).FirstOrDefault().CrustCost;
            return true;
        }

        public bool AddSauce(int sauceID)
        {
            if(dbContext.Sauce.Where(predicate: p => p.SauceId == sauceID).Count() != 1) //Invalid SauceID
                return false;
            Pizza.SauceId = sauceID;
            PizzaPrice += dbContext.Sauce.Where(p => p.SauceId == sauceID).FirstOrDefault().SauceCost;
            return true;
        }

    }
}