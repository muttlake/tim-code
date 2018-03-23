namespace AdventureWorks.Library.Models
{
    public class Person
    {
        public Name Name { get; set; }

        public Person(string first, string last)
        {
            Name = new Name(first, last);


        }

        public override string ToString()
        {
            return $"{Name}";
        }
    }
}