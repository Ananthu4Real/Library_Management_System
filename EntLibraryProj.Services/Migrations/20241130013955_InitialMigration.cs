using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EntLibraryProj.Services.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    LibraryCardNum = table.Column<int>(type: "INTEGER", maxLength: 10, nullable: false),
                    FirstName = table.Column<string>(type: "TEXT", maxLength: 255, nullable: true),
                    LastName = table.Column<string>(type: "TEXT", maxLength: 255, nullable: true),
                    UserName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "INTEGER", nullable: false),
                    PasswordHash = table.Column<string>(type: "TEXT", nullable: true),
                    SecurityStamp = table.Column<string>(type: "TEXT", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumber = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "INTEGER", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "TEXT", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CategoryInfo",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CategoryName = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryInfo", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RoleId = table.Column<string>(type: "TEXT", nullable: false),
                    ClaimType = table.Column<string>(type: "TEXT", nullable: true),
                    ClaimValue = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    ClaimType = table.Column<string>(type: "TEXT", nullable: true),
                    ClaimValue = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "TEXT", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "TEXT", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "TEXT", nullable: true),
                    UserId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    RoleId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    LoginProvider = table.Column<string>(type: "TEXT", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 128, nullable: false),
                    Value = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LibraryItems",
                columns: table => new
                {
                    LibItemId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CategoryId = table.Column<int>(type: "INTEGER", nullable: false),
                    ItemName = table.Column<string>(type: "TEXT", nullable: true),
                    CreatorName = table.Column<string>(type: "TEXT", nullable: true),
                    Publisher = table.Column<string>(type: "TEXT", nullable: true),
                    OriginCountry = table.Column<string>(type: "TEXT", nullable: true),
                    ItemDescription = table.Column<string>(type: "TEXT", nullable: true),
                    Genre = table.Column<string>(type: "TEXT", nullable: true),
                    Inventory = table.Column<int>(type: "INTEGER", nullable: true),
                    Available = table.Column<int>(type: "INTEGER", nullable: true),
                    ImageURL = table.Column<string>(type: "TEXT", nullable: true),
                    DateAdded = table.Column<string>(type: "TEXT", nullable: true),
                    DateCreated = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LibraryItems", x => x.LibItemId);
                    table.ForeignKey(
                        name: "FK_LibraryItems_CategoryInfo_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "CategoryInfo",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "CategoryInfo",
                columns: new[] { "CategoryId", "CategoryName" },
                values: new object[,]
                {
                    { 1, "Book" },
                    { 2, "Movie" },
                    { 3, "Audiobook" },
                    { 4, "VideoGame" },
                    { 5, "Music" },
                    { 6, "Software" },
                    { 7, "Research Paper" },
                    { 8, "Magazine" },
                    { 9, "Newspaper" }
                });

            migrationBuilder.InsertData(
                table: "LibraryItems",
                columns: new[] { "LibItemId", "Available", "CategoryId", "CreatorName", "DateAdded", "DateCreated", "Genre", "ImageURL", "Inventory", "ItemDescription", "ItemName", "OriginCountry", "Publisher" },
                values: new object[,]
                {
                    { 1, 15, 1, "J.R.R. Tolkien", "2020-06-03", "1937-09-21", "Adventure; Action; Fantasy", null, 15, "Lorum Ipsum", "The Hobbit", "UK", "Allen & Unwin" },
                    { 2, 2, 2, "George Lucas", "2024-05-04", "1999-05-15", "Space Opera; Action; Epic; Fantasy; Sci-Fi", null, 2, " ", "Star Wars Episode 1: The Phantom Menace", "USA", "LucasFilm" },
                    { 3, 2, 2, "George Lucas", "2024-05-04", "2002-05-16", "Space Opera; Action; Epic; Fantasy; Sci Fi", null, 2, "Memes", "Star Wars Episode 2: The Attack of the Clones", "USA", "LucasFilm" },
                    { 4, 2, 2, "George Lucas", "2024-05-04", "2005-05-15", "Space Opera; Action; Epic; Fantasy; Sci-Fi", null, 2, "Hello There", "Star Wars Episode 3: The Revenge of the Sith", "USA", "LucasFilm" },
                    { 5, 1, 2, "Brian De Palma", "2024-01-01", "1983-12-01", "Crime Drama; Action", null, 1, "Excellent movie. 170 Minutes runtime. ", "Scarface", "Italy", "Martin Bregman" },
                    { 6, 7, 3, "J.R.R. Tolkien", "2020-12-23", "2000-09-21", "Adventure; Action; Fantasy", null, 7, "Audiobook format is xxx minutes long", "The Hobbit", "UK", "Allen & Unwin" },
                    { 7, 10, 1, "J.R.R. Tolkien", "2019-07-13", "2004-10-21", "Adventure; Action; Fantasy", null, 10, "Print. 1077 pages total, this 50th anniversary edition was published in 2004. Contains 1954's The Fellowship of the Ring and The Two Towers, and 1955's The Return of the King", "The Lord of The Rings Complete Novel", "UK", "George Allen & Unwin" },
                    { 8, 3, 4, "Hidetaka Miyazaki/From Software", "2024-02-26", "2011-09-22", "Adventure; Action; Dark Fantasy; Soulsborne", null, 3, "Git gud", "Dark Souls", "JP", "Bandai Namco" },
                    { 9, 3, 4, "Nintendo", "2024-03-27", "2017-10-27", "Platform, Adventure; Action", null, 3, "", "Super Mario Odyssey", "JP", "Nintendo" },
                    { 10, 4, 5, "Pink Floyd", "2024-04-11", "1973-03-01", "Progressive Rock", null, 4, "Pink Floyd's album The Dark Side of the Moon is certified 14x platinum in the United Kingdom, and topped the US Billboard Top LPs & Tape chart, where it has charted for 990 weeks.", "The Dark Side of the Moon", "UK", "Harvest Records" },
                    { 11, 2, 6, "Visual Paradigm", "2024-05-27", "2001-03-01", "Software; UML", null, 2, "Software", "Visual Paradigm", "Hong Kong", "Visual Paradigm" },
                    { 12, 2, 7, "Michael W. Godfrey; Daniel M. German", "2024-06-17", "2008-10-04", "Software Design", null, 2, "Research Paper", "The past, present, and future of software evolution", "Canada", "IEEE" },
                    { 13, 4, 8, "Laphams Quarterly", "2023-11-11", "2024-07-07", "Education; Science; Philosophy", null, 4, "Learn", "Freedom", "USA", "Laphams Quarterly" },
                    { 14, 2, 8, "Tony Perrottet", "2024-06-17", "2013-06-20", "History; Education", null, 2, "Are you thinking of the Roman Empire now?", "The Glory that is Rome", "USA", "Smithsonian Magazine" },
                    { 15, 1, 9, "The Charlotte Observer", "2024-06-17", "1945-08-15", "History; Education", null, 1, "Newpaper from the final days of WW2. ", "PEACE! IT'S OVER", "USA", "The Charlotte Observer" },
                    { 16, 2, 1, "Liam Neeson", "2020-08-02", "1998-05-01", "Action; Screenplay; Romance", null, 2, "Screenplay of the 1998 movie of the Victor Hugo Classic ", "Les Miserables", "USA; Germany; UK; Ireland", "Sony Pictures" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_LibraryItems_CategoryId",
                table: "LibraryItems",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "LibraryItems");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "CategoryInfo");
        }
    }
}
