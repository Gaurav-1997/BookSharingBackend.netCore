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
        public virtual DbSet<Cart> Carts { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Seller> Sellers { get; set; }
        public virtual DbSet<Table> Tables { get; set; }
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

                entity.Property(e => e.UserAsSellerId).HasColumnName("UserAsSeller_Id");

                entity.HasOne(d => d.AuthorNavigation)
                    .WithMany(p => p.Books)
                    .HasPrincipalKey(p => p.AuthorName)
                    .HasForeignKey(d => d.Author)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Book__Author__412EB0B6");

                entity.HasOne(d => d.UserAsSeller)
                    .WithMany(p => p.Books)
                    .HasForeignKey(d => d.UserAsSellerId)
                    .HasConstraintName("FK__Book__UserAsSell__4CA06362");
            });

            modelBuilder.Entity<Cart>(entity =>
            {
                entity.ToTable("Cart");

                entity.Property(e => e.CartId).HasColumnName("Cart_Id");

                entity.Property(e => e.BookTitle)
                    .IsRequired()
                    .HasColumnName("Book_Title")
                    .HasMaxLength(200);

                entity.Property(e => e.TotalPrice).HasColumnName("Total_Price");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("Category");

                entity.HasIndex(e => e.CategoryName)
                    .HasName("UQ__Category__B35EB41914BCEA8E")
                    .IsUnique();

                entity.Property(e => e.BookId).HasColumnName("Book_Id");

                entity.Property(e => e.CategoryName)
                    .IsRequired()
                    .HasColumnName("Category_Name")
                    .HasMaxLength(50);

                entity.HasOne(d => d.Book)
                    .WithMany(p => p.Categories)
                    .HasForeignKey(d => d.BookId)
                    .HasConstraintName("FK__Category__Book_I__5070F446");
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

            modelBuilder.Entity<Table>(entity =>
            {
                entity.HasKey(e => e.SellerId)
                    .HasName("PK__Table__009FC2A94C4C0CBE");

                entity.ToTable("Table");

                entity.Property(e => e.SellerId)
                    .HasColumnName("Seller_Id")
                    .ValueGeneratedNever();

                entity.Property(e => e.SellerMail)
                    .HasColumnName("Seller_Mail")
                    .HasMaxLength(100);

                entity.Property(e => e.SellerName).HasMaxLength(100);

                entity.Property(e => e.UserAsSeller).HasMaxLength(100);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");

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
