using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using WeatherApp.ClientLib;

namespace WeatherApp.ClientMVC.Models
{
     
    public class MakeAPostViewModel
    {
        public User User { get; set; }
        public Post NewPost { get; set; }
        public RootObject ZipRootObject { get; set; }

        public string WeatherIcon { get; set; }

        public MakeAPostViewModel()
        {
            NewPost = new Post();
        }

        public MakeAPostViewModel(User user)
        {
            NewPost = new Post();
            User = user;
            ZipRootObject = JsonHandler.GetRootObjectFromLibSvcAsync(user.HomeZipCode).GetAwaiter().GetResult();
            SetWeatherIcon(); 

        }

        public RootObject GetCurrentWeather()
        {
            return ZipRootObject;
        }

         public void SetWeatherIcon()
        {
            WeatherIcon = "http://openweathermap.org/img/w/" + ZipRootObject.weather[0].icon + ".png";
        }


    }
}
