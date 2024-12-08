using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Movie_Rental_Management.Migrations
{
    /// <inheritdoc />
    public partial class init6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Rents_userId",
                table: "Rents");

            migrationBuilder.CreateIndex(
                name: "IX_Rents_userId",
                table: "Rents",
                column: "userId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Rents_userId",
                table: "Rents");

            migrationBuilder.CreateIndex(
                name: "IX_Rents_userId",
                table: "Rents",
                column: "userId",
                unique: true);
        }
    }
}
