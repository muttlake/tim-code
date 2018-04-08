using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Ranker.Library
{
    public class Typer
    {
        [Key]
        public int TyperID {get; set; }

		public string TyperName { get; set; }

        public Typer()
        {
            TyperName = "";
        }

        public Typer(string tn)
        {
            TyperName = tn;
        }

        //Related to many RankedItems
        public virtual ICollection<RankedItem> RankedItems {get; set;}

        //Related to many Things
        public virtual ICollection<Thing> Thing {get; set;}

    }
}
