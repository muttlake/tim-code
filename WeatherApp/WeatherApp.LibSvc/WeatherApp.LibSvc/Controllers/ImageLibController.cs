using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WeatherApp.Library;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WeatherApp.LibSvc.Controllers
{
    public class ImageLibController : Controller
    {
        [HttpGet]
        public string Get()
        {
            return null;
        }

        [HttpPost]
        public async Task AddImageAsync()
        {
            var request_Body = new StreamReader(Request.Body).ReadToEnd();
            Console.WriteLine("request_Body: {0}", request_Body);

            //get url from appsettings.dev.json
            var ash = new AppSettingsHandler();
            var uri = new Uri("http://18.188.13.94/DataSvc/api/post");

            var rp = new RelayPost();
            await rp.RelayAddToDataSvc(uri, request_Body);
        }
    }
}
