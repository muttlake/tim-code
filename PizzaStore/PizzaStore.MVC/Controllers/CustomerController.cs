using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PizzaStore.MVC.Models;
using System.Web;


namespace PizzaStore.MVC.Controllers
{
    public class CustomerController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.CustomerNameProblem = "";
            return View(new CustomerViewModel());
        }

        [HttpPost]
        public IActionResult Index(CustomerViewModel model)
        {
            Console.WriteLine(model.CustomerName);
            //System.Web.HttpContext.Current.Session["customerID"] = model.GetCustomerId();
            if (model.GetCustomerId() > 0)
            {
                HttpContext.Session.SetString("CustomerName", model.CustomerName);
                HttpContext.Session.SetInt32("CustomerID", model.GetCustomerId());

                ViewBag.PizzaProblem = "";
                HttpContext.Session.SetInt32("CostOfOrder", 0);
                HttpContext.Session.SetInt32("InventoryProblem", 0);




                return RedirectToAction("Index", "Order");
            }
            else
            {
                ViewBag.CustomerNameProblem = "Name entered not in database or Invalid";
                return View(new CustomerViewModel());
            }
            
        }
    }
}