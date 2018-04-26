using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApp.ClientLib
{
    public class JsonHandler
    {
        //url of the library service for ZipWeather
        private static AppSettingsHandler ash = new AppSettingsHandler();
        private static readonly string httpString = ash.JsonObject.LibraryPath.ToString();

        public int ZipCode { get; set; }


        public JsonHandler(int zip)
        {
            ZipCode = zip;
        }

        public static async Task<RootObject> GetRootObjectFromLibSvcAsync(int zip)
        {
            var client = new HttpClient();
            var result = await client.GetAsync("http://18.188.13.94/LibSvc/api/zipweather?zip=" + zip.ToString());

            if (result.IsSuccessStatusCode)
            {
                var content = await result.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<RootObject>(content);
            }
            else
                return null;
        }
    }
}
