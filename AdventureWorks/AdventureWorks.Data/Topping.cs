using System;
using System.Collections.Generic;

namespace AdventureWorks.Data
{
    public partial class Topping
    {
        public Topping()
        {
            PizzaTopping = new HashSet<PizzaTopping>();
        }

        public int ToppingId { get; set; }
        public string Topping1 { get; set; }
        public DateTime ModifiedDate { get; set; }
        public bool? Active { get; set; }

        public ICollection<PizzaTopping> PizzaTopping { get; set; }
    }
}
