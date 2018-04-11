using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;


namespace Blog2.Library
{
    public class BlogHelper
    {
        public BlogHelper()
        {

        }

        public static List<Article> GetArticles()
        {
            return new List<Article>()
            {
                new Article("One"),
                new Article("Two"),
                new Article("Three")
            };
        }

        public static async Task<List<Article>> GetArticlesAsync()
        {
            var client = new HttpClient();

            var result = await client.GetAsync("http://localhost:53458/api/blog");

            if (result.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<List<Article>>(await result.Content.ReadAsStringAsync());
            }
            else
            {
                return null;
            }
        }
    }
}
