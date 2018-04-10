using System;
using System.Net.Http;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using RestService.Client.Models;

namespace RestService.Client.Controllers
{
    [EnableCors("allowAll")] //Enable Cross Origin Resource Sharing
    [Produces("application/json")] // Means every action result will always be a json type result
    [Route("pizza/[action]")]
    public class PizzaController : Controller
    {

        // [Route("/read/[msg]")] // You have to give msg for it to get to this route, this means it must exist
        // [HttpGet("{msg}")] //msg is mandatory
        // [HttpGet()]
        [HttpGet("{msg}")]
        public IActionResult Read(string msg, string extra)
        {
            return Ok(new PizzaResult(msg));
            //return new JsonResult(new PizzaResult(msg + extra));  //You can return a Json or message directly
            //return RedirectPermanent(new PizzaResult(msg)); //tells DNS to permanently redirect
        }

        [HttpPost]
        public void Create()
        {

        }

        [HttpPut]
        public void Update()
        {

        }

        [HttpDelete]
        public void Delete()
        {

        }



    }
}