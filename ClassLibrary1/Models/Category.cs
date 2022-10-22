using System;
using System.Collections.Generic;

#nullable disable

namespace ClassLibrary1.Models
{
    public partial class Category
    {
        public string Categoryname { get; set; }
        public int Id { get; set; }

        public virtual Description Description { get; set; }
    }
}
