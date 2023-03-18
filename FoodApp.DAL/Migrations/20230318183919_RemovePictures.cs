using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodApp.DAL.Migrations
{
    /// <inheritdoc />
    public partial class RemovePictures : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "image",
                table: "Menu");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "image",
                table: "Menu",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
