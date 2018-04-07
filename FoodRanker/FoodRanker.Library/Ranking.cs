using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FoodRanker.Library
{
    public class Ranking
    {
        [Key]
        public int RankingID {get; set;}

        public virtual User User {get; set;}

        public virtual List<Food> Foods { get; set; }


    }
}
