using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PizzaStore.Data;
using PizzaStore.Library;
using PizzaStore.MVC.Models;

namespace PizzaStore.MVC.Controllers
{
    public class CompleteOrderController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {

            var oh = HttpContext.Session.Get<OrderHandler>("OrderHandler");
            Console.WriteLine("OrderHandlerObject: CustomerID: {0}", oh.CustomerID);
            Console.WriteLine("OrderHandlerObject: LocationID: {0}", oh.LocationID);
            Console.WriteLine("OrderHandlerObject: TotalOrderCost: {0}", oh.TotalOrderValue);
            foreach (var pizza in oh.Pizzas)
            {
                Console.WriteLine("OrderHandlerObject: pizza crustID: {0}", pizza.CrustId);
                Console.WriteLine("OrderHandlerObject: pizza sauceID: {0}", pizza.SauceId);
                Console.WriteLine("OrderHandlerObject: pizza cheese1: {0}", pizza.Cheese1);
                Console.WriteLine("OrderHandlerObject: pizza cheese2: {0}", pizza.Cheese2);
                Console.WriteLine("OrderHandlerObject: pizza topping1: {0}", pizza.Topping1);
                Console.WriteLine("OrderHandlerObject: pizza topping2: {0}", pizza.Topping2);
                Console.WriteLine("OrderHandlerObject: pizza topping3: {0}", pizza.Topping3);
                Console.WriteLine("OrderHandlerObject: pizza quantity: {0}", pizza.Quantity);
            }

            //Check if Order is too Expensive
            JsonHandler jh = new JsonHandler();
            if (oh.TotalOrderValue > jh.JsonObject.MAX_ORDER_TOTAL)
            {
                Console.WriteLine("totalOrderCost exceeds {0}", jh.JsonObject.MAX_ORDER_TOTAL );
                HttpContext.Session.SetInt32("CostOfOrder", (int)oh.TotalOrderValue);
                return RedirectToAction("Index", "Pizza");
            }

            //Check inventory availability here
            OrderInventoryHandler oih = new OrderInventoryHandler(oh);
            if (!oih.GetInventorySufficiency())
            {
                Console.WriteLine("Inventory not sufficient");
                ViewBag.PizzaProblem = "The Store does not have enough inventory to complete that order.";
                return RedirectToAction("Index", "Pizza");
            }

            var completeOrder = new CompleteOrderViewModel(oh);

            return View(completeOrder);
        }

        [HttpPost]
        public IActionResult Index(CompleteOrderViewModel model)
        {
            var oh = HttpContext.Session.Get<OrderHandler>("OrderHandler");

            //Make order
            OrderMaker om = new OrderMaker(oh);
            om.MakeOrder();

            //Subtract Inventory
            OrderInventoryHandler oih = new OrderInventoryHandler(oh);
            oih.SubtractInventory();

            return RedirectToAction("Index", "ReviewOrder");
        }

    }
}