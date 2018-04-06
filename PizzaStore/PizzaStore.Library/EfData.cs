 
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
        private readonly PizzaStoreContext dbContext = new PizzaStoreContext();

        public List<Pizza> ReadPizzas()
        {
            return dbContext.Pizza.ToList();
        }

        public List<Pizza> GetPizzasInOrder(int orderID)
        {
            return dbContext.Pizza.Where(p => p.OrderId == orderID).ToList();
        }

        public List<Crust> ReadCrusts()
        {
            return dbContext.Crust.ToList();
        }

        public List<Pizza2> GetPizza2sForOrder(int orderID)
        {
            return dbContext.Pizza2.Where(p => p.OrderId == orderID).ToList();
        }

        public bool ValidateLocation(int locID)
        {
            return dbContext.Location.Where(predicate: p => p.LocationId == locID).Count() == 1;
        }

        public bool ValidateCustomer(int locID)
        {
            return dbContext.Customer.Where(predicate: p => p.CustomerId == locID).Count() == 1;
        }

        public bool ValidateOrder(int orderId)
        {
            return dbContext.Order.Where(predicate: p => p.OrderId == orderId).Count() == 1;
        }

        public bool ValidateCrust(int crustID)
        {
            return dbContext.Crust.Where(predicate: p => p.CrustId == crustID).Count() == 1;
        }

        public bool ValidateSauce(int sauceId)
        {
            return dbContext.Sauce.Where(predicate: p => p.SauceId == sauceId).Count() == 1;
        }

        public bool ValidateCheese(int cheeseID)
        {
            return dbContext.Cheese.Where(predicate: p => p.CheeseId == cheeseID).Count() == 1;
        }

        public bool ValidateTopping(int toppingID)
        {
            return dbContext.Topping.Where(predicate: p => p.ToppingId == toppingID).Count() == 1;
        }

        public List<Sauce> ReadSauces()
        {
            return dbContext.Sauce.ToList();
        }

        public List<int> GetAllPizzaIDsForOrder(int orderId)
        {
            return dbContext.Pizza.Where(p => p.OrderId == orderId).Select(p => p.PizzaId).ToList();
        }

        public string GetPizzaStringByPizzaID(int pizzaID)
        {
            Pizza pizza = dbContext.Pizza.Where(p => p.PizzaId == pizzaID).FirstOrDefault();
            Crust crust = dbContext.Crust.Where(c => c.CrustId == pizza.CrustId).FirstOrDefault();
            Sauce sauce = dbContext.Sauce.Where(s => s.SauceId == pizza.SauceId).FirstOrDefault();
            List<Cheese> cheeses = GetListCheesesByPizzaID(pizzaID);
            List<Topping> toppings = GetListToppingsByPizzaID(pizzaID);

            string pizzaString = "";

            pizzaString += "$" + pizza.TotalPizzaCost + " " + crust.Crust1 + ", " + sauce.Sauce1;
            foreach (var c in cheeses)
                pizzaString += ", " + c.Cheese1;
            foreach (var t in toppings)
                pizzaString += ", " + t.Topping1;

            return pizzaString;
        }

        public List<Cheese> GetListCheesesByPizzaID(int pid)
        {
            List<PizzaHasCheese> phc = dbContext.PizzaHasCheese.Where(p => p.PizzaId == pid).ToList();
            List<Cheese> cheesesOnPizza = new List<Cheese>();
            foreach (var pizzaCheese in phc)
                cheesesOnPizza.Add(dbContext.Cheese.Where(p => p.CheeseId == pizzaCheese.CheeseId).FirstOrDefault());
            return cheesesOnPizza;
        }

        public List<Topping> GetListToppingsByPizzaID(int pid)
        {
            List<PizzaHasTopping> pht = dbContext.PizzaHasTopping.Where(p => p.PizzaId == pid).ToList();
            List<Topping> toppingsOnPizza = new List<Topping>();
            foreach (var pizzaTopping in pht)
                toppingsOnPizza.Add(dbContext.Topping.Where(p => p.ToppingId == pizzaTopping.ToppingId).FirstOrDefault());
            return toppingsOnPizza;
        }

        public Order GetMostRecentOrderForCustomer(int custId)
        {
            return dbContext.Order.Where(p => p.CustomerId == custId).Last();
        }

        public List<Cheese> ReadCheeses()
        {
            return dbContext.Cheese.ToList();
        }

        public Order GetOrderById(int id)
        {
            return dbContext.Order.Where(p => p.OrderId == id).FirstOrDefault();
        }

        public int GetLocationIDForOrder(int orderId)
        {
            return dbContext.Order.Where(p => p.OrderId == orderId).FirstOrDefault().LocationId;
        }

        public double GetCostForOrder(int orderId)
        {
            return dbContext.Order.Where(p => p.OrderId == orderId).FirstOrDefault().TotalValue.Value;
        }

        public string GetCustomerNameByID(int id)
        {
            if (dbContext.Customer.Where(p => p.CustomerId == id).Count() == 0)
                return "";
            string fullName = dbContext.Customer.Where(p => p.CustomerId == id).FirstOrDefault().FirstName;
            fullName += " " + dbContext.Customer.Where(p => p.CustomerId == id).FirstOrDefault().LastName;
            return fullName;
        }

        public string GetLocationByID(int id)
        {
            if (dbContext.Location.Where(p => p.LocationId == id).Count() == 0)
                return "";
            int AddressID = dbContext.Location.Where(p => p.LocationId == id).FirstOrDefault().AddressId;
            Address address = dbContext.Address.Where(p => p.AddressId == AddressID).FirstOrDefault();
            int StateID = dbContext.Address.Where(p => p.AddressId == address.AddressId).FirstOrDefault().StateId;
            State state = dbContext.State.Where(p => p.StateId == StateID).FirstOrDefault();

            string locationAddress = address.Street;
            locationAddress += ", " + address.City;
            locationAddress += ", " + state.StateAbb;
            locationAddress += ", " + address.ZipCode;
            return locationAddress;
        }

        public string GetCrustByID(int id)
        {
            if (dbContext.Crust.Where(p => p.CrustId == id).Count() == 0)
                return "";
            else
                return dbContext.Crust.Where(p => p.CrustId == id).FirstOrDefault().Crust1;
        }

        public string GetSauceByID(int id)
        {
            if (dbContext.Sauce.Where(p => p.SauceId == id).Count() == 0)
                return "";
            else
                return dbContext.Sauce.Where(p => p.SauceId == id).FirstOrDefault().Sauce1;
        }

        public string GetCheeseByID(int id)
        {
            if (dbContext.Cheese.Where(p => p.CheeseId == id).Count() == 0)
                return "";
            else
                return dbContext.Cheese.Where(p => p.CheeseId == id).FirstOrDefault().Cheese1;
        }

        public string GetToppingByID(int id)
        {
            if (dbContext.Topping.Where(p => p.ToppingId == id).Count() == 0)
                return "";
            else
                return dbContext.Topping.Where(p => p.ToppingId == id).FirstOrDefault().Topping1;
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

        public List<Order> GetOrdersForCustomer(int custId)
        {
            return dbContext.Order.Where(p => p.CustomerId == custId && p.Active == true).ToList();
        }

        public List<int> GetOrderIdsForCustomer(int custId)
        {
            return dbContext.Order.Where(p => p.CustomerId == custId && p.Active == true).Select(p => p.OrderId).ToList();
        }

        public double GetCrustCost(int id)
        {
            return dbContext.Crust.Where(p => p.CrustId == id).FirstOrDefault().CrustCost;
        }

        public double GetSauceCost(int id)
        {
            return dbContext.Sauce.Where(p => p.SauceId == id).FirstOrDefault().SauceCost;
        }

        public double GetToppingCost(int id)
        {
            return dbContext.Topping.Where(p => p.ToppingId == id).FirstOrDefault().ToppingCost;
        }

        public double GetCheeseCost(int id)
        {
            return dbContext.Cheese.Where(p => p.CheeseId == id).FirstOrDefault().CheeseCost;
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

        public List<Pizza> GetPizzasForOrder(int orderID)
        {
            return dbContext.Pizza.Where(p => p.OrderId == orderID && p.Active == true).ToList();
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
