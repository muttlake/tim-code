using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WeatherApp.Library;
using WeatherApp.MVC.Models;

namespace WeatherApp.MVC.Controllers
{
    public class LandingController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            var user = HttpContext.Session.Get<User>("User");
            return View(new LandingViewModel(user));
        }

        [HttpPost]
        public IActionResult Index(LandingViewModel model)
        {
            return View();
        }
    }
}