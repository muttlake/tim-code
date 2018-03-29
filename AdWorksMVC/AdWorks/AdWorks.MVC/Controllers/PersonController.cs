using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace AdWorks.MVC.Controllers
{
    public class PersonController : Controller //suffix contoller allows parser to know it's a controller
    {
        public IActionResult Index() //as user when you request something you want us to act on it
        {
            return View();
        }
    }
}