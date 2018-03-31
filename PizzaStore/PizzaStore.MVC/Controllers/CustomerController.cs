using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
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

        [HttpPost]
        public IActionResult Index(CustomerViewModel model)
        {
            Console.WriteLine(model.CustomerName);
            //ControllerContext.HttpContext.Session["{name}"]
            //HttpContext.Session.Set("customer name", model.CustomerName)
            //return RedirectToAction("Order");
            return RedirectToAction("Index", "Order");
        }
    }
}