using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace BookSharing.Models
{
    public partial class User
    {
        public User()
        {
            Books = new HashSet<Book>();
            Carts = new HashSet<Cart>();
            RefreshTokens = new HashSet<RefreshToken>();
            SellerUserAsSellerNavigations = new HashSet<Seller>();
        }

        public int UserId { get; set; }
        //[Required(ErrorMessage = "Email is madatory")]
        //[RegularExpression("{^_`{|} ~-]+@[a-zA-Z0-9-]+(?:.'\'[a-zA-Z0-9-]+)*$/.}", ErrorMessage ="Email should be of type abc@xyz.com")]
        
        public string UserEmail { get; set; }
        //[Required(ErrorMessage = "Password is madatory")]
        //[StringLength(20,MinimumLength = 6)]
        //[RegularExpression("^(?=.*[A-Za-z])(?=.*'\'d)(?=.*[@$!%*#?&])[A-Za-z'\'d@$!%*#?&]{6,}$",
        //    ErrorMessage = "Minimum six characters, at least one letter, one number and one special character:")]
        public string UserPassword { get; set; }

        //[Required(ErrorMessage = "UserName is madatory")]
        //[RegularExpression(".*[a-zA-z]+.*",ErrorMessage ="Only Numerics are not allowed")]
        public string UserName { get; set; }
        public string Token { get; set; }

        public virtual Seller SellerSellerNavigation { get; set; }
        public virtual ICollection<Book> Books { get; set; }
        
        public virtual ICollection<Cart> Carts { get; set; }
        public virtual ICollection<RefreshToken> RefreshTokens { get; set; }
        public virtual ICollection<Seller> SellerUserAsSellerNavigations { get; set; }
    }
}
