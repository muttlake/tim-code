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
    public class PizzaOrder
    {
        public int OrderID { get; set; }
        public string CustomerName { get; set; }
        public string LocationString { get; set; }
        public double OrderValue { get; set; }
        public DateTime OrderTime { get; set; }
        public List<string> PizzaStrings { get; set; }
    }


    public class OrderViewModel
    {

        [Required]
        public int LocationID { get; set; }
        public int CustomerID { get; set; }
        public string CustomerName { get; set; }
        public List<PizzaOrder> AllPizzaOrders { get; set; }

        public Dictionary<int, string> ValidLocations { get; set; }

        public OrderViewModel()
        {
            LocationID = -999;
            ValidLocations = GetLocations();
            SetPizzaOrders();
        }

        public OrderViewModel(int id)
        {
            LocationID = -999;
            CustomerID = id;
            SetPizzaOrders();

            if (HasPreviousOrders())
            {
                TwoHourChecker thc = new TwoHourChecker(CustomerID);
                if (thc.OrderedWithinTwoHours())
                    ValidLocations = GetLocations(thc.GetLastLocation());
                else
                    ValidLocations = GetLocations();
            }
            else
                ValidLocations = GetLocations();
        }

        private Dictionary<int, string> GetLocations(int loc)
        {
            EfData ef = new EfData();
            Dictionary<int, string> locationDict = new Dictionary<int, string>();
            Location location = ef.ReadLocations().Where(p => p.LocationId == loc).FirstOrDefault();

            string locString = "";
            locString += location.Address.Street;
            locString += ", " + location.Address.City;
            locString += ", " + location.Address.State.StateAbb;
            locString += ", " + location.Address.City;

            locationDict[location.LocationId] = locString;

            return locationDict;
        }

        private Dictionary<int, string> GetLocations()
        {
            EfData ef = new EfData();
            Dictionary<int, string> locationDict = new Dictionary<int, string>();
            foreach (var location in ef.ReadLocations())
            {
                string locString = "";
                locString += location.Address.Street;
                locString += ", " + location.Address.City;
                locString += ", " + location.Address.State.StateAbb;
                locString += ", " + location.Address.City;
                locationDict[location.LocationId] = locString;
            }
            return locationDict;
        }

        public bool HasPreviousOrders()
        {
            return AllPizzaOrders.Count > 0;
        }

        public PizzaOrder GetMostRecentOrder()
        {
            return AllPizzaOrders.ElementAt(AllPizzaOrders.Count - 1);
        }

        public List<PizzaOrder> GetPreviousOrders()
        {
            return AllPizzaOrders;
        }

        public void SetPizzaOrders()
        {
            var ef = new EfData();
            AllPizzaOrders = new List<PizzaOrder>();

            List<int> orderIDs = ef.GetOrderIdsForCustomer(CustomerID);
            foreach(int orderID in orderIDs)
            {
                PizzaOrder po = new PizzaOrder();
                po.OrderID = orderID;
                Console.WriteLine("Found previous order: {0}", orderID);
                Order order = ef.GetOrderById(orderID);
                po.CustomerName = ef.GetCustomerNameByID(CustomerID);
                po.OrderValue = order.TotalValue.Value;
                po.OrderTime = order.OrderTime;
                po.LocationString = ef.GetLocationByID(ef.GetLocationIDForOrder(orderID));
                po.PizzaStrings = GetAllPizzasInOrder(ef.GetPizza2sForOrder(orderID));

                AllPizzaOrders.Add(po);
            }
            Console.WriteLine("There are {0} total orders.", AllPizzaOrders.Count);
        }

        public List<string> GetAllPizzasInOrder(List<Pizza2> pizzas)
        {
            List<string> list = new List<string>();

            foreach (var pizza in pizzas)
            {
                list.Add(Pizza2String(pizza));
            }

            return list;
        }

        private string Pizza2String(Pizza2 pizza)
        {
            var ef = new EfData();
            string ps = "";
            ps += string.Format("${0}", pizza.TotalPizzaCost);
            ps += string.Format(", Crust: {0}", ef.GetCrustByID(pizza.CrustId));
            if (pizza.SauceId != null) { ps += string.Format(", Sauce: {0}", ef.GetSauceByID(pizza.SauceId.Value)); }
            if (pizza.Cheese1 != null) { ps += string.Format(", Cheeses: {0}", ef.GetCheeseByID(pizza.Cheese1.Value)); }
            if (pizza.Cheese2 != null) { ps += string.Format(", {0}", ef.GetCheeseByID(pizza.Cheese2.Value)); }
            if (pizza.Topping1 != null) { ps += string.Format(", Toppings: {0}", ef.GetToppingByID(pizza.Topping1.Value)); }
            if (pizza.Topping2 != null) { ps += string.Format(", {0}", ef.GetToppingByID(pizza.Topping2.Value)); }
            if (pizza.Topping3 != null) { ps += string.Format(", {0}", ef.GetToppingByID(pizza.Topping3.Value)); }
            ps += string.Format(", Quantity: {0}", pizza.Quantity);

            return ps;
        }
    }
}
