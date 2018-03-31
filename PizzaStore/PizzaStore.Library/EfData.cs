 
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using PizzaStore.Data;
using PizzaStore.Library;

namespace PizzaStore.Library
{
    public class EfData
    {
        // Something else is managing connection
        private PizzaStoreContext dbContext = new PizzaStoreContext();

        public List<Pizza> ReadPizzas()
        {
            return dbContext.Pizza.ToList();
        }

        public List<Crust> ReadCrusts()
        {
            return dbContext.Crust.ToList();
        }

        public List<Sauce> ReadSauces()
        {
            return dbContext.Sauce.ToList();
        }

        public List<Cheese> ReadCheeses()
        {
            return dbContext.Cheese.ToList();
        }

        public int ConvertNameToCustomerID(string fullName)
        {
            string[] names = fullName.Split(' ');
            if (names.Length != 2)
                return -999;
            string firstName = names[0];
            string lastName = names[1];
            if (dbContext.Customer.Where(c => c.FirstName == firstName && c.LastName == lastName).Count() == 0)
                return -999;
            else
                return dbContext.Customer.Where(c => c.FirstName == firstName && c.LastName == lastName).FirstOrDefault().CustomerId;
        }

        public List<Topping> ReadToppings()
        {
            return dbContext.Topping.ToList();
        }

        public List<State> ReadStates()
        {
            return dbContext.State.ToList();
        }

        public List<Address> ReadAddresses()
        {
            var addresses = dbContext.Address
                            .Include(p => p.State);
            return addresses.ToList();
        }

        public List<Location> ReadLocations()
        {
            var locations = dbContext.Location
                            .Include(p => p.Address)
                            .Include(p => p.Address.State)
                            .Include(p => p.Inventory);
            return locations.ToList();
        }

        public bool CheckLocation(int loc)
        {
            List<int> locationIDs = new List<int>();
            foreach (var location in ReadLocations())
                locationIDs.Add(location.LocationId);
            return locationIDs.Contains(loc);
        }

        //public List<Customer> R()
        //{
        //    return dbContext.Customer.ToList();
        //}

        public bool CheckCustomer(int cust)
        {
            List<int> customerIDs = new List<int>();
            foreach (var customer in ReadCustomers())
                customerIDs.Add(customer.CustomerId);
            return customerIDs.Contains(cust);
        }


        public List<Customer> ReadCustomers()
        {
            return dbContext.Customer.ToList();
        }

        public void InsertCrust()
        {
            Crust crust = new Crust();
            crust.Crust1 = "Fake";
            crust.CrustCost = 9.00;
            crust.ModifiedDate = System.DateTime.Now;
            dbContext.Crust.Add(crust);
            dbContext.SaveChanges();
        }

        public List<Order> ReadOrders()
        {
            var orders = dbContext.Order
                            .Include(p => p.Location)
                            .Include(p => p.Customer)
                            .Include(p => p.Pizza);
            return orders.ToList();
        }

        public void NewOrder(int locationId, int customerID)
        {
            if(!CheckCustomer(customerID) || !CheckLocation(locationId))
                System.Console.WriteLine("Bad order parameters");
            else
            {
                Order order = new Order();
                order.LocationId = locationId;
                order.CustomerId = customerID;
                order.TotalValue = 0.00;
                order.OrderTime = System.DateTime.Now;
                order.ModifiedDate = System.DateTime.Now;
                dbContext.Order.Add(order);
                dbContext.SaveChanges();
                System.Console.WriteLine("Successfully created empty order.");
            }

        }

        
        public void AddPizza(int orderID, int crustID, int sauceID, List<int> cheeseIDs, List<int> toppingIDs)
        {
            if(!CheckOrder(orderID) || !CheckCrust(crustID) || !CheckSauce(sauceID))
                System.Console.WriteLine("Bad pizza parameters");
            else
            {
                //PizzaCreator pc = new PizzaCreator(orderID);
            }
        }



        public bool CheckOrder(int orderNum)
        {
            List<int> orderIDs = new List<int>();
            foreach (var order in ReadOrders())
                orderIDs.Add(order.OrderId);
            return orderIDs.Contains(orderNum);
        }

        public bool CheckCrust(int crustNum)
        {
            List<int> crustIDs = new List<int>();
            foreach (var crust in ReadCrusts())
                crustIDs.Add(crust.CrustId);
            return crustIDs.Contains(crustNum);
        }


        public bool CheckSauce(int sauceNum)
        {
            List<int> sauceIDs = new List<int>();
            foreach (var sauce in ReadSauces())
                sauceIDs.Add(sauce.SauceId);
            return sauceIDs.Contains(sauceNum);
        }
    }
}