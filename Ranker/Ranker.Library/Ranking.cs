using System;
using System.ComponentModel.DataAnnotations;

namespace Ranker.Library
{
    public class Ranking
    {
        [Key]
        public int RankingID {get; set; }

        //Related to a Thing
        public int ThingID { get; set; }
	public Thing Thing { get; set; }

    }
}
