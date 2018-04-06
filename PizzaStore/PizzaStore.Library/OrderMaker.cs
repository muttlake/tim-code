using PizzaStore.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PizzaStore.Library
{
    public class OrderMaker
    {
        private readonly PizzaStoreContext dbContext = new PizzaStoreContext();

        public OrderHandler Oh { get; set; }

        private Order order { get; set; }

        public OrderMaker(OrderHandler oh)
        {
            Oh = oh;
        }

        public bool MakeOrder()
        {
            if(MakeNewOrder())
            {
                AddPizzasToOrder(order.OrderId);
                return true;
            }
            else
                return false;
        }


        private bool MakeNewOrder()
        {
            var ef = new EfData();
            if (ef.ValidateCustomer(Oh.CustomerID) && ef.ValidateLocation(Oh.LocationID))
            {
                order = new Order();
                order.LocationId = Oh.LocationID;
                order.TotalValue = Oh.TotalOrderValue;
                order.OrderTime = System.DateTime.Now;
                order.CustomerId = Oh.CustomerID;
                order.ModifiedDate = System.DateTime.Now;
                dbContext.Order.Add(order);
                dbContext.SaveChanges();
                Console.WriteLine("Added Order: {0}", order.OrderId);
                return true;
            }
            else
                return false;
        }

        public void AddPizzasToOrder(int orderID)
        {
            foreach (var pizza in Oh.Pizzas)
                AddPizzaToOrder(pizza, orderID);
            dbContext.SaveChanges();
        }

        public void AddPizzaToOrder(Pizza2 pizza, int orderID)
        {
            pizza.OrderId = orderID;
            dbContext.Pizza2.Add(pizza);
        }
    }
}
