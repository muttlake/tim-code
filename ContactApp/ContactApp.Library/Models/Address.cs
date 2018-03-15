
using ContactApp.Library.Enums;

namespace ContactApp.Library.Models
{

    public class Address
    {
        public string Street { get; set; }
        public string City { get; set; }
        public StateEnum State { get; set; }
        public string ZipCode { get; set; }
    }
    
}