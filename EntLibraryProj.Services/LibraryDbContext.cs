using EntLibraryProj.Entities;
using Microsoft.EntityFrameworkCore;

namespace EntLibraryProj.Services
{
    public class LibraryDbContext : DbContext
    {
        public LibraryDbContext(DbContextOptions<LibraryDbContext> options) : base(options) { }

        public DbSet<Book> Books { get; set; }
        public DbSet<Movie> Movies { get;}
        public DbSet<LibraryItem> LibraryItems { get; set; }

        /*
        public DbSet<Category> CategoriesTable { get; set; }
        public DbSet<LibraryItem> ItemsTable { get; set; }
        public DbSet<User> UsersTable { get; set; }
        public DbSet<UserType> UserTypesTable { get; set; }
        */
    }
}
