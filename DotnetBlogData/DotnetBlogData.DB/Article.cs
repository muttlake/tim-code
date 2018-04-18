using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DotnetBlogData.DB
{
    public class Article
    {
        [Key]
        public int ArticleID { get; set; }

        public string Author { get; set; }

        public string Text { get; set; }

        public DateTime PublishDate { get; set; }

        public string Title { get; set; }
    }
}
