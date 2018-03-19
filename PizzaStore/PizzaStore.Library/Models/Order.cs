

using System.Collections.Generic;

namespace PizzaStore.Library.Models
{
    public class Order
    {
        private double _maxOrderValue = 1000.00;
        public Location Location { get; set; }
        public double Value { get; set; }
        public OrderHelper<Pizza> pizzas;
        public Order()
        {
            Value = 0.00;
            Location = new Location();
            pizzas = new OrderHelper<Pizza>();
            pizzas.Add(new Pizza());
        }
        
        public override string ToString()
        {
            string outString = "";

            outString += string.Format("Location: {0}", Location.ToString());
            outString += string.Format("\nValue: {0}", Value);
            foreach (var pizza in pizzas.Read())
                outString += string.Format("\nIncludesPizza: {0}", pizza);

            return outString;
        }

        public bool IsValid()
        {
            return Value <= _maxOrderValue;
        }
    }
}