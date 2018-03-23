using System;
using System.Collections.Generic;

namespace AdventureWorks.Data
{
    public partial class Pizza
    {
        public Pizza()
        {
            PizzaCheese = new HashSet<PizzaCheese>();
            PizzaTopping = new HashSet<PizzaTopping>();
        }

        public int PizzaId { get; set; }
        public string Crust { get; set; }
        public int LocationId { get; set; }
        public DateTime ModifiedDate { get; set; }
        public bool? Active { get; set; }

        public ICollection<PizzaCheese> PizzaCheese { get; set; }
        public ICollection<PizzaTopping> PizzaTopping { get; set; }
    }
}
