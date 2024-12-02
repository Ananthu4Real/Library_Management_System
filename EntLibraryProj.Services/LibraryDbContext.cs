using EntLibraryProj.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EntLibraryProj.Services;
public class LibraryDbContext : IdentityDbContext<LibraryUser>
{
    /// <summary>
    /// By Ian. Constructor works as normal, but it should be noted that the class uses the Identity db context instead of the normal way of building to implement the LibraryUser identity properly
    /// </summary>
    /// <param name="options"></param>
    public LibraryDbContext(DbContextOptions<LibraryDbContext> options) 
        : base(options) { }

    public DbSet<LibraryItem> LibraryItems { get; set; }
    public DbSet<Category> CategoryInfo { get; set; }
    public DbSet<LibraryUser> UserTable { get; set; } = default!;

    /// <summary>
    /// Seeds database with various entries, including necessary categories, and library items for each category
    /// </summary>
    /// <param name="modelBuilder"></param>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>().HasData(
            new Category { CategoryId = 1, CategoryName = "Book" },
            new Category { CategoryId = 2, CategoryName = "Movie" },
            new Category { CategoryId = 3, CategoryName = "Audiobook" },
            new Category { CategoryId = 4, CategoryName = "VideoGame" },
            new Category { CategoryId = 5, CategoryName = "Music" },
            new Category { CategoryId = 6, CategoryName = "Software" },
            new Category { CategoryId = 7, CategoryName = "Research Paper" },
            new Category { CategoryId = 8, CategoryName = "Magazine" },
            new Category { CategoryId = 9, CategoryName = "Newspaper" }
        );
        modelBuilder.Entity<LibraryItem>().HasData(
            new LibraryItem
            {
                LibItemId = 1,
                CategoryId = 1,
                ItemName = "The Hobbit",
                CreatorName = "J.R.R. Tolkien",
                Publisher = "Allen & Unwin",
                OriginCountry = "UK",
                ItemDescription = "Lorum Ipsum",
                Genre = "Adventure; Action; Fantasy",
                Inventory = 15,
                Available = 15,
                DateAdded = "2020-06-03",
                DateCreated = "1937-09-21"
            },

            new LibraryItem
            {
                LibItemId = 2,
                CategoryId = 2,
                ItemName = "Star Wars Episode 1: The Phantom Menace",
                CreatorName = "George Lucas",
                Publisher = "LucasFilm",
                OriginCountry = "USA",
                ItemDescription = " ",
                Genre = "Space Opera; Action; Epic; Fantasy; Sci-Fi",
                Inventory = 2,
                Available = 2,
                DateAdded = "2024-05-04",
                DateCreated = "1999-05-15"
            },
            new LibraryItem
            {
                LibItemId = 3,
                CategoryId = 2,
                ItemName = "Star Wars Episode 2: The Attack of the Clones",
                CreatorName = "George Lucas",
                Publisher = "LucasFilm",
                OriginCountry = "USA",
                ItemDescription = "Memes",
                Genre = "Space Opera; Action; Epic; Fantasy; Sci Fi",
                Inventory = 2,
                Available = 2,
                DateAdded = "2024-05-04",
                DateCreated = "2002-05-16"
            },
            new LibraryItem
            {
                LibItemId = 4,
                CategoryId = 2,
                ItemName = "Star Wars Episode 3: The Revenge of the Sith",
                CreatorName = "George Lucas",
                Publisher = "LucasFilm",
                OriginCountry = "USA",
                ItemDescription = "Hello There",
                Genre = "Space Opera; Action; Epic; Fantasy; Sci-Fi",
                Inventory = 2,
                Available = 2,
                DateAdded = "2024-05-04",
                DateCreated = "2005-05-15"
            },
            new LibraryItem
            {
                LibItemId = 5,
                CategoryId = 2,
                ItemName = "Scarface",
                CreatorName = "Brian De Palma",
                Publisher = "Martin Bregman",
                OriginCountry = "Italy",
                ItemDescription = "Excellent movie. 170 Minutes runtime. ",
                Genre = "Crime Drama; Action",
                Inventory = 1,
                Available = 1,
                DateAdded = "2024-01-01",
                DateCreated = "1983-12-01"
            },
            new LibraryItem
            {
                LibItemId = 6,
                CategoryId = 3,
                ItemName = "The Hobbit",
                CreatorName = "J.R.R. Tolkien",
                Publisher = "Allen & Unwin",
                OriginCountry = "UK",
                ItemDescription = "Audiobook format is xxx minutes long",
                Genre = "Adventure; Action; Fantasy",
                Inventory = 7,
                Available = 7,
                DateAdded = "2020-12-23",
                DateCreated = "2000-09-21"
            },
            new LibraryItem
            {
                LibItemId = 7,
                CategoryId = 1,
                ItemName = "The Lord of The Rings Complete Novel",
                CreatorName = "J.R.R. Tolkien",
                Publisher = "George Allen & Unwin",
                OriginCountry = "UK",
                ItemDescription = "Print. 1077 pages total, this 50th anniversary edition was published in 2004. Contains 1954's The Fellowship of the Ring and The Two Towers, and 1955's The Return of the King",
                Genre = "Adventure; Action; Fantasy",
                Inventory = 10,
                Available = 10,
                DateAdded = "2019-07-13",
                DateCreated = "2004-10-21"
            },
            new LibraryItem
            {
                LibItemId = 8,
                CategoryId = 4,
                ItemName = "Dark Souls",
                CreatorName = "Hidetaka Miyazaki/From Software",
                Publisher = "Bandai Namco",
                OriginCountry = "JP",
                ItemDescription = "Git gud",
                Genre = "Adventure; Action; Dark Fantasy; Soulsborne",
                Inventory = 3,
                Available = 3,
                DateAdded = "2024-02-26",
                DateCreated = "2011-09-22"
            },
            new LibraryItem
            {
                LibItemId = 9,
                CategoryId = 4,
                ItemName = "Super Mario Odyssey",
                CreatorName = "Nintendo",
                Publisher = "Nintendo",
                OriginCountry = "JP",
                ItemDescription = "",
                Genre = "Platform, Adventure; Action",
                Inventory = 3,
                Available = 3,
                DateAdded = "2024-03-27",
                DateCreated = "2017-10-27"
            },
            new LibraryItem
            {
                LibItemId = 10,
                CategoryId = 5,
                ItemName = "The Dark Side of the Moon",
                CreatorName = "Pink Floyd",
                Publisher = "Harvest Records",
                OriginCountry = "UK",
                ItemDescription = "Pink Floyd's album The Dark Side of the Moon is certified 14x platinum in the United Kingdom, and topped the US Billboard Top LPs & Tape chart, where it has charted for 990 weeks.",
                Genre = "Progressive Rock",
                Inventory = 4,
                Available = 4,
                DateAdded = "2024-04-11",
                DateCreated = "1973-03-01"
            },
            new LibraryItem
            {
                LibItemId = 11,
                CategoryId = 6,
                ItemName = "Visual Paradigm",
                CreatorName = "Visual Paradigm",
                Publisher = "Visual Paradigm",
                OriginCountry = "Hong Kong",
                ItemDescription = "Software",
                Genre = "Software; UML",
                Inventory = 2,
                Available = 2,
                DateAdded = "2024-05-27",
                DateCreated = "2001-03-01"
            },
            new LibraryItem
            {
                LibItemId = 12,
                CategoryId = 7,
                ItemName = "The past, present, and future of software evolution",
                CreatorName = "Michael W. Godfrey; Daniel M. German",
                Publisher = "IEEE",
                OriginCountry = "Canada",
                ItemDescription = "Research Paper",
                Genre = "Software Design",
                Inventory = 2,
                Available = 2,
                DateAdded = "2024-06-17",
                DateCreated = "2008-10-04"
            },
            new LibraryItem
            {
                LibItemId = 13,
                CategoryId = 8,
                ItemName = "Freedom",
                CreatorName = "Laphams Quarterly",
                Publisher = "Laphams Quarterly",
                OriginCountry = "USA",
                ItemDescription = "Learn",
                Genre = "Education; Science; Philosophy",
                Inventory = 4,
                Available = 4,
                DateAdded = "2023-11-11",
                DateCreated = "2024-07-07"
            },
            new LibraryItem
            {
                LibItemId = 14,
                CategoryId = 8,
                ItemName = "The Glory that is Rome",
                CreatorName = "Tony Perrottet",
                Publisher = "Smithsonian Magazine",
                OriginCountry = "USA",
                ItemDescription = "Are you thinking of the Roman Empire now?",
                Genre = "History; Education",
                Inventory = 2,
                Available = 2,
                DateAdded = "2024-06-17",
                DateCreated = "2013-06-20"
            },
            new LibraryItem
            {
                LibItemId = 15,
                CategoryId = 9,
                ItemName = "PEACE! IT'S OVER",
                CreatorName = "The Charlotte Observer",
                Publisher = "The Charlotte Observer",
                OriginCountry = "USA",
                ItemDescription = "Newpaper from the final days of WW2. ",
                Genre = "History; Education",
                Inventory = 1,
                Available = 1,
                DateAdded = "2024-06-17",
                DateCreated = "1945-08-15"
            },
            new LibraryItem
            {
                LibItemId = 16,
                CategoryId = 1,
                ItemName = "Les Miserables",
                CreatorName = "Liam Neeson",
                Publisher = "Sony Pictures",
                OriginCountry = "USA; Germany; UK; Ireland",
                ItemDescription = "Screenplay of the 1998 movie of the Victor Hugo Classic ",
                Genre = "Action; Screenplay; Romance",
                Inventory = 2,
                Available = 2,
                DateAdded = "2020-08-02",
                DateCreated = "1998-05-01"
            }
        );

        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfiguration(new ApplicationUserEntityConfiguration());
    }
    /// <summary>
    /// Adds the first name/last name and library card number to the LibraryUser's respective table
    /// </summary>
    internal class ApplicationUserEntityConfiguration : IEntityTypeConfiguration<LibraryUser>
    {
        public void Configure(EntityTypeBuilder<LibraryUser> builder)
        {
            builder.Property(u => u.FirstName).HasMaxLength(255);
            builder.Property(u => u.LastName).HasMaxLength(255);
            builder.Property(u => u.LibraryCardNum).HasMaxLength(10);
        }
    }
}

