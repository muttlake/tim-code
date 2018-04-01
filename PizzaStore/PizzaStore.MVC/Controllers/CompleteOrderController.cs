using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PizzaStore.Library;
using PizzaStore.MVC.Models;

namespace PizzaStore.MVC.Controllers
{
    public class CompleteOrderController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {

            Console.WriteLine("CO SessionData CustomerID is: {0}", HttpContext.Session.GetInt32("CustomerID"));
            Console.WriteLine("CO SessionData CustomerName is: {0}", HttpContext.Session.GetString("CustomerName"));
            Console.WriteLine("CO SessionData LocationID is: {0}", HttpContext.Session.GetInt32("LocationID"));
            Console.WriteLine("CO SessionData CrustID is: {0}", HttpContext.Session.GetInt32("CrustID"));
            Console.WriteLine("CO SessionData SauceID is: {0}", HttpContext.Session.GetInt32("SauceID"));
            Console.WriteLine("CO SessionData CheeseIDString is: {0}", HttpContext.Session.GetString("CheeseIDs"));
            Console.WriteLine("CO SessionData ToppingIDString is: {0}", HttpContext.Session.GetString("ToppingIDs"));
            Console.WriteLine("CO SessionData PizzaQuantity is: {0}", HttpContext.Session.GetString("PizzaQuantity"));

            int custID = HttpContext.Session.GetInt32("CustomerID").Value;
            int locID = HttpContext.Session.GetInt32("LocationID").Value;
            int crustID = HttpContext.Session.GetInt32("CrustID").Value;
            int sauceID = HttpContext.Session.GetInt32("SauceID").Value;
            int pq = HttpContext.Session.GetInt32("PizzaQuantity").Value;
            List<int> cheeseIDs = ConvertSessionStringToList("CheeseIDs");
            List<int> toppingIDs = ConvertSessionStringToList("ToppingIDs");




            var completeOrder = new CompleteOrderViewModel(custID, locID, crustID, sauceID, cheeseIDs, toppingIDs, pq);

            double totalOrderCost = completeOrder.TotalOrderCost();
            if(totalOrderCost > 1000)
            {
                Console.WriteLine("totalOrderCost exceeds 1000");
                ViewBag.PizzaProblem = "Total Order Cost exceeds $1000, please re-make your order";
                return RedirectToAction("Index", "Pizza");
            }

            return View(completeOrder);
        }

        [HttpPost]
        public IActionResult Index(CompleteOrderViewModel model)
        {

            int custID = HttpContext.Session.GetInt32("CustomerID").Value;
            int locID = HttpContext.Session.GetInt32("LocationID").Value;
            int crustID = HttpContext.Session.GetInt32("CrustID").Value;
            int sauceID = HttpContext.Session.GetInt32("SauceID").Value;
            int pq = HttpContext.Session.GetInt32("PizzaQuantity").Value;
            List<int> cheeseIDs = ConvertSessionStringToList("CheeseIDs");
            List<int> toppingIDs = ConvertSessionStringToList("ToppingIDs");

            InitialOrder initialOrder = new InitialOrder();
            Console.WriteLine("Adding Initial Order...");
            initialOrder.CreateNewOrderWithSinglePizza(locID, custID, crustID, sauceID,
                                                       cheeseIDs, toppingIDs);
            int pizzasAfterInitialPizza = pq - 1;
            Console.WriteLine("Should have added Initial Order...");

            int orderId = initialOrder.GetOrderId();

            if(pizzasAfterInitialPizza > 0)
            {
                AddAdditionalPizza pizzaAdder = new AddAdditionalPizza();

                for (int i = 0; i < pizzasAfterInitialPizza; i++)
                {
                    pizzaAdder.AddPizzaToOrder(orderId, crustID, sauceID, cheeseIDs, toppingIDs);
                }
            }

            return RedirectToAction("Index", "Customer");
        }

        private List<int> ConvertSessionStringToList(string s)
        {
            if (HttpContext.Session.GetString(s).Length == 0)
                return new List<int>();

            string[] stringArray = HttpContext.Session.GetString(s).Split(",");
            Console.WriteLine("Length of stringArray: {0}", stringArray.Length);

            List<int> list = new List<int>();
            foreach (var item in stringArray)
            {
                list.Add(Convert.ToInt32(item));
            }
            return list;
        }

    }
}