using System;
using System.ComponentModel.DataAnnotations;

namespace FoodRanker.Library
{
    public class Food
    {
        [Key]
        public int FoodID { get; set;}
        public string Name { get; set; }

        public int AverageRank { get; set; }

        public virtual FoodType FoodType { get; set; }


    }
}
