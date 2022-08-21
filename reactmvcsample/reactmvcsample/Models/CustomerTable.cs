using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace reactmvcsample.Models
{
    public partial class CustomerTable
    {
        public CustomerTable()
        {
            SalesTables = new HashSet<SalesTable>();
        }

        public int Id { get; set; }


        [DisplayName("Name")]
        [Required(ErrorMessage = "Customer Name is required")]
        [StringLength(100, MinimumLength = 3)]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Customer Address is required")]
        [StringLength(300)]
        public string? Address { get; set; }

        public virtual ICollection<SalesTable> SalesTables { get; set; }
    }
}
