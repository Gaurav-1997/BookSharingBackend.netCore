using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace BookSharing.Models
{
    public partial class CartItem
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public int CartId { get; set; }
        public int? Quantity { get; set; }
        public int? TotalPrice { get; set; }

        public virtual Book Book { get; set; }
        public virtual Cart Cart { get; set; }
    }
}
