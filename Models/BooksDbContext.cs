using Microsoft.EntityFrameworkCore;

namespace BooksWebApp.Models
{
    public class BooksDbContext : DbContext
    {
        public BooksDbContext()
        {
            Database.EnsureCreated();
        }

        public DbSet<Book> Books { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Connection string
            optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=BooksDatabase");
        }

        // Kapcsolatok és Seeding beállítás
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Seedelés
            modelBuilder.Entity<Book>().HasData
                (
                    new Book() 
                    {
                        Id = 1,
                        Title = "American Gods",
                        Author = "Neil Gaiman",
                        ReleaseDate = DateTime.Parse("2016-08-16")
                    },
                    new Book()
                    {
                        Id = 2,
                        Title = "Dune",
                        Author = "Frank Herbert",
                        ReleaseDate = DateTime.Parse("1965-08-01")
                    },
                    new Book()
                    {
                        Id = 3,
                        Title = "The Da Vinci Code",
                        Author = "Dan Brown",
                        ReleaseDate = DateTime.Parse("2003-03-18")
                    }
                );
            base.OnModelCreating(modelBuilder);
        }
    }
}
