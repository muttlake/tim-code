using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PizzaStore.MVC.Models;

namespace PizzaStore.MVC.Controllers
{
    public class CustomerController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View(new CustomerViewModel());
        }

        [HttpGet]
        public IActionResult Index(CustomerViewModel model)
        {
            Console.WriteLine(model.CustomerName);
            return RedirectToAction("Index", "Order");
        }
    }
}