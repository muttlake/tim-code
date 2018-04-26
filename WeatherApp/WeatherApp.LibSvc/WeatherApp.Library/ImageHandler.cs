// using file for adding images to imgur using RestSharp
using RestSharp;
//other using files

namespace WeatherApp.Library
{
    public class ImageHandler
    {
        // code for adding images to S3


        // code for adding images to imgur

        readonly string token = "f00e8ac6-10fa-4529-9105-bcac32c2cb17";
        readonly string auth = "Bearer 5f59e946914c966d89ecb5a2f64f6717fa96f682";

        // session variables
        readonly string imgUrl;
        // name of the file shown in imgur
        readonly string imgTitle;
        // description of file in imgur
        readonly string imgDescription;
        // file name
        readonly string imgName;
        readonly string imgType;

        public ImageHandler()
        {
            imgUrl = @"R0lGODlhAQABAIAAAAAAAP///yH5BAEAAAAALAAAAAABAAEAAAIBRAA7";
            
            var imgName = "img.jpg";
            var imgType = "jpg";
            
            
            PostImage();
        }

        public ImageHandler(string url, string name, string type)
        {
            imgUrl = url;
            imgName = name;
            imgType = type;

            PostImage();
        }

        public void PostImage()
        {
            var client = new RestClient("https://api.imgur.com/3/image");
            var request = new RestRequest(Method.POST);

            request.AddHeader("Postman-Token", token);
            request.AddHeader("Cache-Control", "no-cache");
            request.AddHeader("Authorization", auth);
            request.AddHeader("content-type", "multipart/form-data; boundary=----WebKitFormBoundary7MA4YWxkTrZu0gW");
            request.AddParameter("multipart/form-data; boundary=----WebKitFormBoundary7MA4YWxkTrZu0gW",
                "------WebKitFormBoundary7MA4YWxkTrZu0gW\r\n" +
                "Content-Disposition: form-data; name=\"image\"\r\n\r\n" +

                imgUrl + "\r\n" +
                "------WebKitFormBoundary7MA4YWxkTrZu0gW\r\n" +
                "Content-Disposition: form-data; name=\"title\"\r\n\r\n" +

                imgName + "\r\n" +
                "------WebKitFormBoundary7MA4YWxkTrZu0gW--", ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
        }
    }
}
