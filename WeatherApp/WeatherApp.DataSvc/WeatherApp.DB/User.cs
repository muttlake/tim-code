using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WeatherApp.DataSvc.WeatherApp.DB
{
    public class User
    {
        [Key]
        public int UserID {get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

	    public int HomeZipCode { get; set; }

        public User()
        {
            FirstName = "";
            LastName = "";
            Email = "";
            Username = "";
            Password = "";
	        HomeZipCode = 75762;
        }

        public User(string fn, string ln, string em, string un, string pw, int zip)
        {
            FirstName = fn;
            LastName = ln;
            Email = em;
            Username = un;
            Password = pw;
	        HomeZipCode = zip;
        }

        //Navigation property for Posts
        public List<Post> Posts { get; set; }

    }
}
