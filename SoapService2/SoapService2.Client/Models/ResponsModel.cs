using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace SoapService2.Client.Models
{
    [DataContract]
    public class ResponsModel
    {
        [DataMember]
        public string Data { get; set; }

        [DataMember]
        public string Message { get; set; }
    }
}