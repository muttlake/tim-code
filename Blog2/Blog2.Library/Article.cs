using System;
using System.Collections.Generic;
using System.Text;

namespace Blog2.Library
{
    public class Article
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string Content { get; set; }

        public Article(string title)
        {
            Title = title;
            Author = "Tim";
            Content = "cookie crumble";
        }
    }
}
