using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Movie_Rental_Management.Migrations
{
    /// <inheritdoc />
    public partial class init2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rents_Customers_CustomerId",
                table: "Rents");

            migrationBuilder.RenameColumn(
                name: "CustomerId",
                table: "Rents",
                newName: "userId");

            migrationBuilder.RenameIndex(
                name: "IX_Rents_CustomerId",
                table: "Rents",
                newName: "IX_Rents_userId");

            migrationBuilder.AddForeignKey(
                name: "FK_Rents_Users_userId",
                table: "Rents",
                column: "userId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rents_Users_userId",
                table: "Rents");

            migrationBuilder.RenameColumn(
                name: "userId",
                table: "Rents",
                newName: "CustomerId");

            migrationBuilder.RenameIndex(
                name: "IX_Rents_userId",
                table: "Rents",
                newName: "IX_Rents_CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Rents_Customers_CustomerId",
                table: "Rents",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
