

namespace ContactApp.Library.Models
{
    public class Phone
    {
        public string Area { get; set; }
        public string Number { get; set; }

        public Phone()
        {

        }
        public Phone(string area, string number)
        {
            Area = area;
            Number = number;
        }

        public override string ToString()
        {
            return $"{Area} {Number}";
        }
    }
}