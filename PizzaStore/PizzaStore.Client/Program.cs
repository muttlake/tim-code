﻿using System;
using System.Collections.Generic;

namespace PizzaStore.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            PrintPizzaItems();
            PrintStateItems();
        }

        static void PrintPizzaItems()
        {
            var ed = new EfData();

            Console.WriteLine("Crusts: ");
            foreach (var crust in ed.ReadCrusts())
            {
                System.Console.Write("{0} {1} {2} ", crust.CrustId, crust.Crust1, crust.CrustCost);
                System.Console.Write("{0} {1}\n", crust.ModifiedDate, crust.Active);
            }

            Console.WriteLine("Sauces: ");
            foreach (var sauce in ed.ReadSauces())
            {
                System.Console.Write("{0} {1} {2} ", sauce.SauceId, sauce.Sauce1, sauce.SauceCost);
                System.Console.Write("{0} {1}\n", sauce.ModifiedDate, sauce.Active);
            }

            Console.WriteLine("Cheeses: ");
            foreach (var cheese in ed.ReadCheeses())
            {
                System.Console.Write("{0} {1} {2} ", cheese.CheeseId, cheese.Cheese1, cheese.CheeseCost);
                System.Console.Write("{0} {1}\n", cheese.ModifiedDate, cheese.Active);
            }

            Console.WriteLine("Toppings: ");
            foreach (var topping in ed.ReadToppings())
            {
                System.Console.Write("{0} {1} {2} ", topping.ToppingId, topping.Topping1, topping.ToppingCost);
                System.Console.Write("{0} {1}\n", topping.ModifiedDate, topping.Active);
            }
        }
        static void PrintStateItems()
        {
            var ed = new EfData();

            Console.WriteLine("States: ");
            foreach (var state in ed.ReadStates())
            {
                System.Console.Write("{0} {1}\n", state.StateId, state.StateAbb);
            }

            Console.WriteLine("Addresses: ");
            foreach (var address in ed.ReadAddresses())
            {
                System.Console.Write("{0} {1} {2} ", address.AddressId, address.Street, address.City);
                System.Console.Write("{0} {1} {2} ", address.ZipCode, address.ModifiedDate, address.Active);
                System.Console.Write("{0} {1} {2}\n", address.StateId, address.State.StateId, address.State.StateAbb);
            }
        }
    }
}
