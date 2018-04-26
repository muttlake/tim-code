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
    public class PostLibController : Controller
    {
        [HttpGet]
        public async Task<List<Post>> Get(string pid = "default")
        {
            int postID = 1;
            if (Int32.TryParse(pid, out postID))
            {
                return await Task.Run(() =>
                {
                    return PostHandler.GetPostFromDataSvcAsync(postID);
                });
            }
            else
                return await Task.Run(() =>
                {
                    return PostHandler.GetAllPostsFromDataSvcAsync();
                });
        }

        [HttpPost]
        public async Task RelayAddPostAsync()
        {
            var request_Body = new StreamReader(Request.Body).ReadToEnd();

            var ash = new AppSettingsHandler();
            var uri = new Uri("http://18.188.13.94/DataSvc/api/post");

            var rp = new RelayPost();
            await rp.RelayAddToDataSvc(uri, request_Body);

        }
    }
}