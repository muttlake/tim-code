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

        public CompleteOrderViewModel()
        {

        }

        public CompleteOrderViewModel(int cust, int loc, int crust, int sauc, List<int> cheeses, List<int> toppings, int pq)
        {
            CustomerID = cust;
            LocationID = loc;
            CrustID = crust;
            SauceID = sauc;
            CheeseIDs = cheeses;
            ToppingIDs = toppings;
            PizzaQuantity = pq;

        }

        public double TotalOrderCost()
        {
            return PerPizzaCost() * PizzaQuantity;
        }

        public double PerPizzaCost()
        {
            EfData ef = new EfData();
            double perPizzaCost = 0.00;
            perPizzaCost += ef.GetCrustCost(CrustID);
            perPizzaCost += ef.GetSauceCost(SauceID);
            foreach(var cheeseID in CheeseIDs)
                perPizzaCost += ef.GetCheeseCost(cheeseID);
            foreach (var toppingID in ToppingIDs)
                perPizzaCost += ef.GetToppingCost(toppingID);

            return perPizzaCost;
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
                    cheeseString += ", " + ef.GetCheeseByID(cheeseID);
                count += 1;
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
                    toppingString += ", " + ef.GetToppingByID(toppingID);
                count += 1;
            }
            return toppingString;
        }

        public string GetPizzaQuantity()
        {
            return PizzaQuantity.ToString();
        }

    }
}
