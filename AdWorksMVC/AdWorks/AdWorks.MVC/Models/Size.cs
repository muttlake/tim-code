using System.Collections.Generic;

namespace AdWorks.MVC.Models
{
    public class Size
    {
        public string Small { get; set; }
        public string Medium { get; set; }
        public string Large { get; set; }

        public Size()
        {
            Small = "Small";
            Medium = "Medium";
            Large = "Large";
        }
    }
}