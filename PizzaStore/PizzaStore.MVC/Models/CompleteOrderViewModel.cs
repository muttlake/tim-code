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
    public class CompleteOrderViewModel
    {
        public OrderHandler Oh { get; set; }

        public CompleteOrderViewModel()
        {

        }

        public CompleteOrderViewModel(OrderHandler oh)
        {
            Oh = oh;
        }

        public string GetCustomerName()
        {
            EfData ef = new EfData();
            return ef.GetCustomerNameByID(Oh.CustomerID);
        }

        public string GetLocationString()
        {
            EfData ef = new EfData();
            return ef.GetLocationByID(Oh.LocationID);
        }

        public List<string> GetAllPizzasInOrder()
        {
            List<string> list = new List<string>();

            foreach(var pizza in Oh.Pizzas)
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
