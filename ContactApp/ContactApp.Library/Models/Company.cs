

namespace ContactApp.Library.Models
{
    public class Company: Person
    {
        public Company()
        {
            Name = new Name("Default Company");
        }

        public Company(string name)
        {
            Name = new Name(name);
        }

        public override string ToString()
        {
            return string.Format("Company:  {0}", Name);
        }
    }
}