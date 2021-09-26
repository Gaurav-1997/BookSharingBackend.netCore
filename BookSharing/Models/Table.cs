using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace BookSharing.Models
{
    public partial class Table
    {
        public int SellerId { get; set; }
        public string SellerName { get; set; }
        public string SellerMail { get; set; }
        public string UserAsSeller { get; set; }
    }
}
