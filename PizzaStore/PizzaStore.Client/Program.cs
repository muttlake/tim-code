using System;
using System.Collections.Generic;
using PizzaStore.Library.Enums;
using PizzaStore.Library.Models;

namespace PizzaStore.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            PlayWithPizzas();
        }

        static void PlayWithPizzas()
        {
            var pizzas = new List<Pizza>();

            var p1 = new Pizza();
            pizzas.Add(p1);
            pizzas.Add(new Pizza());

            var p2 = new Pizza();
            p2.Crust = CrustEnum.Thin;
            p2.Cheeses.Add(CheeseEnum.Cheddar);
            p2.Cheeses.Add(CheeseEnum.Colby);
            p2.Toppings.Add(ToppingEnum.Pepperoni);
            p2.Toppings.Add(ToppingEnum.GreenPepper);
            p2.Toppings.Add(ToppingEnum.Meatball);
            p2.Toppings.Add(ToppingEnum.Onion);

            pizzas.Add(p2);

            foreach (var pizza in pizzas)
            {
                Console.WriteLine("Pizza: " + pizza.ToString());
            }
        }
    }
}
