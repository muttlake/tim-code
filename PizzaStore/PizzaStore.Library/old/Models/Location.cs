
using PizzaStore.Library.Enums;

namespace PizzaStore.Library.Models
{
    public class Location
    {
        public Inventory Inventory { get; }

        public Address Address { get; set; }
        
        public Location()
        {
            Address = new Address();
            Inventory = new Inventory();
        }

        public override string ToString()
        {
            string outString = "\nLocation: ----- ";
            outString += string.Format("\nLocation Address {0}", Address);
            outString += string.Format("\nLocation Inventory: {0}", Inventory);
            return outString;
        }
    }
}