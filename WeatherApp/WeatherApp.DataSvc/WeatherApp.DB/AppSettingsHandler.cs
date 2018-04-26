using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace WeatherApp.DB
{

    public class ConnectionStrings
    {
        public string DefaultConnection { get; set; }
    }

    public class AppSettingsFormat
    {
        public ConnectionStrings ConnectionStrings { get; set; }
        public string DatabasePath { get; set; }
        public string LibraryPath { get; set; }
        public string ClientPath { get; set; }
    }

    public class AppSettingsHandler
    {
        private string _jsonPath = "../appsettings.dev.json";

        public AppSettingsFormat JsonObject { get; set; }

        public AppSettingsHandler()
        {
            LoadJson();
        }

        public void LoadJson()
        {
            using (StreamReader r = new StreamReader(_jsonPath))
            {
                string json = r.ReadToEnd();
                JsonObject = JsonConvert.DeserializeObject<AppSettingsFormat>(json);
            }
        }
    }


}
