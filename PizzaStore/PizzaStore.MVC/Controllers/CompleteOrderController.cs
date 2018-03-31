using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PizzaStore.MVC.Models;

namespace PizzaStore.MVC.Controllers
{
    public class CompleteOrderController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            //Console.WriteLine("The TempData customerID is: {0}", TempData["customerID"]);
            //Console.WriteLine("The TempData locationID is: {0}", TempData["locationID"]);
            //Console.WriteLine("The TempData crustID is: {0}", TempData["crustID"]);
            //Console.WriteLine("The TempData sauceID is: {0}", TempData["sauceID"]);
            //foreach(var cheese in TempData["cheeseIDList"] as List<int>)
            //    Console.WriteLine("The TempData cheeseIDList includes: {0}", cheese);
            //foreach (var topping in TempData["toppingIDList"] as List<int>)
            //    Console.WriteLine("The TempData toppingIDList includes: {0}", topping);
            //Console.WriteLine("The TempData quantity is: {0}", TempData["pizzaQuantity"]);
            int custID = Convert.ToInt32(TempData["customerID"]);
            int locID = Convert.ToInt32(TempData["locationID"]);
            int crustID = Convert.ToInt32(TempData["crustID"]);
            int sauceID = Convert.ToInt32(TempData["sauceID"]);
            int pa = Convert.ToInt32(TempData["pizzaQuantity"]);
            List<int> cheeses = TempData["cheeseIDList"] as List<int>;
            List<int> toppings = TempData["toppingIDList"] as List<int>;

            //foreach (var cheese in TempData["cheeseIDList"] as List<int>)
            //    cheeses.Add(Convert.ToInt32(cheese));
            //ist<int> toppings = new List<int>();
            //foreach (var topping in TempData["toppingIDList"] as List<int>)
            //    cheeses.Add(Convert.ToInt32(topping));

            var completeOrder = new CompleteOrderViewModel(custID, locID, crustID, sauceID, cheeses, toppings, pa);
            return View(completeOrder);
        }

        [HttpPost]
        public IActionResult Index(CompleteOrderViewModel model)
        {
            return View();
        }


    }
}