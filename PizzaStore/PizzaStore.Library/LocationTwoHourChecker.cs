using System;
using System.Collections.Generic;
using System.Linq;
using PizzaStore.Data;

namespace PizzaStore.Library
{
    public class LocationTwoHourChecker
    {
        private PizzaStoreContext dbContext = new PizzaStoreContext();
        public int LocationID { get; set; }
        public int CustomerID { get; set; }
        public DateTime OrderTime { get; set; }

        public LocationTwoHourChecker(int locID, int custID, DateTime orderTime)
	    {
            LocationID = locID;
            CustomerID = custID;
            OrderTime = orderTime;
	    }





    }
}
