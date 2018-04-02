using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace AdWorks.MVC.Models
{
    public class PizzaViewModel
    {
        [Required]
        public int CrustID { get; set; }

        [Required]
        public int SauceID { get; set; }

        [Required]
        public List<int> CheeseIDs { get; set; }

        [Required]
        public List<int> ToppingIDs { get; set; }

        public Dictionary<int, string> Crusts { get; set; }
        public Dictionary<int, string> Sauces { get; set; }
        public Dictionary<int, string> Cheeses { get; set; }
        public Dictionary<int, string> Toppings { get; set; }

        public PizzaViewModel()
        {
            Crusts = new Dictionary<int, string>() { { 1, "Thin" }, { 2, "Hand Tossed" }, { 3, "Thick" } };
            Sauces = new Dictionary<int, string>() { { 1, "Tomato" }, { 2, "Pesto" } };
            Cheeses = new Dictionary<int, string>() { { 1, "Mozzarella" }, { 2, "Colby" }, { 3, "Cheddar" } };
            Toppings = new Dictionary<int, string>() { { 7, "Pepperoni" }, { 8, "Green Pepper" }, { 9, "Onion" }, { 10, "Meatball" }, { 11, "Mushroom" } };
        }
    }
}
