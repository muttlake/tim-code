

using System.Collections.Generic;
using System.Linq;
using PizzaStore.Library;

namespace PizzaStore.Client
{
    public class EfData
    {
        // Something else is managing connection
        private PizzaStoreContext db = new PizzaStoreContext();

        public List<Pizza> ReadPizzas()
        {
            return db.Pizza.ToList();
        }

        public List<Crust> ReadCrusts()
        {
            return db.Crust.ToList();
        }

        public List<Sauce> ReadSauces()
        {
            return db.Sauce.ToList();
        }

        public List<Cheese> ReadCheeses()
        {
            return db.Cheese.ToList();
        }

        public List<Topping> ReadToppings()
        {
            return db.Topping.ToList();
        }
        public List<State> ReadStates()
        {
            return db.State.ToList();
        }

        public List<Address> ReadAddresses()
        {
            return db.Address.ToList();
        }

        public List<Location> ReadLocations()
        {
            return db.Location.ToList();
        }
    }
}