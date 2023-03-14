using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodApp.DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddedCategoryColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "Menu");

            migrationBuilder.AlterColumn<string>(
                name: "Category",
                table: "Menu",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Category",
                table: "Menu",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "Menu",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
