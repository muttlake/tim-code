using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WeatherApp.ClientLib;
using WeatherApp.ClientMVC.Models;

namespace WeatherApp.ClientMVC.Controllers
{
    public class LoginController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View(new LoginViewModel());
        }

        [HttpPost]
        public IActionResult Index(LoginViewModel model)
        {
           var user = UserHandler.ValidateUser(model.Email, model.Password).GetAwaiter().GetResult();
           if (user != null)
           {
                HttpContext.Session.Set<User>("User", user);                    
                return RedirectToAction("Index", "Landing");
           }
           return RedirectToAction("Index", "Home");
        }
    }
}
