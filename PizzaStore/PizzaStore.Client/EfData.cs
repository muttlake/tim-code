

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
    }
}