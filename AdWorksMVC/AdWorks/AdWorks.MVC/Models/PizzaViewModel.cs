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

        public string Size { get; set; }

        public Size Sizes
        {
            get;
            set;
        }

        public List<SelectListItem> Crust
        {
            get;
            set;
        }

        public List<string> Sizes2
        {
            get;
            set;
        }

        public Topping Toppings
        {
            get;
            set;
        }

        public List<string> ToppingList
        {
            get;
            set;
        }

        public PizzaViewModel()
        {
            Sizes = new Size();
            Toppings = new Topping();

            Sizes2 = new List<string>() { "Small", "Medium", "Large" };
        }
    }
}
