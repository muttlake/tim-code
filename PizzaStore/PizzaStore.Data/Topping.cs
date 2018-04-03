using System;
using System.Collections.Generic;

namespace PizzaStore.Data
{
    public partial class Topping
    {
        public Topping()
        {
            Pizza2Topping1Navigation = new HashSet<Pizza2>();
            Pizza2Topping2Navigation = new HashSet<Pizza2>();
            Pizza2Topping3Navigation = new HashSet<Pizza2>();
            PizzaHasTopping = new HashSet<PizzaHasTopping>();
        }

        public int ToppingId { get; set; }
        public double ToppingCost { get; set; }
        public DateTime ModifiedDate { get; set; }
        public bool? Active { get; set; }
        public string Topping1 { get; set; }

        public ICollection<Pizza2> Pizza2Topping1Navigation { get; set; }
        public ICollection<Pizza2> Pizza2Topping2Navigation { get; set; }
        public ICollection<Pizza2> Pizza2Topping3Navigation { get; set; }
        public ICollection<PizzaHasTopping> PizzaHasTopping { get; set; }
    }
}
