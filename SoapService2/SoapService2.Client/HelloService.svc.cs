using SoapService2.Client.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SoapService2.Client
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "HelloService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select HelloService.svc or HelloService.svc.cs at the Solution Explorer and start debugging.
    public class HelloService : IHelloService
    {
        public ResponsModel Greeting(Person p)
        {

            var res = new ResponsModel();

            if (DateTime.Now.Hour < 12)
            {
                res.Data = $"Good Morning {p.FirstName} {p.LastName}";
                res.Message = "All Good";
            }

            res.Data =  $"Good Day {p.FirstName} {p.LastName}";
            res.Message = "Not So God Good";

            return res;


        }

    }
}
