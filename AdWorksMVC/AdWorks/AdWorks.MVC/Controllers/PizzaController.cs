using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdWorks.MVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace AdWorks.MVC.Controllers
{
    public class PizzaController : Controller
    {
        [HttpGet] //This Action only supports Get Requests
        public IActionResult Index() //Any Action you Create you can respond to all http verbs
        {
            return View(new PizzaViewModel());
        }

        //[HttpPost] //This Action would also accep Post
        //public IActionResult Index(string id)
        //{
        //    return View();
        //}

        [HttpPost] //This does not work because client does not know which single parameter method to use
        public IActionResult Index(PizzaViewModel model) //actually only has to be an object that has the correct properties
        {
            Console.WriteLine(model.CrustID);
            return View();
        }
    }
}