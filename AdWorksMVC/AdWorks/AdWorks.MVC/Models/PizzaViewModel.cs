using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdWorks.MVC.Models
{
    public class PizzaViewModel
    {
        public string Size { get; set; }
        public string Crust { get; set; }

        public List<string> Sizes { get; set; }

        public List<string> Crusts { get; set; }

        public PizzaViewModel()
        {
            Sizes = new List<string>() { "Small", "Medium", "Large" };
            Crusts = new List<string>() { "Thin", "HandTossed", "Thick" };
        }
    }
}
