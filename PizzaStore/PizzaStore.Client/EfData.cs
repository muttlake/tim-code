

using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using PizzaStore.Library;

namespace PizzaStore.Client
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

        
        public bool CheckCustomer(int cust)
        {
            List<int> customerIDs = new List<int>();
            foreach (var customer in ReadCustomers())
                customerIDs.Add(customer.CustomerId);
            return customerIDs.Contains(cust);
        }


        public List<Customer> ReadCustomers()
        {
            var customers = dbContext.Customer
                            .Include(p => p.Address)
                            .Include(p => p.Address.State);
            return customers.ToList();
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
    }
}