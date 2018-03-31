using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PizzaStore.MVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace PizzaStore.MVC.Controllers
{
    public class OrderController : Controller
    {

        [HttpGet]
        public IActionResult Index()
        {
            Console.WriteLine("Order Get Index");
            //int customerID = System.Web.HttpContext.Current.Session["customerID"];
            //Console.WriteLine("Customer Id is: {0}", System.Web.HttpContext.Current.Session["customerID"]);
            return View(new OrderViewModel());
        }

        [HttpPost]
        public IActionResult Index(OrderViewModel model)
        {
            Console.WriteLine("Order Post Index");
            Console.WriteLine(model.LocationID);
            TempData["locationID"] = model.LocationID;
            Console.WriteLine("The TempData customerID is: {0}", TempData["customerID"]);
            Console.WriteLine("The TempData locationID is: {0}", TempData["locationID"]);
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