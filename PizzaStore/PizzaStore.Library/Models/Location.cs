
using PizzaStore.Library.Enums;

namespace PizzaStore.Library.Models
{
    public class Location
    {
        public Inventory Inventory { get; }
        public string Street { get; set; }
        public string City { get; set; }
        public StateEnum State { get; set; }
        public string ZipCode { get; set; }

        public Location()
        {
            Street = "Default Street";
            City = "Defaulty City";
            State = StateEnum.AK;
            ZipCode = "0000000";
            Inventory = new Inventory();
        }

        public Location(string street, string city, StateEnum state, string zip)
        {
            Street = street;
            City = city;
            State = state;
            ZipCode = zip;
            Inventory = new Inventory();
        }

        public override string ToString()
        {
            string outString = "Location: ----- ";
            outString += $"{Street} , {City}, {State}, {ZipCode}";
            outString += string.Format("\nLocation Inventory: {0}", Inventory);
            return outString;
        }
    }
}