using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WeatherApp.Library
{
    public class EfData
    {
        private readonly WeatherAppContext dbContext = new WeatherAppContext();

        public List<User> ReadUsers()
        {
            return dbContext.Users.ToList();
        }

        public bool ValidateUser(string email, string password)
        {

            if(dbContext.Users.Where(p => p.Email == email).Count() == 1)
            {
                var user = dbContext.Users.Where(p => p.Email == email).FirstOrDefault();

                return user.Password == password;
            }

            return false;
        }
    }
}
