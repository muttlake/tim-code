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
    public class OrderController : Controller
    {

        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.BadLocation = "";

            int custID = HttpContext.Session.GetInt32("CustomerID").Value;
            var orderViewModel = new OrderViewModel(custID);

            if(orderViewModel.HasPreviousOrders())
                if (orderViewModel.ValidLocations.Count == 1)
                    ViewBag.BadLocation = "You have ordered within two hours, so there is only one location";

            return View(orderViewModel);
        }

        [HttpPost]
        public IActionResult Index(OrderViewModel model)
        {
            if (model.LocationID == -999)
            {
                ViewBag.BadLocation = "Please choose a Location.";
                int cID = HttpContext.Session.GetInt32("CustomerID").Value;
                return View(new OrderViewModel(cID));
            }

            HttpContext.Session.SetInt32("LocationID", model.LocationID);
            int custID = HttpContext.Session.GetInt32("CustomerID").Value;
            HttpContext.Session.Set<OrderHandler>("OrderHandler", new OrderHandler(custID, model.LocationID));

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