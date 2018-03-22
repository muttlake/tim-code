
using System.Collections.Generic;
using PizzaStore.Library.Enums;

namespace PizzaStore.Library.Models
{
    public class Inventory
    {
        public Dictionary<CheeseEnum, int> Cheeses;
        public Dictionary<CrustEnum, int> Crusts;
        public Dictionary<SauceEnum, int> Sauces;
        public Dictionary<ToppingEnum, int> Toppings;

        public Inventory()
        {
            Cheeses = new Dictionary<CheeseEnum, int>();
            Crusts = new Dictionary<CrustEnum, int>();
            Sauces = new Dictionary<SauceEnum, int>();
            Toppings = new Dictionary<ToppingEnum, int>();
        }

        public override string ToString()
        {
            string outString = "";
            foreach(KeyValuePair<CheeseEnum, int> entry in Cheeses)
                outString += string.Format("\nInventory Cheese: {0} : {1}", entry.Key, entry.Value);
            foreach(KeyValuePair<CrustEnum, int> entry in Crusts)
                outString += string.Format("\nInventory Crust: {0} : {1}", entry.Key, entry.Value);
            foreach(KeyValuePair<SauceEnum, int> entry in Sauces)
                outString += string.Format("\nInventory Sauce: {0} : {1}", entry.Key, entry.Value);
            foreach(KeyValuePair<ToppingEnum, int> entry in Toppings)
                outString += string.Format("\nInventory Topping: {0} : {1}", entry.Key, entry.Value);
            return outString;
        } 
        
    }
}