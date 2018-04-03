using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using PizzaStore.Library;
using PizzaStore.Data;

namespace PizzaStore.MVC.Models
{

    public class ReDoAnOrderViewModel
    {
        private Order prevOrder { get; set; }
        public PizzaOrder Po { get; set; }

        public OrderHandler Oh { get; set; }

        public ReDoAnOrderViewModel()
        {
        }

        public ReDoAnOrderViewModel(int custID)
        {
            EfData ef = new EfData();
            prevOrder = ef.GetMostRecentOrderForCustomer(custID);
            SetPizzaOrder();
            SetOrderHandler();
        }

        public void SetOrderHandler()
        {
            Oh = new OrderHandler(prevOrder.CustomerId, prevOrder.LocationId);

            var ef = new EfData();
            List<Pizza2> pizzas = ef.GetPizza2sForOrder(prevOrder.OrderId);
            
            foreach(var pizza in pizzas)
            {
                Pizza2 p2 = new Pizza2();
                p2.CrustId = pizza.CrustId;
                p2.SauceId = pizza.SauceId;
                p2.Cheese1 = pizza.Cheese1;
                p2.Cheese2 = pizza.Cheese2;

                p2.Topping1 = pizza.Topping1;
                p2.Topping2 = pizza.Topping2;
                p2.Topping3 = pizza.Topping3;

                p2.Quantity = pizza.Quantity;

                p2.TotalPizzaCost = pizza.TotalPizzaCost;

                p2.ModifiedDate = DateTime.Now;
                Oh.Pizzas.Add(p2);
                Oh.TotalOrderValue += p2.TotalPizzaCost.Value * p2.Quantity;
            }
        }


        public int GetLocationId()
        {
            return prevOrder.LocationId;
        }

        public void SetPizzaOrder()
        {
            var ef = new EfData();
            Po = new PizzaOrder();
            Po.OrderID = prevOrder.OrderId;
            Po.CustomerName = ef.GetCustomerNameByID(prevOrder.CustomerId);
            Po.OrderValue = prevOrder.TotalValue.Value;
            Po.OrderTime = prevOrder.OrderTime;
            Po.LocationString = ef.GetLocationByID(ef.GetLocationIDForOrder(prevOrder.OrderId));
            Po.PizzaStrings = GetAllPizzasInOrder(ef.GetPizza2sForOrder(prevOrder.OrderId));
        }

        public List<string> GetAllPizzasInOrder(List<Pizza2> pizzas)
        {
            List<string> list = new List<string>();

            foreach (var pizza in pizzas)
            {
                list.Add(Pizza2String(pizza));
            }

            return list;
        }

        private string Pizza2String(Pizza2 pizza)
        {
            var ef = new EfData();
            string ps = "";
            ps += string.Format("${0}", pizza.TotalPizzaCost);
            ps += string.Format(", Crust: {0}", ef.GetCrustByID(pizza.CrustId));
            if (pizza.SauceId != null) { ps += string.Format(", Sauce: {0}", ef.GetSauceByID(pizza.SauceId.Value)); }
            if (pizza.Cheese1 != null) { ps += string.Format(", Cheeses: {0}", ef.GetCheeseByID(pizza.Cheese1.Value)); }
            if (pizza.Cheese2 != null) { ps += string.Format(", {0}", ef.GetCheeseByID(pizza.Cheese2.Value)); }
            if (pizza.Topping1 != null) { ps += string.Format(", Toppings: {0}", ef.GetToppingByID(pizza.Topping1.Value)); }
            if (pizza.Topping2 != null) { ps += string.Format(", {0}", ef.GetToppingByID(pizza.Topping2.Value)); }
            if (pizza.Topping3 != null) { ps += string.Format(", {0}", ef.GetToppingByID(pizza.Topping3.Value)); }
            ps += string.Format(", Quantity: {0}", pizza.Quantity);

            return ps;
        }
    }
}

