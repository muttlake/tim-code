using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WeatherApp.ClientLib;
using WeatherApp.ClientMVC.Models;

namespace WeatherApp.ClientMVC.Controllers
{
    public class FeedController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View(new FeedViewModel());
        }

        public IActionResult Invalid(string message)
        {
            ViewData["Message"] = message;
            return View();
        }

        [HttpGet]
        public IActionResult Registered()
        {
            bool userfound = true;
                try
                {
                    var user = HttpContext.Session.Get<User>("User");
                }
                catch (System.NullReferenceException)
                {
                    userfound = false;
                }
                if (userfound)
                {
                    
                    return RedirectToAction("Index", "Feed");
                }else{

                    return RedirectToAction(nameof(Invalid),new{ message = "Please log in"});
                }
        }

        [HttpPost]
        public ActionResult Index(FeedViewModel model)
        {
            string temp = "";
            string weatherType = "";
            string zip = "";
            if (model.TempFahrFilter != null)
                temp = model.TempFahrFilter;
            if (model.WeatherTypeFilter != null)
                weatherType = model.WeatherTypeFilter;
            if (model.ZipCodeFilter != null)
                zip = model.ZipCodeFilter;

            Console.WriteLine("Temp Filter {0}", temp);
            Console.WriteLine("Weather Type Filter {0}", weatherType);
            Console.WriteLine("Zip Code Filter {0}", zip);

            var fvm = new FeedViewModel(temp, weatherType, zip);

            //Put to database here
            return View(fvm);
        }
    }
}