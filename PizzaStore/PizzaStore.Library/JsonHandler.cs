using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using PizzaStore.Data;

namespace PizzaStore.Library
{
    public class JsonFormat
    {
        public List<string> connectionString { get; set; }
        public int MAX_CHEESES { get; set; }
        public int MAX_TOPPINGS { get; set; }
        public int MAX_ORDER_TOTAL { get; set; }
    }

    public class JsonHandler
    {
        //private string _jsonPath = "/c/Revature/tim.code/PizzaStore/PizzaStore.MVC/appsettings.dev.json";

     //   public JsonHandler()
	    //{

     //       JsonFormat obj = JsonConvert.DeserializeObject<JsonFormat>(data);
     //   }

    }
}
