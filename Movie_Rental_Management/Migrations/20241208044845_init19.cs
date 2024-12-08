using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Movie_Rental_Management.Migrations
{
    /// <inheritdoc />
    public partial class init19 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RecieverId",
                table: "Notifications",
                newName: "ReceiverId");

            migrationBuilder.AddColumn<string>(
                name: "Nic",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "ViewStatus",
                table: "Notifications",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Nic",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Phone",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "ViewStatus",
                table: "Notifications");

            migrationBuilder.RenameColumn(
                name: "ReceiverId",
                table: "Notifications",
                newName: "RecieverId");
        }
    }
}
