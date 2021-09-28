﻿using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace BookSharing.Models
{
    public partial class Category
    {
        public Category()
        {
            BookCategories = new HashSet<BookCategory>();
        }

        public int Id { get; set; }
        public string CategoryName { get; set; }

        public virtual ICollection<BookCategory> BookCategories { get; set; }
    }
}
