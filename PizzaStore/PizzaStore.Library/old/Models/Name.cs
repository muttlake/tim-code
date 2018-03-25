

namespace PizzaStore.Library.Models
{ 
    public class Name 
    {
        public string First { get; set; }
        public string Last { get; set; }

        public Name()
        {
            First = "fred";
            Last = "belotte";
        }

        public Name(string name)
        {
            First = name;
        }

        public Name(string fName, string lName)
        {
            First = fName;
            Last = lName;
        }

        public override string ToString()
        {
            return $"{First} {Last}";
        }
    }
}