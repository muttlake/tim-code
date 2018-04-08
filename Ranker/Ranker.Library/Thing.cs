using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Ranker.Library
{
    public class Thing
    {
        [Key]
        public int ThingID {get; set; }

	public string ThingName { get; set; }

	public DateTime ModifiedDate { get; set; }

    public Thing()
    {
        ThingName = "";
        ModifiedDate = System.DateTime.Now;
    }

    public Thing(string tn)
    {
        ThingName = tn;
        ModifiedDate = System.DateTime.Now;
    }

        //Related to many RankedItems
    public int TypeID { get; set; }
	public Type Type { get; set; }

	public virtual ICollection<Ranking> Rankings {get; set;}

    }
}
