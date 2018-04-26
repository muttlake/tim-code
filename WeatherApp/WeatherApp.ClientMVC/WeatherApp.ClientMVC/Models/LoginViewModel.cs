using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeatherApp.ClientLib;

namespace WeatherApp.ClientMVC.Models
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

        public User GetUser()
        {
            var uh = new UserHandler();
            return uh.GetCurrentUser(Email);
        }
    }
}
