using EntLibraryProj.Entities;
using Microsoft.EntityFrameworkCore

namespace EntLibraryProj.Services
{
    public class LibraryDbContext : DbContext
    {
        public LibraryDbContext(DbContextOptions<LibraryDbContext> options) : base(options) { }

        public DbSet<Category> CategoriesTable { get; set; }
        public DbSet<LibraryItem> ItemsTable { get; set; }
        public DbSet<User> UsersTable { get; set; }
        public DbSet<UserType> UserTypesTable { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { CategoryId = 1, CategoryName = "Book" },
                new Category { CategoryId = 2, CategoryName = "Movie" },
                new Category { CategoryId = 3, CategoryName = "Audiobook" },
                new Category { CategoryId = 4, CategoryName = "Video Program" },
                new Category { CategoryId = 5, CategoryName = "VideoGame" },
                new Category { CategoryId = 6, CategoryName = "Music" },
                new Category { CategoryId = 7, CategoryName = "Software" },
                new Category { CategoryId = 8, CategoryName = "Research Paper" },
                new Category { CategoryId = 9, CategoryName = "Magazine" },
                new Category { CategoryId = 10, CategoryName = "Newspaper" }
            );
            base.OnModelCreating(modelBuilder);
        }
    }
}
