using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace Data.Models
{
    public partial class Description
    {
        public string Barcode { get; set; }
        public decimal? Distance { get; set; }
        public decimal Weight { get; set; }
        public int? Capacity { get; set; }
        public decimal Price { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public string Categoryname { get; set; }
       
        public virtual Category CategorynameNavigation { get; set; }
    }
}
