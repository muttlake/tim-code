using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PizzaStore.MVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using PizzaStore.Library;

namespace PizzaStore.MVC.Controllers
{
    public class PizzaController : Controller
    {
        [HttpGet] //This Action only supports Get Requests
        public IActionResult Index() //Any Action you Create you can respond to all http verbs
        {
            JsonHandler jh = new JsonHandler();
            if (HttpContext.Session.GetInt32("CostOfOrder") > jh.JsonObject.MAX_ORDER_TOTAL)
                ViewBag.PizzaProblem = string.Format("Order Exceeds ${0}. It was $", jh.JsonObject.MAX_ORDER_TOTAL) + HttpContext.Session.GetInt32("CostOfOrder").ToString();
            return View(new PizzaViewModel());
        }


        [HttpPost] //This does not work because client does not know which single parameter method to use
        public IActionResult Index(PizzaViewModel model) //actually only has to be an object that has the correct properties
        {
            int pizzaQuantity = 0;
            bool validQuantity = Int32.TryParse(model.PizzaQuantity, out pizzaQuantity);
            if(!(pizzaQuantity > 0)) { validQuantity = false; }
            if (ModelState.IsValid) // does same check as client side using [Required] annotations, this time they can't bypass it
            {
                if (model.SelectedCheeses.Count > 2 || model.SelectedToppings.Count > 3 || !validQuantity || model.CrustID == 0 || model.SauceID == 0)
                {
                    if (model.CrustID == 0)
                        ViewBag.PizzaProblem = "No Crust Chosen";
                    else if (model.SauceID == 0)
                        ViewBag.PizzaProblem = "No Sauce Chosen";
                    else if (model.SelectedCheeses.Count > 2)
                        ViewBag.PizzaProblem = "You can only have 2 cheeses";
                    else if (model.SelectedToppings.Count > 3)
                        ViewBag.PizzaProblem = "You can only have 3 Toppings";
                    else
                        ViewBag.PizzaProblem = "Invalid Pizza Quantity";

                    return View(new PizzaViewModel());
                }
            }

            HttpContext.Session.SetInt32("CrustID", model.CrustID);
            HttpContext.Session.SetInt32("SauceID", model.SauceID);
            HttpContext.Session.SetInt32("PizzaQuantity", pizzaQuantity);
            HttpContext.Session.SetString("CheeseIDs", model.GetCheeseIDString()); 
            HttpContext.Session.SetString("ToppingIDs", model.GetToppingIDString());


            Console.WriteLine("The SessionData CustomerID is: {0}", HttpContext.Session.GetInt32("CustomerID"));
            Console.WriteLine("The SessionData CustomerName is: {0}", HttpContext.Session.GetString("CustomerName"));
            Console.WriteLine("The SessionData LocationID is: {0}", HttpContext.Session.GetInt32("LocationID"));
            Console.WriteLine("The SessionData CrustID is: {0}", HttpContext.Session.GetInt32("CrustID"));
            Console.WriteLine("The SessionData SauceID is: {0}", HttpContext.Session.GetInt32("SauceID"));
            Console.WriteLine("The SessionData CheeseIDString is: {0}", HttpContext.Session.GetString("CheeseIDs"));
            Console.WriteLine("The SessionData ToppingIDString is: {0}", HttpContext.Session.GetString("ToppingIDs"));



            return RedirectToAction("Index", "CompleteOrder");
        }
    }
}