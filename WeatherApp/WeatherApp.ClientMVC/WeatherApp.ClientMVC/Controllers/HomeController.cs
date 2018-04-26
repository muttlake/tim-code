using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WeatherApp.ClientMVC.Models;

namespace WeatherApp.ClientMVC.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Weather App is a way to enable users to share the current weather at their location. Users can make a blog post and add images to that post to share with other users.";

            return View();
        }

        public IActionResult Login()
        {
            return RedirectToAction("Index", "Login");
        }


    public IActionResult Logout()
        {
            HttpContext.Session.Clear();
                
            return RedirectToAction("Index", "Home");
               
        }


        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
