using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdWorks.MVC.Models
{
    public class PizzaViewModel
    {
        public string Name
        {
            get;
            set;
        }

        public List<SelectListItem> Size
        {
            get;
            set;
        }
        public List<Topping> Toppings
        {
            get;
            set;
        }

        public PizzaViewModel()
        {
            Size = new List<SelectListItem>()
            {
                new SelectListItem {Text = "Small", Value = "S", Selected = true},
                new SelectListItem { Text = "Medium", Value = "M" },
                new SelectListItem { Text = "Large", Value = "L" }
            };

            Toppings = new List<Topping>()
            {
                new Topping {Name = "BBQ"},
                new Topping {Name = "Pineapple"}, 
                new Topping {Name = "Pepperoni"}
            };
        }
    }
}
