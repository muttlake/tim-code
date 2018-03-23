using System;
using System.Collections.Generic;

namespace AdventureWorks.Data
{
    public partial class PizzaCheese
    {
        public int PizzaCheeseId { get; set; }
        public int PizzaId { get; set; }
        public int CheeseId { get; set; }

        public Cheese Cheese { get; set; }
        public Pizza Pizza { get; set; }
    }
}
