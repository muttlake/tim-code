using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using WeatherApp.Library;

namespace WeatherApp.LibSvc.Controllers
{

    [EnableCors("allowAll")] //Enable Cross Origin Resource Sharing
    [Produces("application/json")] // Means every action result will always be a json type result
    [Route("api/[controller]")]
    public class ZipWeatherController : Controller
    {

        [HttpGet]
        public async Task<RootObject> Get(string zip = "default")
        {
            int zipCode = 0;
            if(Int32.TryParse(zip, out zipCode))
            {
                return await Task.Run(() => {
                    return JsonReader.GetRootObjectForZipCodeAsync(zipCode);
                });
            }
            else
                return await Task.Run(() => {
                    return JsonReader.GetRootObjectForZipCodeAsync(75762);
                });
        }

    }
}