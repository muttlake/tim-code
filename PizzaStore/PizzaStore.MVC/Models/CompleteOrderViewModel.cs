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
    public class CompleteOrderViewModel
    {
        public int CustomerID { get; set; }
        public int LocationID { get; set; }
        public int CrustID { get; set; }
        public int SauceID { get; set; }
        public List<int> CheeseIDs { get; set; }
        public List<int> ToppingIDs { get; set; }
        public int PizzaQuantity { get; set; }

        public CompleteOrderViewModel(int cust, int loc, int crust, int sauc, List<int> cheeses, List<int> toppings, int pq)
        {
            CustomerID = cust;
            LocationID = loc;
            CrustID = crust;
            SauceID = sauc;
            CheeseIDs = cheeses;
            ToppingIDs = toppings;
            PizzaQuantity = pq;


            Console.WriteLine("CheeseIDs size: {0}", CheeseIDs.Count);
        }

        public string GetCustomerName()
        {
            EfData ef = new EfData();
            return ef.GetCustomerNameByID(CustomerID);
        }

        public string GetLocationString()
        {
            EfData ef = new EfData();
            return ef.GetLocationByID(LocationID);
        }

        public string GetCrustString()
        {
            EfData ef = new EfData();
            return ef.GetCrustByID(CrustID);
        }

        public string GetSauceString()
        {
            EfData ef = new EfData();
            return ef.GetSauceByID(SauceID);
        }

        public string GetCheeseString()
        {
            EfData ef = new EfData();
            string cheeseString = "";
            int count = 0;
            foreach(var cheeseID in CheeseIDs)
            {
                if (count == 0)
                    cheeseString += ef.GetCheeseByID(cheeseID);
                else
                    cheeseString += "\n" + ef.GetCheeseByID(cheeseID);
            }
            return cheeseString;
        }

        public string GetToppingString()
        {
            EfData ef = new EfData();
            string toppingString = "";
            int count = 0;
            foreach (var toppingID in ToppingIDs)
            {
                if (count == 0)
                    toppingString += ef.GetToppingByID(toppingID);
                else
                    toppingString += "\n" + ef.GetToppingByID(toppingID);
            }
            return toppingString;
        }

        public string GetPizzaQuantity()
        {
            return PizzaQuantity.ToString();
        }


        //Console.WriteLine("The TempData customerID is: {0}", TempData["customerID"]);
        //Console.WriteLine("The TempData locationID is: {0}", TempData["locationID"]);
        //Console.WriteLine("The TempData crustID is: {0}", TempData["crustID"]);
        //Console.WriteLine("The TempData sauceID is: {0}", TempData["sauceID"]);
        //foreach(var cheese in TempData["cheeseIDList"] as List<int>)
        //    Console.WriteLine("The TempData cheeseIDList includes: {0}", cheese);
        //foreach (var topping in TempData["toppingIDList"] as List<int>)
        //    Console.WriteLine("The TempData toppingIDList includes: {0}", topping);
        //Console.WriteLine("The TempData quantity is: {0}", TempData["pizzaQuantity"]);
    }
}
