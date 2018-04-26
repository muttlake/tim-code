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


    public class PostHandler
    {
        //This is the url to the library service
        private static AppSettingsHandler ash = new AppSettingsHandler();
        private static readonly string httpString = ash.JsonObject.LibraryPath.ToString();

        public int PostID { get; set; }

        public PostHandler()
        {
            // empty method
        }

        public PostHandler(int id)
        {
            PostID = id;
        }

        public static async Task<Post> GetPostFromDataSvcAsync(int pid)
        {
            var client = new HttpClient();
            var result = await client.GetAsync("http://18.188.13.94/LibSvc/api/postlib?pid" + pid.ToString());

            if (result.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<Post>(await result.Content.ReadAsStringAsync());
            }
            else
                return null;
        }

        public static async Task<List<Post>> GetAllPostsAsync()
        {
            var client = new HttpClient();
            var result = await client.GetAsync("http://18.188.13.94/LibSvc/api/postlib");

            if (result.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<List<Post>>(await result.Content.ReadAsStringAsync());
            }
            else
                return null;
        }

        public static async Task<List<PostWithUser>> GetAllPostsWithUserAsync()
        {
            var client = new HttpClient();
            var result = await client.GetAsync("http://18.188.13.94/LibSvc/api/postwithuserlib");

            if (result.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<List<PostWithUser>>(await result.Content.ReadAsStringAsync());
            }
            else
                return null;
        }

        public static async Task<Post> AddPost(User user, RootObject currentWeather, string imageFile, string blogPost)
        {

            var ct = Convert.ToInt32(currentWeather.main.temp);
            var cwj = JsonConvert.SerializeObject(currentWeather);
            var cwd = currentWeather.weather[0].description;
            var post = new Post(blogPost, imageFile, user.UserID, ct, cwj, cwd, user.HomeZipCode);

            var client = new HttpClient();
            var url = "http://18.188.13.94/DataSvc/api/post";
            var uri = new Uri(url);
            var data = JsonConvert.SerializeObject(post);
            var stringContent = new StringContent(data, Encoding.UTF8, "application/json");

            var result = await client.PostAsync(uri, stringContent);

            if (result.IsSuccessStatusCode)
            {
                Console.WriteLine("result: {0}", result.StatusCode);
                return post;
            }

            return null;
        }

    }
}
