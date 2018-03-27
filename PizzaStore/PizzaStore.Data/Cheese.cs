using System;
using System.Collections.Generic;

namespace PizzaStore.Data
{
    public partial class Cheese
    {
        public Cheese()
        {
            PizzaHasCheese = new HashSet<PizzaHasCheese>();
        }

        public int CheeseId { get; set; }
        public string Cheese1 { get; set; }
        public double CheeseCost { get; set; }
        public DateTime ModifiedDate { get; set; }
        public bool? Active { get; set; }

        public ICollection<PizzaHasCheese> PizzaHasCheese { get; set; }
    }
}
