using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Movie_Rental_Management.Migrations
{
    /// <inheritdoc />
    public partial class hhhhh : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RentalQuantity",
                table: "Rents",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RentalQuantity",
                table: "Rents");
        }
    }
}
