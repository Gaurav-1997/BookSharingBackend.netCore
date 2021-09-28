using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace BookSharing.Models
{
    public partial class Book
    {
        public Book()
        {
            BookAuthors = new HashSet<BookAuthor>();
            BookCategories = new HashSet<BookCategory>();
            CartItems = new HashSet<CartItem>();
            Sellers = new HashSet<Seller>();
        }

        public int Id { get; set; }
        [Required]
        public string BookTitle { get; set; }
        public string BookDescription { get; set; }
        [Required]
        public int? BookPrice { get; set; }
        [Required]
        public string Author { get; set; }
        public string BookCover { get; set; }
        public int? UserAsSellerId { get; set; }
        [Required]
        public string Category { get; set; }

        public virtual User UserAsSeller { get; set; }
        public virtual ICollection<BookAuthor> BookAuthors { get; set; }
        public virtual ICollection<BookCategory> BookCategories { get; set; }
        public virtual ICollection<CartItem> CartItems { get; set; }
        public virtual ICollection<Seller> Sellers { get; set; }
    }
}
