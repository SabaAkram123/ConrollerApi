using System;
using System.Collections.Generic;

namespace reactmvcsample.Models
{
    public partial class StoreTable
    {
        public StoreTable()
        {
            SalesTables = new HashSet<SalesTable>();
        }

        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Address { get; set; }

        public virtual ICollection<SalesTable> SalesTables { get; set; }
    }
}
