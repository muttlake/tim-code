using System;
using System.Collections.Generic;
using PizzaStore.Library;

namespace PizzaStore.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Pizza");
            //PrintPizzaItems();
            // InsertTest();
            // PrintLocationItems();
            //CreateAnOrder();
            //AddPizzaToOrder();
            NewOrderMaker();
        }

        static bool NewOrderMaker()
        {
            var initialOrder = new InitialOrder();
            List<int> cheeseIds = new List<int>() {1, 3};
            List<int> toppingIds = new List<int>() {7, 10, 11};
            return initialOrder.CreateNewOrderWithSinglePizza(2, 4, 4, 1, cheeseIds, toppingIds);
        }
        
        static void CreateAnOrder()
        {
            Console.WriteLine("Creating an order\n");

            Console.WriteLine("Listing all locations.");
            var ed = new EfData();
            foreach (var location in ed.ReadLocations())
            {
                System.Console.Write("LocationID: {0} AddressID: {1} InventoryID: {2} {3} {4}\n", location.LocationId, location.AddressId, location.InventoryId, location.ModifiedDate, location.Active);
                System.Console.Write("\tAddressID: {0} Street: {1} City: {2} ", location.Address.AddressId, location.Address.Street, location.Address.City);
                System.Console.Write("ZipCode: {0} {1} {2} ", location.Address.ZipCode, location.Address.ModifiedDate, location.Address.Active);
                System.Console.Write("StateID: {0}", location.Address.StateId);
                System.Console.Write(" StateID: {0} StateAbb: {1}\n", location.Address.State.StateId, location.Address.State.StateAbb);
                System.Console.Write("\tInventoryID: {0} Crust_Thin_Count: {1} Crust_HandTossed_Count: {2} ", location.Inventory.InventoryId, location.Inventory.CrustThinCount, location.Inventory.CrustHandTossedCount);
                System.Console.Write("CrustThickCount: {0} SauceTomatoCount: {1} Sauce Pesto Count: {2} ", location.Inventory.CrustThickCount, location.Inventory.SauceTomatoCount, location.Inventory.SaucePestoCount);
                System.Console.Write("CheeseMozzarellaCount: {0} CheeseCheddarCount: {1} CheeseColbyCount: {2} ", location.Inventory.CheeseMozzarellaCount, location.Inventory.CheeseCheddarCount, location.Inventory.CheeseColbyCount);
                System.Console.Write("ToppingPepperoniCount: {0} ToppingOnionCount: {1} ToppingGPCount: {2} ", location.Inventory.ToppingPepperoniCount, location.Inventory.ToppingOnionCount, location.Inventory.ToppingGreenPepperCount);
                System.Console.Write("ToppingMeatballCount: {0} ToppingMushroomCount: {1}\n", location.Inventory.ToppingMeatballCount, location.Inventory.ToppingMushroomCount);
            }
            
            
            Console.WriteLine("\nEnter Location: ");
            int locationEntered = Convert.ToInt32(Console.ReadLine());

            // if(ed.CheckLocation(locationEntered))
            //     Console.WriteLine("Location is valid.");
            // else
            //     Console.WriteLine("Location is not valid.");

            foreach(var customer in ed.ReadCustomers())
            {
                System.Console.Write("CustomerId: {0} AddressId: {1} Phone: {2} ", customer.CustomerId, customer.AddressId, customer.Phone);
                System.Console.Write("Email: {0} FirstName: {1} LastName: {2} {3} {4}\n", customer.Email, customer.FirstName, customer.LastName, customer.ModifiedDate, customer.Active);
                System.Console.Write("\tAddressID: {0} Street: {1} City: {2} ", customer.Address.AddressId, customer.Address.Street, customer.Address.City);
                System.Console.Write("ZipCode: {0} {1} {2} ", customer.Address.ZipCode, customer.Address.ModifiedDate, customer.Address.Active);
                System.Console.Write("StateID: {0}", customer.Address.StateId);
                System.Console.Write(" StateID: {0} StateAbb: {1}\n", customer.Address.State.StateId, customer.Address.State.StateAbb);
            }

            Console.WriteLine("\nEnter customer: ");
            int customerEntered = Convert.ToInt32(Console.ReadLine());

            if(ed.CheckCustomer(customerEntered))
                Console.WriteLine("Customer is valid.");
            else
                Console.WriteLine("Customer is not valid.");

            Console.WriteLine("Create a new order.");

            ed.NewOrder(locationEntered, customerEntered);

        }

        static void AddPizzaToOrder()
        {
            Console.WriteLine("Listing all orders.");
            var ed = new EfData();
            foreach (var order in ed.ReadOrders())
            {
                System.Console.Write("OrderID: {0} LocationID: {1} TotalValue: {2} OrderTime: {3} CustomerId{4}", order.OrderId, order.LocationId, order.TotalValue, order.OrderTime, order.CustomerId);
                System.Console.Write(" ModifiedDate: {0} Active: {1}\n", order.ModifiedDate, order.Active);
            }
            
            Console.WriteLine("\nEnter order: ");
            int orderEntered = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter Stop to Stop adding pizzas to order");
            string userStop = Console.ReadLine();
            while(!userStop.Equals("Stop"))
            {
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

                Console.WriteLine("Enter CrustID: ");
                int crustEntered = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Enter SauceID: ");
                int sauceEntered = Convert.ToInt32(Console.ReadLine());



                Console.WriteLine("Now add cheeses, Say OK To stop: ");
                var cheeseStop = Console.ReadLine();

                List<int> cheeseIDs = new List<int>();
                while(!cheeseStop.Equals("Stop"))
                {
                    Console.WriteLine("Enter CheeseID: ");
                    var cheeseID = Convert.ToInt32(Console.ReadLine());
                    cheeseIDs.Add(cheeseID);
                    Console.WriteLine("Say OK To stop adding cheeses: ");
                    cheeseStop = Console.ReadLine();
                }

                Console.WriteLine("Now add toppings, Say OK To stop: ");
                var toppingStop = Console.ReadLine();
                List<int> toppingIDs = new List<int>();
                while(!cheeseStop.Equals("Stop"))
                {
                    Console.WriteLine("Enter ToppingID: ");
                    var toppingID = Convert.ToInt32(Console.ReadLine());
                    toppingIDs.Add(toppingID);
                    Console.WriteLine("Say OK To stop adding toppings: ");
                    toppingStop = Console.ReadLine();
                }

                //ed.AddPizza(orderEntered, crustEntered, sauceEntered, cheeseIDs, toppingIDs);


                Console.WriteLine("Enter Stop to Stop adding pizzas to order");
                userStop = Console.ReadLine();
            }
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

            Console.WriteLine("Locations: ");
            // foreach (var location in ed.ReadLocations())
            // {
            //     System.Console.Write("{0} {1} {2} {3} {4}\n", location.LocationId, location.AddressId, location.InventoryId, location.ModifiedDate, location.Active);
            //     System.Console.Write("\t{0} {1} {2} ", location.Address.AddressId, location.Address.Street, location.Address.City);
            //     System.Console.Write("{0} {1} {2} ", location.Address.ZipCode, location.Address.ModifiedDate, location.Address.Active);
            //     System.Console.Write("{0} {1}", location.Address.StateId, location.InventoryId);
            //     System.Console.Write(" {0} {1}\n", location.Address.State.StateId, location.Address.State.StateAbb);
            //     System.Console.Write("\t{0} {1} {2} ", location.Inventory.InventoryId, location.Inventory.CrustThinCount, location.Inventory.CrustHandTossedCount);
            //     System.Console.Write("{0} {1} {2} ", location.Inventory.CrustThickCount, location.Inventory.SauceTomatoCount, location.Inventory.SaucePestoCount);
            //     System.Console.Write("{0} {1} {2} ", location.Inventory.CheeseMozzarellaCount, location.Inventory.CheeseCheddarCount, location.Inventory.CheeseColbyCount);
            //     System.Console.Write("{0} {1} {2} ", location.Inventory.ToppingPepperoniCount, location.Inventory.ToppingOnionCount, location.Inventory.ToppingGreenPepperCount);
            //     System.Console.Write("{0} {1}\n", location.Inventory.ToppingMeatballCount, location.Inventory.ToppingMushroomCount);
            // }
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
