using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EntLibraryProj.Services.Migrations
{
    /// <inheritdoc />
    public partial class _3UserItems : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_LibraryItems_itemId",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "itemId",
                table: "AspNetUsers",
                newName: "itemId3");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetUsers_itemId",
                table: "AspNetUsers",
                newName: "IX_AspNetUsers_itemId3");

            migrationBuilder.AddColumn<int>(
                name: "itemId1",
                table: "AspNetUsers",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "itemId2",
                table: "AspNetUsers",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_itemId1",
                table: "AspNetUsers",
                column: "itemId1");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_itemId2",
                table: "AspNetUsers",
                column: "itemId2");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_LibraryItems_itemId1",
                table: "AspNetUsers",
                column: "itemId1",
                principalTable: "LibraryItems",
                principalColumn: "LibItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_LibraryItems_itemId2",
                table: "AspNetUsers",
                column: "itemId2",
                principalTable: "LibraryItems",
                principalColumn: "LibItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_LibraryItems_itemId3",
                table: "AspNetUsers",
                column: "itemId3",
                principalTable: "LibraryItems",
                principalColumn: "LibItemId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_LibraryItems_itemId1",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_LibraryItems_itemId2",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_LibraryItems_itemId3",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_itemId1",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_itemId2",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "itemId1",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "itemId2",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "itemId3",
                table: "AspNetUsers",
                newName: "itemId");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetUsers_itemId3",
                table: "AspNetUsers",
                newName: "IX_AspNetUsers_itemId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_LibraryItems_itemId",
                table: "AspNetUsers",
                column: "itemId",
                principalTable: "LibraryItems",
                principalColumn: "LibItemId");
        }
    }
}
