using System;
using System.Collections.Generic;

namespace PizzaStore.Data
{
    public partial class Topping
    {
        public Topping()
        {
            PizzaHasTopping = new HashSet<PizzaHasTopping>();
        }

        public int ToppingId { get; set; }
        public double ToppingCost { get; set; }
        public DateTime ModifiedDate { get; set; }
        public bool? Active { get; set; }
        public string Topping1 { get; set; }

        public ICollection<PizzaHasTopping> PizzaHasTopping { get; set; }
    }
}
