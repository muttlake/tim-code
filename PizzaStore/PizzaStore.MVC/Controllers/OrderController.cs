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
            return View(new OrderViewModel());
        }

        [HttpPost]
        public IActionResult Index(OrderViewModel model)
        {
            Console.WriteLine(model.LocationID);
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