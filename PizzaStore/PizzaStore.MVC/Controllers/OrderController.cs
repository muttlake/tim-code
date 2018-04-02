using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PizzaStore.MVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace PizzaStore.MVC.Controllers
{
    public class OrderController : Controller
    {

        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.BadLocation = "";
            Console.WriteLine("Order Get Index");
            int custID = HttpContext.Session.GetInt32("CustomerID").Value;
            var orderViewModel = new OrderViewModel(custID);
            HttpContext.Session.SetString("NewOrder", "false");
            return View(orderViewModel);
        }

        [HttpPost]
        public IActionResult Index(OrderViewModel model)
        {
            if (model.LocationID == -999)
            {
                ViewBag.BadLocation = "Please choose a Location.";
                int custID = HttpContext.Session.GetInt32("CustomerID").Value;
                return View(new OrderViewModel(custID));
            }
            HttpContext.Session.SetInt32("LocationID", model.LocationID);
            return RedirectToAction("Index", "Pizza");
        }

        [HttpGet]
        public IActionResult CompleteOrder()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CompleteOrder(int i)
        {
            return View();
        }

    }
}