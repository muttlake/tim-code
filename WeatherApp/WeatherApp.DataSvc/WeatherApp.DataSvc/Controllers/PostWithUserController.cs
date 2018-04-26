using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WeatherApp.DataSvc.Models;
using WeatherApp.DataSvc.WeatherApp.DB;

namespace WeatherApp.DataSvc.Controllers
{
    [EnableCors("allowAll")] //Enable Cross Origin Resource Sharing
    [Route("api/[controller]")]
    [Produces("application/json")] // Means every action result will always be a json type result
    public class PostWithUserController : Controller
    {

        private readonly WeatherAppContext context;

        public PostWithUserController(WeatherAppContext db)
        {
            context = db;
        }

        [HttpGet]
        public async Task<IEnumerable<PostWithUser>> Get()
        {
            return await Task.Run(() => {

                var pwusQuery = from p in context.Posts
                                join u in context.Users
                                on p.UserID equals u.UserID
                                orderby p.PostID descending
                                select new
                                {
                                     p.PostID,
                                     p.BlogPost,
                                     p.ImageFile,
                                     p.WeatherType,
                                     p.ZipCode,
                                     p.TempFahr,
                                     p.WeatherJson,
                                     p.PublishDateTime,
                                     u.UserID,
                                     u.FirstName,
                                     u.LastName,
                                     u.Username
                                };

                var pwus = new List<PostWithUser>();

                foreach(var item in pwusQuery)
                {
                    var postWithUser = new PostWithUser(item.PostID, item.BlogPost, item.ImageFile, item.WeatherType, item.ZipCode, 
                                                    item.TempFahr, item.WeatherJson, item.PublishDateTime, 
                                                    item.UserID, item.FirstName, item.LastName, 
                                                    item.Username);
                    pwus.Add(postWithUser);
                }

                return pwus;
            });
        }

        [HttpGet("{postid}")] // here must put in /<idvalue> to ge
        public async Task<PostWithUser> Get(string postid)
        {
            int postID = 1;
            if (Int32.TryParse(postid, out postID))
                return await Task.Run(() =>
                {
                    var pwusQuery = from p in context.Posts
                                    join u in context.Users
                                    on p.UserID equals u.UserID
                                    orderby p.PostID descending
                                    select new
                                    {
                                        p.PostID,
                                        p.BlogPost,
                                        p.ImageFile,
                                        p.WeatherType,
                                        p.ZipCode,
                                        p.TempFahr,
                                        p.WeatherJson,
                                        p.PublishDateTime,
                                        u.UserID,
                                        u.FirstName,
                                        u.LastName,
                                        u.Username
                                    };

                    PostWithUser pwu = new PostWithUser();

                    foreach (var item in pwusQuery)
                    {
                        if(item.PostID == postID)
                        {
                            var matching_pwu = new PostWithUser(item.PostID, item.BlogPost, item.ImageFile, item.WeatherType, item.ZipCode,
                                                       item.TempFahr, item.WeatherJson, item.PublishDateTime,
                                                       item.UserID, item.FirstName, item.LastName,
                                                       item.Username);
                            pwu = matching_pwu;
                        }
                    }
                    return pwu;
                });
            return await Task.Run(() =>
                {
                    return new PostWithUser();
                });
        }
    }
}
