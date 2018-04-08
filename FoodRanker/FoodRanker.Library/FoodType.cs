using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace FoodRanker.Library
{
    public class FoodType
    {
        [Key]
        public int FoodTypeID {get; set;}

        public string Name { get; set; }
        
        public virtual ICollection<Food> Foods { get; set; } 


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
