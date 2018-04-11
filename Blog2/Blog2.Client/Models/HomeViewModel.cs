using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Blog2.Library;
using Newtonsoft.Json;

namespace Blog2.Client.Models
{
    public class HomeViewModel
    {
        public List<Article> Articles { get; set; }

        public HomeViewModel()
        {

            Articles = BlogHelper.GetArticlesAsync().Result;
        }


    }
}
