using System;
using System.Collections.Generic;

#nullable disable

namespace ClassLibrary1.Models
{
    public partial class Description
    {
        public string Categoryname { get; set; }
        public string Barcode { get; set; }
        public decimal? Distance { get; set; }
        public decimal Weight { get; set; }
        public int? Capacity { get; set; }
        public decimal Price { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }

        public virtual Category CategorynameNavigation { get; set; }
    }
}
