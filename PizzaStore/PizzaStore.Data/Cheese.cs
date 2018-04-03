using System;
using System.Collections.Generic;

namespace PizzaStore.Data
{
    public partial class Cheese
    {
        public Cheese()
        {
            Pizza2Cheese1Navigation = new HashSet<Pizza2>();
            Pizza2Cheese2Navigation = new HashSet<Pizza2>();
            PizzaHasCheese = new HashSet<PizzaHasCheese>();
        }

        public int CheeseId { get; set; }
        public string Cheese1 { get; set; }
        public double CheeseCost { get; set; }
        public DateTime ModifiedDate { get; set; }
        public bool? Active { get; set; }

        public ICollection<Pizza2> Pizza2Cheese1Navigation { get; set; }
        public ICollection<Pizza2> Pizza2Cheese2Navigation { get; set; }
        public ICollection<PizzaHasCheese> PizzaHasCheese { get; set; }
    }
}
