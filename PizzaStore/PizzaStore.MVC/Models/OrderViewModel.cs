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
    public struct PizzaOrder
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
            TwoHourChecker thc = new TwoHourChecker(CustomerID);
            if (thc.OrderedWithinTwoHours())
                ValidLocations = GetLocations(thc.GetLastLocation());
            else
                ValidLocations = GetLocations();
            SetPizzaOrders();
        }

        private Dictionary<int, string> GetLocations(int loc)
        {
            EfData ef = new EfData();
            Dictionary<int, string> locationDict = new Dictionary<int, string>();
            foreach (var location in ef.ReadLocations())
            {
                if (location.LocationId == loc)
                {
                    string locString = "";
                    locString += location.Address.Street;
                    locString += ", " + location.Address.City;
                    locString += ", " + location.Address.State.StateAbb;
                    locString += ", " + location.Address.City;
                    locationDict[location.LocationId] = locString;
                }
            }
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
                Order order = ef.GetOrderById(orderID);
                po.CustomerName = ef.GetCustomerNameByID(CustomerID);
                po.OrderValue = order.TotalValue.Value;
                po.OrderTime = order.OrderTime;
                po.LocationString = ef.GetLocationByID(ef.GetLocationIDForOrder(orderID));

                po.PizzaStrings = new List<string>();
                List<int> pizzaIDs = ef.GetAllPizzaIDsForOrder(orderID);
                int count = 0;
                string lastPizzaString = ef.GetPizzaStringByPizzaID(pizzaIDs.ElementAt(0));

                for(int i = 0; i < pizzaIDs.Count; i++)
                {
                    string newPizzaString = ef.GetPizzaStringByPizzaID(pizzaIDs.ElementAt(i));
                    if (!newPizzaString.Equals(lastPizzaString))
                    {
                        po.PizzaStrings.Add(lastPizzaString + string.Format(", Quantity: {0}", count));
                        lastPizzaString = newPizzaString;
                        count = 1;
                    }
                    else
                        count += 1;

                    if (i == pizzaIDs.Count - 1)
                        po.PizzaStrings.Add(newPizzaString + string.Format(", Quantity: {0}", count));
                }

                AllPizzaOrders.Add(po);

            }
        }
    }
}
