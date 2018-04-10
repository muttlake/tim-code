
using System.Collections.Generic;
using System.Net;

namespace RestService.Client.Models
{
    public class ResponseResult
    {

        public object Data { get; set; }

        public string Message { get; set; }

        public HttpStatusCode StatusCode { get; set; }

        public List<string> Links { get; set; }
        
    }
}