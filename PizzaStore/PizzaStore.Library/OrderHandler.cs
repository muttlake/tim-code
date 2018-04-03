using PizzaStore.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaStore.Library
{
    public class OrderHandler
    {
        public int CustomerID { get; set; }
        public int LocationID { get; set; }
        public int OrderID { get; set; }
        public double TotalOrderValue { get; set; }
        public List<Pizza2> Pizzas { get; set; }

        public OrderHandler(int custID, int locID)
        {
            CustomerID = custID;
            LocationID = locID;
            Pizzas = new List<Pizza2>();
            TotalOrderValue = 0.00;
        }
    }
}
