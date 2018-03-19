
using System.Collections.Generic;

namespace PizzaStore.Library.Models
{
    public class User
    {
        public Name Name { get; set; }

        public Address Address { get; set; }

        public Dictionary<long, Order> OrderHistory;

        public User()
        {
            Name = new Name();
            Address = new Address();
            OrderHistory = new Dictionary<long, Order>();
        }

        public override string ToString()
        {
            string outString = "";
            outString += string.Format("User Name: {0}", Name);
            outString += string.Format("\nUser Address: {0}", Address);
            foreach(KeyValuePair<long, Order> entry in OrderHistory)
                outString += string.Format("\nUser Order History: {0} : {1}", entry.Key, entry.Value);
            return outString;
        }

    }
}