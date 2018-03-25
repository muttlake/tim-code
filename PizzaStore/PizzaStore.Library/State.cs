using System;
using System.Collections.Generic;

namespace PizzaStore.Library
{
    public partial class State
    {
        public State()
        {
            Address = new HashSet<Address>();
        }

        public int StateId { get; set; }
        public string StateAbb { get; set; }

        public ICollection<Address> Address { get; set; }
    }
}
