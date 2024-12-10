using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bibek.BookStore.Migrations
{
    /// <inheritdoc />
    public partial class updatebokktable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ConcurrencyStamp",
                table: "Client",
                type: "nvarchar(40)",
                maxLength: 40,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ExtraProperties",
                table: "Client",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ConcurrencyStamp",
                table: "Book",
                type: "nvarchar(40)",
                maxLength: 40,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ExtraProperties",
                table: "Book",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ConcurrencyStamp",
                table: "Client");

            migrationBuilder.DropColumn(
                name: "ExtraProperties",
                table: "Client");

            migrationBuilder.DropColumn(
                name: "ConcurrencyStamp",
                table: "Book");

            migrationBuilder.DropColumn(
                name: "ExtraProperties",
                table: "Book");
        }
    }
}
