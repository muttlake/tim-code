
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



        public override string ToString()
        {
            string outputString = "";
            outputString += string.Format("Crust: {0}", Crust);
            outputString += string.Format(", Sauce: {0}", Sauce);
            int counter = 0;
            foreach (var cheese in Cheeses.Read())
            {
                counter += 1;
                outputString += string.Format(", Cheese{0}: {1}", counter, cheese);
            }
            counter = 0;
            foreach (var topping in Toppings.Read())
            {
                counter += 1;
                outputString += string.Format(", Topping{0}: {1}", counter, topping);
            }
            return outputString;
        }

    }
}