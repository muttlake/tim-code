using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PizzaStore.MVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace PizzaStore.MVC.Controllers
{
    public class PizzaController : Controller
    {
        [HttpGet] //This Action only supports Get Requests
        public IActionResult Index() //Any Action you Create you can respond to all http verbs
        {
            ViewBag.CheeseOrToppingProblem = "";
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
            if(ModelState.IsValid) // does same check as client side using [Required] annotations, this time they can't bypass it
            {
                if(model.SelectedCheeses.Count > 2 || model.SelectedToppings.Count > 3)
                {
                    if (model.SelectedCheeses.Count > 2)
                        ViewBag.CheeseOrToppingProblem = "You can only have 2 cheeses";
                    else
                        ViewBag.CheeseOrToppingProblem = "You can only have 3 Toppings";

                    return View(new PizzaViewModel());
                }
            }
            //Session["Key"] = "Value"; // if you want data to survive entire session, weakly typed data collection
            Console.WriteLine(model.CrustID);
            //return View();
            return RedirectToAction("CompleteOrder", "Order");
        }
    }
}