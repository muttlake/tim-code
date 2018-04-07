using System;
using System.ComponentModel.DataAnnotations;


namespace FoodRanker.Library
{
    public class FoodType
    {
        [Key]
        public int FoodTypeID {get; set;}

        public string Name { get; set; }

        public FoodType()
        {
            Name = "";
        }

        public FoodType(string name)
        {
            Name = name;
        }

    }
}
