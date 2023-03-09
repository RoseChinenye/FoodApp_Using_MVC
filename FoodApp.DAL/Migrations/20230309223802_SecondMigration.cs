using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodApp.DAL.Migrations
{
    /// <inheritdoc />
    public partial class SecondMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Menus_Admins_AdminId",
                table: "Menus");

            migrationBuilder.DropForeignKey(
                name: "FK_Menus_Customers_CustomerId",
                table: "Menus");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Menus",
                table: "Menus");

            migrationBuilder.RenameTable(
                name: "Menus",
                newName: "Menu");

            migrationBuilder.RenameIndex(
                name: "IX_Menus_CustomerId",
                table: "Menu",
                newName: "IX_Menu_CustomerId");

            migrationBuilder.RenameIndex(
                name: "IX_Menus_AdminId",
                table: "Menu",
                newName: "IX_Menu_AdminId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Menu",
                table: "Menu",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Menu_Admins_AdminId",
                table: "Menu",
                column: "AdminId",
                principalTable: "Admins",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Menu_Customers_CustomerId",
                table: "Menu",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Menu_Admins_AdminId",
                table: "Menu");

            migrationBuilder.DropForeignKey(
                name: "FK_Menu_Customers_CustomerId",
                table: "Menu");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Menu",
                table: "Menu");

            migrationBuilder.RenameTable(
                name: "Menu",
                newName: "Menus");

            migrationBuilder.RenameIndex(
                name: "IX_Menu_CustomerId",
                table: "Menus",
                newName: "IX_Menus_CustomerId");

            migrationBuilder.RenameIndex(
                name: "IX_Menu_AdminId",
                table: "Menus",
                newName: "IX_Menus_AdminId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Menus",
                table: "Menus",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Menus_Admins_AdminId",
                table: "Menus",
                column: "AdminId",
                principalTable: "Admins",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Menus_Customers_CustomerId",
                table: "Menus",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id");
        }
    }
}
