using System;
using System.Collections.Generic;

namespace PizzaStore.Data
{
    public partial class Inventory
    {
        public Inventory()
        {
            Location = new HashSet<Location>();
        }

        public int InventoryId { get; set; }
        public int CrustThinCount { get; set; }
        public int CrustHandTossedCount { get; set; }
        public int CrustThickCount { get; set; }
        public int SauceTomatoCount { get; set; }
        public int SaucePestoCount { get; set; }
        public int CheeseMozzarellaCount { get; set; }
        public int CheeseCheddarCount { get; set; }
        public int CheeseColbyCount { get; set; }
        public int ToppingPepperoniCount { get; set; }
        public int ToppingOnionCount { get; set; }
        public int ToppingGreenPepperCount { get; set; }
        public int ToppingMeatballCount { get; set; }
        public int ToppingMushroomCount { get; set; }

        public ICollection<Location> Location { get; set; }
    }
}
