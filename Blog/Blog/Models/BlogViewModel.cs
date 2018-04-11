using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.Library;

namespace Blog.Models
{
    public class BlogViewModel
    {
        public List<Article> Articles { get; set; }

        public BlogViewModel()
        {
            Articles = BlogHelper.GetArticles();
        }
    }
}
