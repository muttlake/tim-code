using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using PizzaStore.Library;
using PizzaStore.Data;

namespace PizzaStore.MVC.Models
{

    public class ReDoAnOrderViewModel
    {
        public int LocationID { get; set; }
        public int CustomerID { get; set; }
        public string CustomerName { get; set; }
        public PizzaOrder PreviousOrder { get; set; }
        public List<int> PizzaQuantities { get; set; }

        public Dictionary<int, string> ValidLocations { get; set; }

        public ReDoAnOrderViewModel(int id)
        {
            CustomerID = id;
            LocationID = -999;
            SetPizzaOrders();
        }

        public PizzaOrder GetPreviousOrder()
        {
            return PreviousOrder;
        }

        public void SetPizzaOrders()
        {
            var ef = new EfData();
            PizzaOrder po = new PizzaOrder();
            Order order = ef.GetMostRecentOrderForCustomer(CustomerID);
            po.OrderID = order.OrderId;

            po.CustomerName = ef.GetCustomerNameByID(CustomerID);
            po.OrderValue = order.TotalValue.Value;
            po.OrderTime = order.OrderTime;
            po.LocationString = ef.GetLocationByID(ef.GetLocationIDForOrder(po.OrderID));

            //po.PizzaStrings = new List<string>();
            //List<int> pizzaIDs = ef.GetAllPizzaIDsForOrder(po.OrderID);
            //int count = 0;
            //string lastPizzaString = ef.GetPizzaStringByPizzaID(pizzaIDs.ElementAt(0));

            //PizzaQuantities = new List<int>();

            //for (int i = 0; i < pizzaIDs.Count; i++)
            //{
            //    string newPizzaString = ef.GetPizzaStringByPizzaID(pizzaIDs.ElementAt(i));
            //    if (!newPizzaString.Equals(lastPizzaString))
            //    {
            //        po.PizzaStrings.Add(lastPizzaString + string.Format(", Quantity: {0}", count));
            //        lastPizzaString = newPizzaString;
            //        count = 1;
            //    }
            //    else
            //        count += 1;

            //    if (i == pizzaIDs.Count - 1)
            //        po.PizzaStrings.Add(newPizzaString + string.Format(", Quantity: {0}", count));
            //    PizzaQuantities.Add(count);
            //}
            PreviousOrder = po;
        }
    }
}

