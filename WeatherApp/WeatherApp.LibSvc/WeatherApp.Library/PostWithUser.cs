using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherApp.Library
{
    public class PostWithUser
    {

        [JsonProperty("postID")]
        public int PostID { get; set; }

        [JsonProperty("blogPost")]
        public string BlogPost { get; set; }

        [JsonProperty("imageFile")]
        public string ImageFile { get; set; }

        [JsonProperty("tempFahr")]
        public int TempFahr { get; set; }

        [JsonProperty("weatherJson")]
        public string WeatherJson { get; set; }

        [JsonProperty("weatherType")]
        public string WeatherType { get; set; }

        [JsonProperty("zipCode")]
        public int ZipCode { get; set; }

        [JsonProperty("publishDateTime")]
        public DateTime PublishDateTime { get; set; }

        [JsonProperty("userID")]
        public int UserID { get; set; }

        [JsonProperty("firstName")]
	    public string FirstName { get; set; }

        [JsonProperty("lastName")]
        public string LastName { get; set; }

        [JsonProperty("userName")]
        public string Username { get; set; }

        public PostWithUser()
        {
        }
    }
}
