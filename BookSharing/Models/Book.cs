using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace BookSharing.Models
{
    public partial class Book
    {
        public Book()
        {
            Categories = new HashSet<Category>();
            Sellers = new HashSet<Seller>();
        }

        public int Id { get; set; }
        public string BookTitle { get; set; }
        public string BookDescription { get; set; }
        public int? BookPrice { get; set; }
        public string Author { get; set; }
        public string BookCover { get; set; }
        public int? UserAsSellerId { get; set; }

        public virtual Author AuthorNavigation { get; set; }
        public virtual Seller UserAsSeller { get; set; }
        public virtual ICollection<Category> Categories { get; set; }
        public virtual ICollection<Seller> Sellers { get; set; }
    }
}
