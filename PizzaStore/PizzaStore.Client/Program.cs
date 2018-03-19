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
            //PlayWithPizzas();
            PlayWithOrders();
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

        static void PlayWithOrders()
        {
            var orders = new List<Order>();

            var o1 = new Order();
            orders.Add(o1);
            orders.Add(new Order());
            
            var o2 = new Order();
            o2.Location.Street = "230 Palm Shadow Way";
            o2.Location.City = "Tampa";
            o2.Location.State = StateEnum.MD;
            o2.Location.ZipCode = "24234";
            o2.Location.Inventory.Cheeses[CheeseEnum.Mozzarella] = 2;
            o2.Location.Inventory.Cheeses[CheeseEnum.Cheddar] = 1;
            
            o2.Location.Inventory.Crusts[CrustEnum.HandTossed] = 20;
            o2.Location.Inventory.Crusts[CrustEnum.Thick] = 30;
            o2.Location.Inventory.Crusts[CrustEnum.Thin] = 10;

            o2.Location.Inventory.Sauces[SauceEnum.Tomato] = 50;
            o2.Location.Inventory.Sauces[SauceEnum.Pesto] = 34;

            o2.Location.Inventory.Toppings[ToppingEnum.Onion] = 12;
            o2.Location.Inventory.Toppings[ToppingEnum.Meatball] = 44;
            o2.Location.Inventory.Toppings[ToppingEnum.Mushroom] = 30;

            Console.WriteLine("Topping Onion: " + o2.Location.Inventory.Toppings[ToppingEnum.Onion].ToString());

            


            o2.Value = 1000.01;

            var p1 = new Pizza();
            o2.pizzas.Add(p1);
            o2.pizzas.Add(new Pizza());

            var p2 = new Pizza();
            p2.Crust = CrustEnum.Thin;
            p2.Cheeses.Add(CheeseEnum.Cheddar);
            p2.Cheeses.Add(CheeseEnum.Colby);
            p2.Toppings.Add(ToppingEnum.Pepperoni);
            p2.Toppings.Add(ToppingEnum.GreenPepper);
            p2.Toppings.Add(ToppingEnum.Meatball);
            p2.Toppings.Add(ToppingEnum.Onion);

            o2.pizzas.Add(p2);

            Console.WriteLine("Is o2 Valid: {0}", o2.IsValid());

            orders.Add(o2);

            foreach (var order in orders)
            {
                Console.WriteLine("Order -------------");
                Console.WriteLine(order);
            }
        }
    }
}
