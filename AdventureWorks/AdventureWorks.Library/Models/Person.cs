using System.ComponentModel.DataAnnotations;

namespace AdventureWorks.Library.Models
{
    public class Person
    {
        [Key]
        public int Id { get; set; }
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