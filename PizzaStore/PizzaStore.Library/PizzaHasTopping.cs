using System;
using System.Collections.Generic;
using PizzaStore.Library.Interfaces;

namespace PizzaStore.Library
{
    //public partial class PizzaHasTopping
    public partial class PizzaHasTopping : IPizzaHas
    {
        public int PizzaHasToppingId { get; set; }
        public int PizzaId { get; set; }
        public int ToppingId { get; set; }

        public Pizza Pizza { get; set; }
        public Topping Topping { get; set; }
    }
}
