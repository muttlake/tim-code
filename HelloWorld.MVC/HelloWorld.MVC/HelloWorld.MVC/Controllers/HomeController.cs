using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace HelloWorld.MVC.Controllers
{
    [Route("/home")]
    //[Route("[controller]/[action = index]")]
    public class HomeController : Controller
    {
        [Route("/home/index")]
        public string Index()
        {
            return "hello MVC";
        }
    }
}