
using System.ComponentModel.DataAnnotations;

namespace AdventureWorks.Library.Models
{
    public class Name
    {
        [Key]
        public int Id { get; set; }
        public string First { get; set; }
        public string Last { get; set; }

        public Name(string first, string last)
        {
            First = first;
            Last = last;
        }

        public override string ToString()
        {
            return $"{First} {Last}";
        }
    }
}