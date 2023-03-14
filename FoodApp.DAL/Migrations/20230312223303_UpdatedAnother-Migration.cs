using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodApp.DAL.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedAnotherMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Menu_Customers_CustomerId",
                table: "Menu");

            migrationBuilder.DropIndex(
                name: "IX_Menu_CustomerId",
                table: "Menu");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "Menu");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CustomerId",
                table: "Menu",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Menu_CustomerId",
                table: "Menu",
                column: "CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Menu_Customers_CustomerId",
                table: "Menu",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id");
        }
    }
}
