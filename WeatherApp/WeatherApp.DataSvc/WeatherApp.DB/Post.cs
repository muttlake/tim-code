using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WeatherApp.DataSvc.WeatherApp.DB
{
    public class Post
    {
        [Key]
        public int PostID {get; set; }

    	public string BlogPost { get; set; }
    	public string ImageFile { get; set; }

	public string WeatherType { get; set; }
	public int ZipCode { get; set; }
	public int TempFahr { get; set; }
	public string WeatherJson { get; set; }
	public DateTime PublishDateTime { get; set; }

        public Post()
        {
            BlogPost = "";
            ImageFile = "";
        }

        public Post(int uid, string blog, string image)
        {
            UserID = uid;
            BlogPost = blog;
            ImageFile = image;
        }


        //Foreign Key for User
        public int UserID { get; set; }
	public User User { get; set; }

    }
}
