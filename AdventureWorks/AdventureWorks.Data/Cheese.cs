using System;
using System.Collections.Generic;

namespace AdventureWorks.Data
{
    public partial class Cheese
    {
        public Cheese()
        {
            PizzaCheese = new HashSet<PizzaCheese>();
        }

        public int CheeseId { get; set; }
        public string Cheese1 { get; set; }
        public DateTime ModifiedDate { get; set; }
        public bool? Active { get; set; }

        public ICollection<PizzaCheese> PizzaCheese { get; set; }
    }
}
