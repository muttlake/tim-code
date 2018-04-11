using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog2Service.Service.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Blog2Service.Service.Controllers
{

    [EnableCors("allowAll")]
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class BlogController : Controller
    {
        // GET: api/Blog
        [HttpGet]
        public async Task<IEnumerable<Article>> GetAsync()
        {
            // public Delegate IEnumerable<Article> Result();
            // Func<IEnumerable<Article>> fa = () => ( return new List<Article>(););
            // task = new Task(() => {});
            // return await Task.Run
            return await Task.Run(() => new List<Article>()
            {
                new Article("From Service 1"),
                new Article("From Service 2"),
                new Article("From Service 3")
            });
        }

        // GET: api/Blog/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }
        
        // POST: api/Blog
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }
        
        // PUT: api/Blog/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
