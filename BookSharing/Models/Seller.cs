using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace BookSharing.Models
{
    public partial class Seller
    {
        public Seller()
        {
            Books = new HashSet<Book>();
        }

        public int SellerId { get; set; }
        public string UserAsSeller { get; set; }
        public string BookTitle { get; set; }
        public DateTime UploadDate { get; set; }

        public virtual Book BookTitleNavigation { get; set; }
        public virtual User SellerNavigation { get; set; }
        public virtual User UserAsSellerNavigation { get; set; }
        public virtual ICollection<Book> Books { get; set; }
    }
}
