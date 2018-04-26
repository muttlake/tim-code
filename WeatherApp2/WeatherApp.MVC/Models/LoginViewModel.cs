using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeatherApp.Library;

namespace WeatherApp.MVC.Models
{
    public class LoginViewModel
    {
        public string Email { get; set; }
        public string Password { get; set; }

        public LoginViewModel()
        {
            Email = "";
            Password = "";
        }

        public bool IsUserValid()
        {
            var ef = new EfData();
            return ef.ValidateUser(Email, Password);
        }

        public User GetUser()
        {
            var ef = new EfData();
            return ef.ReadUsers().Where(p => p.Email == Email).FirstOrDefault();
        }
    }
}
