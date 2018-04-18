using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DotnetBlogData.DB;

namespace DotnetBlogData.Svc.Controllers
{
    [Route("api/[controller]")]
    public class ArticleController : Controller
    {

        private BlogDBContext db = new BlogDBContext();

        [HttpGet]  
        public async Task<IEnumerable<Article>> Index()
        {
            return await Task.Run(() => { return db.Articles.ToList(); });
            //return View();
        }
    }
}