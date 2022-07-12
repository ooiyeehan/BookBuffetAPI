using Microsoft.EntityFrameworkCore;
using BookBuffetWeb2.DomainClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookBuffetWeb2.Data
{
    public partial class BackendDBContext : DbContext
    {
        // Dependency Injection
        public BackendDBContext(DbContextOptions<BackendDBContext> options) : base(options)
        {

        }

        //Authors collection will allow us to manage CRUD data operations in Author table
        public DbSet<User> Users { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<BookCategory> BookCategories { get; set; }
        public DbSet<RentRequest> RentRequests { get; set; }




        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Author>().HasData(
            //    new Author { AuthorId = 1, Name = "John Davis" },
            //    new Author { AuthorId = 2, Name = "Arlan Hamilton" },
            //    new Author { AuthorId = 3, Name = "Minda Harts" },
            //    new Author { AuthorId = 4, Name = "Susanne Tedrick" },
            //    new Author { AuthorId = 5, Name = "Steve Proctor" },
            //    new Author { AuthorId = 6, Name = "Michael Chen" }
            //    );

            //modelBuilder.Entity<Book>().HasData(
            //    new Book { BookId = 1, AuthorId = 1, Title = "Data Visualizations" },
            //    new Book { BookId = 2, AuthorId = 2, Title = "The Memo" }

            //);

            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("users");

                entity.Property(e => e.UserId)
                    .HasColumnName("userid");

                entity.Property(e => e.Username)
                    .HasMaxLength(200)
                    .HasColumnName("username");

                entity.Property(e => e.Email)
                    .HasMaxLength(200)
                    .HasColumnName("email");

                entity.Property(e => e.Password)
                    .HasMaxLength(200)
                    .HasColumnName("password");

                entity.Property(e => e.ProfileImageUrl).HasColumnName("profileimageurl");

            });

            modelBuilder.Entity<BookCategory>(entity =>
            {
                entity.ToTable("bookCategories");

                entity.Property(e => e.Name)
                    .HasMaxLength(200)
                    .HasColumnName("name");
                entity.HasData(
                    new BookCategory { Id = 1, Name = "All" },
                    new BookCategory { Id = 2, Name = "Mystery" },
                    new BookCategory { Id = 3, Name = "Thriller" },
                    new BookCategory { Id = 4, Name = "Horror" },
                    new BookCategory { Id = 5, Name = "Romance" },
                    new BookCategory { Id = 6, Name = "Western" },
                    new BookCategory { Id = 7, Name = "Sci-Fi" }
                    );
            });

            modelBuilder.Entity<Book>(entity =>
            {
                entity.ToTable("books");

                entity.Property(e => e.UserId).HasColumnName("userId");

                entity.Property(e => e.Title).HasColumnName("title");
                entity.Property(e => e.Description).HasColumnName("description");
                entity.Property(e => e.ImageUrl).HasColumnName("imageUrl");
                entity.Property(e => e.Category)
                    .HasMaxLength(200)
                    .HasColumnName("category");
                entity.Property(e => e.RentPerMonth)
                    .HasMaxLength(200)
                    .HasColumnName("rentPerMonth");
            });

            modelBuilder.Entity<RentRequest>(entity =>
            {
                entity.ToTable("rentRequests");

                entity.Property(e => e.RequesterId).HasColumnName("requesterId");

                entity.Property(e => e.ReceiverId).HasColumnName("receiverId");

                entity.Property(e => e.BookId).HasColumnName("bookId");

                entity.Property(e => e.RequestDate).HasColumnName("requestDate");

                entity.Property(e => e.Status).HasColumnName("status");

            });


            OnModelCreatingPartial(modelBuilder);
        }
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
