using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace BookSharing.Models
{
    public partial class Cart
    {
        public int CartId { get; set; }
        public string BookTitle { get; set; }
        public int Quantity { get; set; }
        public int TotalPrice { get; set; }
    }
}
