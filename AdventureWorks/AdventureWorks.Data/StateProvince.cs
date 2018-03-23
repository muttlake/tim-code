using System;
using System.Collections.Generic;

namespace AdventureWorks.Data
{
    public partial class StateProvince
    {
        public StateProvince()
        {
            Address1 = new HashSet<Address1>();
            SalesTaxRate = new HashSet<SalesTaxRate>();
        }

        public int StateProvinceId { get; set; }
        public string StateProvinceCode { get; set; }
        public string CountryRegionCode { get; set; }
        public bool? IsOnlyStateProvinceFlag { get; set; }
        public string Name { get; set; }
        public int TerritoryId { get; set; }
        public Guid Rowguid { get; set; }
        public DateTime ModifiedDate { get; set; }

        public CountryRegion CountryRegionCodeNavigation { get; set; }
        public SalesTerritory Territory { get; set; }
        public ICollection<Address1> Address1 { get; set; }
        public ICollection<SalesTaxRate> SalesTaxRate { get; set; }
    }
}
