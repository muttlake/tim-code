using System;
using System.Collections.Generic;
using System.IO;
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
        //public int HOURS_BETWEEN_ORDERS { get; set; }
    }

    public class JsonHandler
    {
        private string _jsonPath = "/Revature/tim.code/PizzaStore/PizzaStore.MVC/appsettings.dev.json";

        public JsonFormat JsonObject { get; set; }

        public JsonHandler()
        {
            LoadJson();
        }

        public void LoadJson()
        {
            using (StreamReader r = new StreamReader(_jsonPath))
            {
                string json = r.ReadToEnd();
                JsonObject = JsonConvert.DeserializeObject<JsonFormat>(json);
            }
        }
    }


}
