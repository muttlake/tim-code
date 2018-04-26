using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WeatherApp.ClientLib;
using WeatherApp.ClientMVC.Models;

namespace WeatherApp.ClientMVC.Controllers
{
    public class LandingController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            var user = HttpContext.Session.Get<User>("User");
            var lvm = new LandingViewModel(user);

            //Set current weather in session
            HttpContext.Session.Set<RootObject>("CurrentWeather", lvm.GetCurrentWeather());

            return View(lvm);
        }
    }
}