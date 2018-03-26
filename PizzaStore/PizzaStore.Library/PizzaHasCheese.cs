using System;
using System.Collections.Generic;
using PizzaStore.Library.Interfaces;

namespace PizzaStore.Library
{
    public partial class PizzaHasCheese : IPizzaHas
    {
        public int PizzaHasCheeseId { get; set; }
        public int PizzaId { get; set; }
        public int CheeseId { get; set; }

        public Cheese Cheese { get; set; }
        public Pizza Pizza { get; set; }
    }
}
