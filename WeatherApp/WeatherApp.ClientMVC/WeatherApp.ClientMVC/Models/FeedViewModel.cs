using System;
using System.Collections.Generic;
using WeatherApp.ClientLib;
using System.Threading.Tasks;
using System.Linq;
using Newtonsoft.Json;

namespace WeatherApp.ClientMVC.Models
{
    public class PostWithUserWeather
    {
        public PostWithUser Post { get; set; }
        public RootObject Weather { get; set; }

        public string WeatherIconImage { get; set; }

    }

    public class FeedViewModel
    {
        public List<PostWithUser> Posts { get; set; }

        public List<PostWithUserWeather> FeedWithWeather { get; set; }
        public string WeatherTypeFilter { get; set; }
        public string ZipCodeFilter { get; set; }
        public string TempFahrFilter { get; set; }

        
        public List<string> WeatherTypes { get; set; }

        public int ZipCodeInt { get; set; }
        public int TempFahrInt { get; set; }

        public RootObject FeedZipRootObject { get; set; }

      

        public FeedViewModel()
        {
            Posts = PostHandler.GetAllPostsWithUserAsync().GetAwaiter().GetResult();
            GetValidWeatherTypes();
            GetPostsWithWeather();
        }
        

        public FeedViewModel(string temp, string wtype, string zip)
        {
            //Assign filters
            TempFahrFilter = temp;
            WeatherTypeFilter = wtype;
            ZipCodeFilter = zip;

            //Get all posts
            Posts = PostHandler.GetAllPostsWithUserAsync().GetAwaiter().GetResult();

            Console.WriteLine("Numer of Posts initially: {0}", Posts.Count);

            //Apply Filters
            ApplyPostFilters();
            GetValidWeatherTypes();
            GetPostsWithWeather();
        }

        public void GetValidWeatherTypes()
        {
            WeatherTypes = new List<string>();
            foreach(var post in Posts)
            {
                if (!WeatherTypes.Contains(post.WeatherType))
                {
                    WeatherTypes.Add(post.WeatherType);
                }
            }
        }

        public void ApplyPostFilters()
        {
            if (TempFahrFilter != null && SetTemp())
            {
                ApplyTempFilter();
            }
            Console.WriteLine("Numer of Posts after temp filter: {0}", Posts.Count);

            if (WeatherTypeFilter != null && WeatherTypeFilter != "")
            {
                ApplyWeatherTypeFilter();
            }
            Console.WriteLine("Numer of Posts after weather type filter: {0}", Posts.Count);

            if (ZipCodeFilter != null && SetZipCode())
            {
                ApplyZipCodeFilter();
            }
            Console.WriteLine("Numer of Posts after zip code filter: {0}", Posts.Count);


        }

        public bool SetZipCode()
        {
            var valid = Int32.TryParse(ZipCodeFilter, out int zip);
            if (valid)
                ZipCodeInt = zip;
            return valid;
        }

        public bool SetTemp()
        {
            var valid = Int32.TryParse(TempFahrFilter, out int temp);
            if (valid)
                TempFahrInt = temp;
            return valid;
        }


        public void ApplyZipCodeFilter()
        {
            Console.WriteLine("Applying Zip Filer with zipcode: {0}", ZipCodeInt);
            var filteredPosts = new List<PostWithUser>();
            foreach (var post in Posts)
            {
                if (post.ZipCode == ZipCodeInt)
                {
                    filteredPosts.Add(post);
                }
            }
            Posts = filteredPosts;
        }


        public void ApplyWeatherTypeFilter()
        {
            var filteredPosts = new List<PostWithUser>();
            foreach(var post in Posts)
            {
                if(post.WeatherType.Equals(WeatherTypeFilter))
                {
                    filteredPosts.Add(post);
                }
            }
            Posts = filteredPosts;
        }



        public RootObject GetCurrentWeather()
        {
            return FeedZipRootObject;
        }

        


         public void GetPostsWithWeather()
         {
             FeedWithWeather = new List<PostWithUserWeather>();
             foreach(var post in Posts)
             {
                 var p = new PostWithUserWeather();
                 p.Post = post;
                 p.Weather = JsonConvert.DeserializeObject<RootObject>(post.WeatherJson);
                 p.WeatherIconImage =  "http://openweathermap.org/img/w/" + p.Weather.weather[0].icon + ".png";
                 FeedWithWeather.Add(p);

             }
         }


        public void ApplyTempFilter()
        {
            var filteredPosts = new List<PostWithUser>();
            foreach (var post in Posts)
            {
                if (post.TempFahr  >= (TempFahrInt - 2) && post.TempFahr <= (TempFahrInt + 2))
                {
                    filteredPosts.Add(post);
                }
            }
            Posts = filteredPosts;
        }
    }
}
