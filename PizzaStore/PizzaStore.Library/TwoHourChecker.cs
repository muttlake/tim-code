using System;
using System.Collections.Generic;
using System.Linq;
using PizzaStore.Data;

namespace PizzaStore.Library
{
    public class TwoHourChecker
    {
        private readonly PizzaStoreContext dbContext = new PizzaStoreContext();
        public int CustomerID { get; set; }
        public int LocationID { get; set; }
        public DateTime OrderTime { get; set; }

        public TwoHourChecker(int custID)
	    {
            CustomerID = custID;
            GetLastOrderTime();
	    }

        private void GetLastOrderTime()
        {
            OrderTime = dbContext.Order.Where(p => p.CustomerId == CustomerID).OrderByDescending(p => p.OrderTime).FirstOrDefault().OrderTime;
        }

        public bool OrderedWithinTwoHours()
        {
            DateTime currentTimeMinusTwoHours = DateTime.Now.AddHours(-2);
            int result = DateTime.Compare(currentTimeMinusTwoHours, OrderTime);
            return result <= 0;
        }

        public int GetLastLocation()
        {
            return dbContext.Order.Where(p => p.CustomerId == CustomerID).OrderByDescending(p => p.OrderTime).FirstOrDefault().LocationId;
        }

    }
}
