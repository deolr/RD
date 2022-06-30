using Microsoft.EntityFrameworkCore;
using Bookstore.Models;

namespace Bookstore.DBContexts
{
    /// <summary>
    /// DBContext that allows Book model to interact with the database
    /// </summary>
    public class BookContext : DbContext
    {
        public BookContext(DbContextOptions<BookContext> options) : base(options)
        {
            this.Database.EnsureCreated();
        }
        public DbSet<Book> Books { get; set; }

        /// <summary>
        /// Store default data in the database
        /// </summary>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>().HasData(
                new Book
                {
                    Id = 1,
                    Title = "C# In Depth",
                    Description = "A great book with latest features in C#",
                    Author = "Jon Skeet",
                    CoverImage=@"/images/1/coverImage.png",
                    Price=65.99
                },
               new Book
               {
                   Id = 2,
                   Title = "Murach's SQL Server 2019",
                   Description = "A great SQL book for every developer",
                   Author = "Joel Murach",
                   CoverImage = @"/images/2/coverImage.png",
                   Price = 59.50
               }
            );
        }

    }
}