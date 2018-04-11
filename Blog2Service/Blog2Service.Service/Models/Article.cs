using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog2Service.Service.Models
{
    public class Article
    {
        public string Author { get; set; }

        public DateTime PublishDate { get; set; }

        public string Text { get; set; }

        public string Title { get; set; }

        public Article(string title)
        {
            Title = title;
            PublishDate = DateTime.Now;
            Author = "barbie w";
            Text = "This dog does't bite";
        }
    }
}
