

using System.Collections.Generic;
using System.Linq;
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
            return dbContext.Address.ToList();
        }

        public List<Location> ReadLocations()
        {
            return dbContext.Location.ToList();
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