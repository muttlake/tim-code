using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PizzaStore.MVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace PizzaStore.MVC.Controllers
{
    public class PizzaController : Controller
    {
        [HttpGet] //This Action only supports Get Requests
        public IActionResult Index() //Any Action you Create you can respond to all http verbs
        {
            ViewBag.PizzaProblem = "";
            return View(new PizzaViewModel());
        }

        //[HttpPost] //This Action would also accep Post
        //public IActionResult Index(string id)
        //{
        //    return View();
        //}

        [HttpPost] //This does not work because client does not know which single parameter method to use
        public IActionResult Index(PizzaViewModel model) //actually only has to be an object that has the correct properties
        {
            int pizzaQuantity = 0;
            bool validQuantity = Int32.TryParse(model.PizzaQuantity, out pizzaQuantity);
            if (ModelState.IsValid) // does same check as client side using [Required] annotations, this time they can't bypass it
            {
                if (model.SelectedCheeses.Count > 2 || model.SelectedToppings.Count > 3 || !validQuantity)
                {
                    if (model.SelectedCheeses.Count > 2)
                        ViewBag.PizzaProblem = "You can only have 2 cheeses";
                    else if (model.SelectedToppings.Count > 3)
                        ViewBag.PizzaProblem = "You can only have 3 Toppings";
                    else
                        ViewBag.PizzaProblem = "Invalid Pizza Quantity";

                    return View(new PizzaViewModel());
                }
            }
            //Session["Key"] = "Value"; // if you want data to survive entire session, weakly typed data collection

            Console.WriteLine("Session Test: {0}", HttpContext.Session.GetString("Test"));

            TempData["crustID"] = model.CrustID;
            TempData["sauceID"] = model.SauceID;
            //HttpContext.Session.Set("crustID", model.CrustID as Object);
            TempData["cheeseIDList"] = model.GetCheeseIDs();
            TempData["toppingIDList"] = model.GetToppingIDs();
            TempData["pizzaQuantity"] = pizzaQuantity;
            TempData.Keep();


            Console.WriteLine("The TempData customerID is: {0}", TempData["customerID"]);
            Console.WriteLine("The TempData locationID is: {0}", TempData["locationID"]);
            Console.WriteLine("The TempData crustID is: {0}", TempData["crustID"]);
            Console.WriteLine("The TempData sauceID is: {0}", TempData["sauceID"]);
            foreach(var cheese in TempData["cheeseIDList"] as List<int>)
                Console.WriteLine("The TempData cheeseIDList includes: {0}", cheese);
            foreach (var topping in TempData["toppingIDList"] as List<int>)
                Console.WriteLine("The TempData toppingIDList includes: {0}", topping);
            Console.WriteLine("The TempData quantity is: {0}", TempData["pizzaQuantity"]);
            TempData.Keep();


            return RedirectToAction("Index", "CompleteOrder");
        }
    }
}