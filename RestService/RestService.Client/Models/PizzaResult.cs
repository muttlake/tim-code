
using System.Collections.Generic;
using System.Net;

namespace RestService.Client.Models
{
    public class PizzaResult : ResponseResult
    {

        public PizzaResult(object data)
        {
            Data = data;
            Message = "All good";
            StatusCode = HttpStatusCode.OK;

            Links = new List<string>();
            Links.Add("http://google.com");
            Links.Add("http://docs.microsoft.com");
        }
        


    }
}