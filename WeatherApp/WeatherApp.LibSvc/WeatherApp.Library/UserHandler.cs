using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApp.Library
{
    public class UserHandler
    {
        private static AppSettingsHandler ash = new AppSettingsHandler();
        private static readonly string httpString = ash.JsonObject.DatabasePath.ToString();

        public int UserID { get; set; }

        public UserHandler()
        {
            var _requestString = httpString;
        }

        public UserHandler(int id)
        {
            UserID = id;
           var  _requestString = httpString;
        }

        public static async Task<List<User>> GetUserFromDataSvcAsync(int userid)
        {

            var client = new HttpClient();
            var result = await client.GetAsync("http://18.188.13.94/DataSvc/api/user/" + userid.ToString());

            if (result.IsSuccessStatusCode)
            {
                var user = JsonConvert.DeserializeObject<User>(await result.Content.ReadAsStringAsync());
                return new List<User>() { user };
            }
            else
                return null;
        }

        public static async Task<List<User>> GetAllUsersFromDataSvcAsync()
        {

            var client = new HttpClient();
            var result = await client.GetAsync("http://18.188.13.94/DataSvc/api/user");

            if (result.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<List<User>>(await result.Content.ReadAsStringAsync());
            }
            else
                return null;

        }
    }
}
