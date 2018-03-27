using System;
using System.Collections.Generic;

namespace PizzaStore.Data
{
    public partial class PizzaHasTopping
    {
        public int PizzaHasToppingId { get; set; }
        public int PizzaId { get; set; }
        public int ToppingId { get; set; }

        public Pizza Pizza { get; set; }
        public Topping Topping { get; set; }
    }
}
