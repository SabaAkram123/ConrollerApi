using System;
using System.Collections.Generic;

namespace reactmvcsample.Models
{
    public partial class ProductTable
    {
        public ProductTable()
        {
            SalesTables = new HashSet<SalesTable>();
        }

        public int Id { get; set; }
        public string? Name { get; set; }
        public int? Price { get; set; }

        public virtual ICollection<SalesTable> SalesTables { get; set; }
    }
}
