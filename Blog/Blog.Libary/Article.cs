using System;
using System.Collections.Generic;
using System.Text;

namespace BlogLibary
{
    class Article
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string Content { get; set; }

        public Article(string title)
        {
            Title = title;
            Author = "Timothy";
            Content = "That is how the cookie crumbles";
        }
    }
}
