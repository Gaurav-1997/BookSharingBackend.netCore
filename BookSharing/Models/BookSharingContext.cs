using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace BookSharing.Models
{
    public partial class BookSharingContext : DbContext
    {
        public BookSharingContext()
        {
        }

        public BookSharingContext(DbContextOptions<BookSharingContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Author> Authors { get; set; }
        public virtual DbSet<Book> Books { get; set; }
        public virtual DbSet<BookAuthor> BookAuthors { get; set; }
        public virtual DbSet<BookCategory> BookCategories { get; set; }
        public virtual DbSet<Cart> Carts { get; set; }
        public virtual DbSet<CartItem> CartItems { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<RefreshToken> RefreshTokens { get; set; }
        public virtual DbSet<Seller> Sellers { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Name=BookSharingDB");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>(entity =>
            {
                entity.ToTable("Author");

                entity.HasIndex(e => e.AuthorName)
                    .HasName("UQ__Author__9B43168759487402")
                    .IsUnique();

                entity.Property(e => e.AuthorEmail)
                    .HasColumnName("Author_Email")
                    .HasMaxLength(50);

                entity.Property(e => e.AuthorName)
                    .IsRequired()
                    .HasColumnName("Author_Name")
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Book>(entity =>
            {
                entity.ToTable("Book");

                entity.HasIndex(e => e.BookTitle)
                    .HasName("UQ__Book__F550A4CA7B99B9E4")
                    .IsUnique();

                entity.Property(e => e.Author)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.BookCover).HasColumnName("Book_Cover");

                entity.Property(e => e.BookDescription).HasColumnName("Book_Description");

                entity.Property(e => e.BookPrice).HasColumnName("Book_Price");

                entity.Property(e => e.BookTitle)
                    .IsRequired()
                    .HasColumnName("Book_Title")
                    .HasMaxLength(100);

                entity.Property(e => e.Category).HasMaxLength(50);

                entity.Property(e => e.UserAsSellerId).HasColumnName("UserAsSeller_Id");

                entity.HasOne(d => d.UserAsSeller)
                    .WithMany(p => p.Books)
                    .HasForeignKey(d => d.UserAsSellerId)
                    .HasConstraintName("FK__Book__UserAsSell__778AC167");
            });

            modelBuilder.Entity<BookAuthor>(entity =>
            {
                entity.HasKey(e => new { e.BookId, e.AuthorId })
                    .HasName("PK__BookAuth__6AED6DC4A6E88A91");

                entity.HasOne(d => d.Author)
                    .WithMany(p => p.BookAuthors)
                    .HasForeignKey(d => d.AuthorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__BookAutho__Autho__5812160E");

                entity.HasOne(d => d.Book)
                    .WithMany(p => p.BookAuthors)
                    .HasForeignKey(d => d.BookId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__BookAutho__BookI__571DF1D5");
            });

            modelBuilder.Entity<BookCategory>(entity =>
            {
                entity.HasKey(e => new { e.CategoryId, e.BookId })
                    .HasName("PK__BookCate__7AD7362B7EA96456");

                entity.ToTable("BookCategory");

                entity.Property(e => e.CategoryId).HasMaxLength(50);

                entity.HasOne(d => d.Book)
                    .WithMany(p => p.BookCategories)
                    .HasForeignKey(d => d.BookId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__BookCateg__BookI__5AEE82B9");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.BookCategories)
                    .HasPrincipalKey(p => p.CategoryName)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__BookCateg__Categ__5BE2A6F2");
            });

            modelBuilder.Entity<Cart>(entity =>
            {
                entity.ToTable("Cart");

                entity.Property(e => e.CartId).HasColumnName("Cart_Id");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Carts)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Cart__UserId__6EF57B66");
            });

            modelBuilder.Entity<CartItem>(entity =>
            {
                entity.ToTable("CartItem");

                entity.Property(e => e.Quantity).HasDefaultValueSql("((0))");

                entity.Property(e => e.TotalPrice)
                    .HasColumnName("Total_Price")
                    .HasDefaultValueSql("((0))");

                entity.HasOne(d => d.Book)
                    .WithMany(p => p.CartItems)
                    .HasForeignKey(d => d.BookId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__CartItem__BookId__7C4F7684");

                entity.HasOne(d => d.Cart)
                    .WithMany(p => p.CartItems)
                    .HasForeignKey(d => d.CartId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__CartItem__CartId__7D439ABD");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("Category");

                entity.HasIndex(e => e.CategoryName)
                    .HasName("UQ__Category__B35EB41914BCEA8E")
                    .IsUnique();

                entity.Property(e => e.CategoryName)
                    .IsRequired()
                    .HasColumnName("Category_Name")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<RefreshToken>(entity =>
            {
                entity.HasKey(e => e.TokenId);

                entity.ToTable("RefreshToken");

                entity.Property(e => e.TokenId).HasColumnName("token_id");

                entity.Property(e => e.ExpiryDate)
                    .HasColumnName("expiry_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.Token)
                    .IsRequired()
                    .HasColumnName("token")
                    .HasMaxLength(200);

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.RefreshTokens)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__RefreshTo__user___534D60F1");
            });

            modelBuilder.Entity<Seller>(entity =>
            {
                entity.ToTable("Seller");

                entity.Property(e => e.SellerId)
                    .HasColumnName("Seller_Id")
                    .ValueGeneratedNever();

                entity.Property(e => e.BookTitle)
                    .HasColumnName("Book_Title")
                    .HasMaxLength(100);

                entity.Property(e => e.UploadDate)
                    .HasColumnName("Upload_Date")
                    .HasColumnType("datetime");

                entity.Property(e => e.UserAsSeller).HasMaxLength(100);

                entity.HasOne(d => d.BookTitleNavigation)
                    .WithMany(p => p.Sellers)
                    .HasPrincipalKey(p => p.BookTitle)
                    .HasForeignKey(d => d.BookTitle)
                    .HasConstraintName("FK__Seller__Book_Tit__4BAC3F29");

                entity.HasOne(d => d.SellerNavigation)
                    .WithOne(p => p.SellerSellerNavigation)
                    .HasForeignKey<Seller>(d => d.SellerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Seller__Seller_I__4AB81AF0");

                entity.HasOne(d => d.UserAsSellerNavigation)
                    .WithMany(p => p.SellerUserAsSellerNavigations)
                    .HasPrincipalKey(p => p.UserName)
                    .HasForeignKey(d => d.UserAsSeller)
                    .HasConstraintName("FK__Seller__UserAsSe__49C3F6B7");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");

                entity.HasIndex(e => e.UserEmail)
                    .HasName("UQ__User__4C70A05C654CA14D")
                    .IsUnique();

                entity.HasIndex(e => e.UserName)
                    .HasName("UQ__User__681E8A605EEC8EC8")
                    .IsUnique();

                entity.Property(e => e.UserId).HasColumnName("User_Id");

                entity.Property(e => e.UserEmail)
                    .IsRequired()
                    .HasColumnName("User_Email")
                    .HasMaxLength(100);

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasColumnName("User_Name")
                    .HasMaxLength(100);

                entity.Property(e => e.UserPassword)
                    .IsRequired()
                    .HasColumnName("User_Password")
                    .HasMaxLength(100);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
