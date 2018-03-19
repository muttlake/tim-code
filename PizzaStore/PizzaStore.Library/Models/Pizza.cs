
using System.Collections.Generic;
using PizzaStore.Library.Enums;

namespace PizzaStore.Library.Models
{
    public class Pizza 
    {
        private const int _maxCheeses = 2;
        private const int _maxToppings = 3;


        public CrustEnum Crust { get; set; }
        public SauceEnum Sauce { get; set; }
        public PizzaHelper<CheeseEnum> Cheeses { get; set; }
        public PizzaHelper<ToppingEnum> Toppings {get; set; }

        public Pizza()
        {
            Crust = CrustEnum.HandTossed;
            Sauce = SauceEnum.Tomato;
            Cheeses = new PizzaHelper<CheeseEnum>(_maxCheeses);
            Cheeses.Add(CheeseEnum.Mozzarella);
            Toppings = new PizzaHelper<ToppingEnum>(_maxToppings);
        }
    }
}