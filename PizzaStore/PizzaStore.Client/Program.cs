using System;
using System.Collections.Generic;

namespace PizzaStore.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            PrintPizzaItems();
            InsertTest();
            PrintLocationItems();
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
        static void PrintLocationItems()
        {
            var ed = new EfData();

            // Console.WriteLine("States: ");
            // foreach (var state in ed.ReadStates())
            // {
            //     System.Console.Write("{0} {1}\n", state.StateId, state.StateAbb);
            // }

            // Console.WriteLine("Addresses: ");
            // foreach (var address in ed.ReadAddresses())
            // {
            //     System.Console.Write("{0} {1} {2} ", address.AddressId, address.Street, address.City);
            //     System.Console.Write("{0} {1} {2} ", address.ZipCode, address.ModifiedDate, address.Active);
            //     System.Console.Write("{0}", address.StateId);
            //     System.Console.Write(" {0} {1}\n" , address.State.StateId, address.State.StateAbb);
            //     // if(address.State != null)
            //     //     System.Console.Write(" {0} {1}\n" , address.State.StateId, address.State.StateAbb);
            //     // else
            //     //     System.Console.Write("Null State\n");
            // }

            Console.WriteLine("Locations: ");
            foreach (var location in ed.ReadLocations())
            {
                System.Console.Write("{0} {1} {2} {3} {4}\n", location.LocationId, location.AddressId, location.InventoryId, location.ModifiedDate, location.Active);
                System.Console.Write("\t{0} {1} {2} ", location.Address.AddressId, location.Address.Street, location.Address.City);
                System.Console.Write("{0} {1} {2} ", location.Address.ZipCode, location.Address.ModifiedDate, location.Address.Active);
                System.Console.Write("{0} {1}", location.Address.StateId, location.InventoryId);
                System.Console.Write(" {0} {1}\n", location.Address.State.StateId, location.Address.State.StateAbb);
                System.Console.Write("\t{0} {1} {2} ", location.Inventory.InventoryId, location.Inventory.CrustThinCount, location.Inventory.CrustHandTossedCount);
                System.Console.Write("{0} {1} {2} ", location.Inventory.CrustThickCount, location.Inventory.SauceTomatoCount, location.Inventory.SaucePestoCount);
                System.Console.Write("{0} {1} {2} ", location.Inventory.CheeseMozzarellaCount, location.Inventory.CheeseCheddarCount, location.Inventory.CheeseColbyCount);
                System.Console.Write("{0} {1} {2} ", location.Inventory.ToppingPepperoniCount, location.Inventory.ToppingOnionCount, location.Inventory.ToppingGreenPepperCount);
                System.Console.Write("{0} {1}\n", location.Inventory.ToppingMeatballCount, location.Inventory.ToppingMushroomCount);
            }
        }

        static void InsertTest()
        {
            var ed = new EfData();

            Console.WriteLine("Crusts: ");
            foreach (var crust in ed.ReadCrusts())
            {
                System.Console.Write("{0} {1} {2} ", crust.CrustId, crust.Crust1, crust.CrustCost);
                System.Console.Write("{0} {1}\n", crust.ModifiedDate, crust.Active);
            }

            ed.InsertCrust();

            Console.WriteLine("Crusts: ");
            foreach (var crust in ed.ReadCrusts())
            {
                System.Console.Write("{0} {1} {2} ", crust.CrustId, crust.Crust1, crust.CrustCost);
                System.Console.Write("{0} {1}\n", crust.ModifiedDate, crust.Active);
            }
        }
    }
}
