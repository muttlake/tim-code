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
        private Order prevOrder { get; set; }

        public Dictionary<int, string> ValidLocations { get; set; }

        public ReDoAnOrderViewModel(int id)
        {
            CustomerID = id;
            LocationID = -999;

            var ef = new EfData();
            prevOrder = ef.GetMostRecentOrderForCustomer(CustomerID);
            LocationID = prevOrder.LocationId;
            SetPizzaOrder();
        }

        public int GetPQ()
        {
            var ef = new EfData();
            return ef.GetAllPizzaIDsForOrder(prevOrder.OrderId).Count;
        }

        public int GetSauceID()
        {
            var ef = new EfData();
            return ef.GetPizzasForOrder(prevOrder.OrderId).FirstOrDefault().SauceId;
        }

        public int GetCrustID()
        {
            var ef = new EfData();
            return ef.GetPizzasForOrder(prevOrder.OrderId).FirstOrDefault().CrustId;
        }

        public List<int> GetCheeseIDs()
        {
            var ef = new EfData();
            int firstPizza = ef.GetAllPizzaIDsForOrder(prevOrder.OrderId).FirstOrDefault();
            return ef.GetListCheesesByPizzaID(firstPizza).Select(p => p.CheeseId).ToList();
        }

        public string GetCheeseIDString()
        {
            string cheeseString = "";
            int count = 0;
            foreach (var cheeseID in GetCheeseIDs())
            {
                if (count == 0)
                    cheeseString += cheeseID.ToString();
                else
                    cheeseString += "," + cheeseID.ToString();
                count += 1;
            }
            Console.WriteLine("CheeseString: :" + cheeseString + ":");
            return cheeseString;
        }

        public string GetToppingIDString()
        {
            string toppingString = "";
            int count = 0;
            foreach (var toppingID in GetToppingIDs())
            {
                if (count == 0)
                    toppingString += toppingID.ToString();
                else
                    toppingString += "," + toppingID.ToString();
                count += 1;
            }
            return toppingString;
        }

        public List<int> GetToppingIDs()
        {
            var ef = new EfData();
            int firstPizza = ef.GetAllPizzaIDsForOrder(prevOrder.OrderId).FirstOrDefault();
            return ef.GetListToppingsByPizzaID(firstPizza).Select(p => p.ToppingId).ToList();
        }

        public void SetPizzaOrder()
        {
            var ef = new EfData();
            PizzaOrder po = new PizzaOrder();
            po.OrderID = prevOrder.OrderId;

            po.CustomerName = ef.GetCustomerNameByID(CustomerID);
            po.OrderValue = prevOrder.TotalValue.Value;
            po.OrderTime = prevOrder.OrderTime;
            po.LocationString = ef.GetLocationByID(ef.GetLocationIDForOrder(po.OrderID));
            int firstPizzaID = ef.GetAllPizzaIDsForOrder(po.OrderID).FirstOrDefault();
            //po.PizzaString = ef.GetPizzaStringByPizzaID(firstPizzaID);
            //po.PizzaString += string.Format(", Quantity: {0}", ef.GetAllPizzaIDsForOrder(po.OrderID).Count);

            PreviousOrder = po;
        }
    }
}

