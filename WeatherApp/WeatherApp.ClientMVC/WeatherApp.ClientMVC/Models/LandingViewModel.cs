using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeatherApp.ClientLib;
using Newtonsoft.Json;

namespace WeatherApp.ClientMVC.Models
{
    public class PostWithWeather
    {
        public Post Post { get; set; }
        public RootObject Weather { get; set; }

        public string WeatherIconImage { get; set; }
       
    }

    public class LandingViewModel
    {
        public User User { get; set; }
        public Post Post { get; set; }
        public List<Post> Posts { get; set; }

        public List<PostWithWeather> PostsWithWeather { get; set; }
        public RootObject HomeZipRootObject { get; set; }

        public RootObject Weather { get; set; }
        public string WeatherIcon { get; set; }

        

        public LandingViewModel(User u)
        {
            User = u;
            HomeZipRootObject = JsonHandler.GetRootObjectFromLibSvcAsync(u.HomeZipCode).GetAwaiter().GetResult();
            SetWeatherIcon();
            GetPosts();
            GetPostsWithWeather();
        }

        public void GetPosts()
        {
            Posts = new List<Post>();
            var currentPosts = PostHandler.GetAllPostsAsync().GetAwaiter().GetResult();
            foreach (var post in currentPosts)
            {
                if (post.UserID == User.UserID)
                {
                    Posts.Add(post);
                }
            }
        }

        public RootObject GetCurrentWeather()
        {
            return HomeZipRootObject;
        }

        public void SetWeatherIcon()
        {
            WeatherIcon = "http://openweathermap.org/img/w/" + HomeZipRootObject.weather[0].icon + ".png";
        }



        public void GetPostsWithWeather()
        {
            PostsWithWeather = new List<PostWithWeather>();
            foreach (var post in Posts)
            {
                var p = new PostWithWeather();
                p.Post = post;
                p.Weather = JsonConvert.DeserializeObject<RootObject>(post.WeatherJson);
                p.WeatherIconImage = "http://openweathermap.org/img/w/" + p.Weather.weather[0].icon + ".png";
                PostsWithWeather.Add(p);

            }
        }
    }
}
