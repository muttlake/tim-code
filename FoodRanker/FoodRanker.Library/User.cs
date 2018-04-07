using System;
using System.ComponentModel.DataAnnotations;

namespace FoodRanker.Library
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

        public User()
        {
            FirstName = "";
            LastName = "";
            Email = "";
            Username = "";
            Password = "";
        }

        public User(string fn, string ln, string em, string un, string pw)
        {
            FirstName = fn;
            LastName = ln;
            Email = em;
            Username = un;
            Password = pw;
        }

    }
}
