using System;
using System.Collections.Generic;

namespace reactmvcsample.Models
{
    public partial class SalesTable
    {
        public int Id { get; set; }
        public int? CustomerId { get; set; }
        public int? ProductId { get; set; }
        public int? StoreId { get; set; }
        public DateTime? DateSold { get; set; }

        public virtual CustomerTable? Customer { get; set; }
        public virtual ProductTable? Product { get; set; }
        public virtual StoreTable? Store { get; set; }
    }
}
