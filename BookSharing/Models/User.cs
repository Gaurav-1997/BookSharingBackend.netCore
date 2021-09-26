using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace BookSharing.Models
{
    public partial class User
    {
        public User()
        {
            SellerUserAsSellerNavigations = new HashSet<Seller>();
        }

        public int UserId { get; set; }
        public string UserEmail { get; set; }
        public string UserPassword { get; set; }
        public string UserName { get; set; }
        public string Token { get; set; }

        public virtual Seller SellerSellerNavigation { get; set; }
        public virtual ICollection<Seller> SellerUserAsSellerNavigations { get; set; }
    }
}
