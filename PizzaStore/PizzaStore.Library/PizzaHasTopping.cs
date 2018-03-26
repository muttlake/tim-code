﻿using System;
using System.Collections.Generic;

namespace PizzaStore.Library
{
    //public partial class PizzaHasTopping
    public partial class PizzaHasTopping
    {
        public int PizzaHasToppingId { get; set; }
        public int PizzaId { get; set; }
        public int ToppingId { get; set; }

        public Pizza Pizza { get; set; }
        public Topping Topping { get; set; }
    }
}
