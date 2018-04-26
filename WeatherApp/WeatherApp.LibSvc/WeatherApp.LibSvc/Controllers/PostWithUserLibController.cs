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
    public class PostWithUserLibController : Controller
    {
        [HttpGet]
        public async Task<List<PostWithUser>> Get(string pid = "default")
        {
            int postID = 1;
            if (Int32.TryParse(pid, out postID))
            {
                return await Task.Run(() =>
                {
                    return PostHandler.GetPostsWithUserFromDataSvcAsync(postID);
                });
            }
            else
                return await Task.Run(() =>
                {
                    return PostHandler.GetAllPostsWithUserFromDataSvcAsync();
                });
        }

    }
}