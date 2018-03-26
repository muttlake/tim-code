﻿using System;
using System.Collections.Generic;

namespace AdventureWorks.Data
{
    public partial class Location1
    {
        public Location1()
        {
            ProductInventory = new HashSet<ProductInventory>();
            WorkOrderRouting = new HashSet<WorkOrderRouting>();
        }

        public short LocationId { get; set; }
        public string Name { get; set; }
        public decimal CostRate { get; set; }
        public decimal Availability { get; set; }
        public DateTime ModifiedDate { get; set; }

        public ICollection<ProductInventory> ProductInventory { get; set; }
        public ICollection<WorkOrderRouting> WorkOrderRouting { get; set; }
    }
}