
using ContactApp.Library.Enums;

namespace ContactApp.Library.Models
{

    public class Address
    {
        public string Street { get; set; }
        public string City { get; set; }
        public StateEnum State { get; set; }
        public string ZipCode { get; set; }

        public Address()
        {
            Street = "Default Street";
            City = "Defaulty City";
            State = StateEnum.AK;
            ZipCode = "0000000";
        }

        public Address(string street, string city, StateEnum state, string zip)
        {
            Street = street;
            City = city;
            State = state;
            ZipCode = zip;
        }

        public override string ToString()
        {
            return $"{Street} , {City}, {State}, {ZipCode}";
        }
    }
    
}