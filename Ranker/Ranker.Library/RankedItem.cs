using System;
using System.ComponentModel.DataAnnotations;

namespace Ranker.Library
{
    public class RankedItem
    {
        [Key]
        public int RankedItemID {get; set; }

		public string TypeName { get; set; }

        public RankedItem()
        {
        }

        //Related to a User
	    public int UserID { get; set; }
        public virtual User User { get; set; }

        //Related to a Type
	    public int TyperID { get; set; }
        public virtual Typer Typer { get; set; }

	//Related to Ranking
	public int RankingID {get; set;}
	public virtual Ranking Ranking {get; set;}
    }
}
