using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using WeatherApp.Library;

namespace WeatherApp.LibSvc.Controllers
{
    [EnableCors("allowAll")] //Enable Cross Origin Resource Sharing
    [Produces("application/json")] // Means every action result will always be a json type result
    [Route("api/[controller]")]
    public class UserLibController : Controller
    {       
        [HttpGet]
        public async Task<List<User>> Get(string uid = "default")
        {   
            Console.WriteLine("\n\n\nLibSvc userlib Get");
            int userID = 0;
            if (Int32.TryParse(uid, out userID))
            {
                return await Task.Run(() =>
                {
                    return UserHandler.GetUserFromDataSvcAsync(userID);
                });
            }
            else
                return await Task.Run(() =>
                {
                    return UserHandler.GetAllUsersFromDataSvcAsync();
                });
        }

        [HttpPost]
        public async Task RelayAddUserAsync()
        {

            var request_Body = new StreamReader(Request.Body).ReadToEnd();

            var ash = new AppSettingsHandler();
            var uri = new Uri("http://18.188.13.94/DataSvc/api/user");

            var rp = new RelayPost();
            await rp.RelayAddToDataSvc(uri, request_Body);
        }

    }
}