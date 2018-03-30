using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdWorks.MVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace AdWorks.MVC.Controllers
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
            Console.WriteLine(model.CustomerName);
            Console.WriteLine(model.LocationID);
            return RedirectToAction("Index", "Pizza");
        }
    }
}