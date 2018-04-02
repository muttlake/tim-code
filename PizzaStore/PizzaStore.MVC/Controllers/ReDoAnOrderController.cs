using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PizzaStore.MVC.Models;

namespace PizzaStore.MVC.Controllers
{
    public class ReDoAnOrderController : Controller
    {
        //choose a location
        //Redo the order
        [HttpGet]
        public IActionResult Index()
        {
            var raovm = new ReDoAnOrderViewModel(HttpContext.Session.GetInt32("CustomerID").Value);

            HttpContext.Session.SetInt32("LocationID", raovm.LocationID);
            HttpContext.Session.SetInt32("CrustID", raovm.GetCrustID());
            HttpContext.Session.SetInt32("SauceID", raovm.GetSauceID());
            HttpContext.Session.SetInt32("PizzaQuantity", raovm.GetPQ());
            HttpContext.Session.SetString("CheeseIDs", raovm.GetCheeseIDString());
            HttpContext.Session.SetString("ToppingIDs", raovm.GetToppingIDString());

            return View(raovm);
        }

        [HttpPost]
        public IActionResult Index(ReDoAnOrderViewModel model)
        {
            return RedirectToAction("Index", "CompleteOrder");
        }
    }
}