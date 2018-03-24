using System;
using System.Collections.Generic;

namespace PizzaStore.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            var ed = new EfData();

            foreach (var item in ed.ReadPizzas())
            {
                System.Console.Write("{0} {1} {2} ", item.PizzaId, item.CrustId, item.SauceId);
                System.Console.Write("{0} {1} {2} ", item.TotalPizzaCost, item.OrderId, item.ModifiedDate);
                System.Console.Write("{0}\n", item.Active);
            }
        }
    }
}
