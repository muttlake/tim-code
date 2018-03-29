using System;
using System.Collections.Generic;

namespace PizzaStore.Data
{
    public partial class PizzaHasCheese
    {
        public int PizzaHasCheeseId { get; set; }
        public int PizzaId { get; set; }
        public int CheeseId { get; set; }

        public Cheese Cheese { get; set; }
        public Pizza Pizza { get; set; }
    }
}
