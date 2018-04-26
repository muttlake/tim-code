using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace WeatherApp.Library
{
    public class JsonReader
    {
        // Our Key for the Open Weather API
        private static readonly string _apiKey = "a6acab0d579d6ac71c21659ff3de726d";

        public int InputZipCode { get; set; }
        public string WeatherApiResponse { get; set; }

        public RootObject RootObject { get; set; }

        public JsonReader()
        {
            WeatherApiResponse = "";
            InputZipCode = 0;
        }

        public JsonReader(int zip)
        {
            WeatherApiResponse = "";
            InputZipCode = zip;
        }

        public static string FormatInputZipCode(int zip)
        {
            string zipString = zip.ToString();
            string outString = "";
            for (int i = 0; i < 5 - zipString.Length; i++)
                outString += "0";
            outString += zipString;
            return outString;
        }

        public void MakeRootObject()
        {
            RootObject = JsonConvert.DeserializeObject<RootObject>(WeatherApiResponse);
        }

        public RootObject GetRootObjectForZipCode()
        {
            Console.WriteLine("InputZipString {0}", FormatInputZipCode(InputZipCode));
            string requestString = "http://api.openweathermap.org/data/2.5/weather?zip=" + FormatInputZipCode(InputZipCode) + ",us&units=imperial&appid=" + _apiKey;


            var drh = new DataSvcRequestHandler();
            return JsonConvert.DeserializeObject<RootObject>(drh.GetJsonResponse(requestString).GetAwaiter().GetResult());
        }

        public static async Task<RootObject> GetRootObjectForZipCodeAsync(int zipCode)
        {
            var client = new HttpClient();
            string requestString = "http://api.openweathermap.org/data/2.5/weather?zip=" + FormatInputZipCode(zipCode) + ",us&units=imperial&appid=" + _apiKey;
            var result = await client.GetAsync(requestString);

            if (result.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<RootObject>(await result.Content.ReadAsStringAsync());
            }
            else
                return null;
        }

    }
}