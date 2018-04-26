using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherApp.DataSvc.Models
{
    public class PostWithUser
    {
        public int PostID { get; set; }

        public string BlogPost { get; set; }
        public string ImageFile { get; set; }

        public int TempFahr { get; set; }
        public string WeatherJson { get; set; }
        public string WeatherType { get; set; }
        public int ZipCode { get; set; }
        public DateTime PublishDateTime { get; set; }

        public int UserID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }

        public PostWithUser()
        {
        }

        public PostWithUser(int pid, string blogPost, string imageFile, string weatherType, int zip, int tempFahr, string weatherJson, DateTime publishDate, int uid, string firstName, string lastName, string userName)
        {
            PostID = pid;

            BlogPost = blogPost;
            ImageFile = imageFile;

            WeatherType = weatherType;
            ZipCode = zip;
            TempFahr = tempFahr;
            WeatherJson = weatherJson;
            PublishDateTime = publishDate;

            UserID = uid;
            FirstName = firstName;
            LastName = lastName;
            Username = userName;
        }



    }
}
