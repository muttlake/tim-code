using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AdWorks.MVC.Models;

namespace AdWorks.MVC.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet] //This Action only supports Get Requests
        [HttpPost]
        public IActionResult Index() //action named index is default
        {
            //dynamic obj = "hello";
            //obj.name = new { name = "Fred" };
            //obj = 10; // This is dynamic, object can be overwritten with different types

            //ViewBag.GoToOrder = false; // does not survive redirect
            //ViewData["Message"] = "minion";
            return View();
            ////TempData["Message"] = "despicable";
            //if(!ViewBag.GoToOrder)
            //    return View(); // which view? default view
            //else
            //    return RedirectToAction("Index", "Order");
            //return RedirectToAction("About");
        }


        public IActionResult About()
        {
            //ViewData["Message"] = "Your application description page.";

            //ViewBag.Message = "banana"; // does not survive redirect
            //ViewData["Message"] = "minion";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
