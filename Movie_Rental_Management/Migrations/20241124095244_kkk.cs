using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Movie_Rental_Management.Migrations
{
    /// <inheritdoc />
    public partial class kkk : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Payment_Customers_CustomerId",
                table: "Payment");

            migrationBuilder.DropForeignKey(
                name: "FK_Rents_Customers_CustomerId",
                table: "Rents");

            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Customers_CustomerId",
                table: "Reviews");

            migrationBuilder.DropIndex(
                name: "IX_Rents_CustomerId",
                table: "Rents");

            migrationBuilder.DropIndex(
                name: "IX_Payment_CustomerId",
                table: "Payment");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "Payment");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "JoinDate",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "MobileNumber",
                table: "Customers");

            migrationBuilder.RenameColumn(
                name: "CustomerId",
                table: "Reviews",
                newName: "customerId");

            migrationBuilder.RenameIndex(
                name: "IX_Reviews_CustomerId",
                table: "Reviews",
                newName: "IX_Reviews_customerId");

            migrationBuilder.RenameColumn(
                name: "NIC",
                table: "Customers",
                newName: "Phone");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "Customers",
                newName: "Password");

            migrationBuilder.RenameColumn(
                name: "FirstName",
                table: "Customers",
                newName: "Name");

            migrationBuilder.AlterColumn<int>(
                name: "customerId",
                table: "Reviews",
                type: "int",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<Guid>(
                name: "CustomerId",
                table: "Reviews",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<int>(
                name: "CustomerId1",
                table: "Rents",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Customers",
                type: "int",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.CreateIndex(
                name: "IX_Rents_CustomerId1",
                table: "Rents",
                column: "CustomerId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Rents_Customers_CustomerId1",
                table: "Rents",
                column: "CustomerId1",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Customers_customerId",
                table: "Reviews",
                column: "customerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rents_Customers_CustomerId1",
                table: "Rents");

            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Customers_customerId",
                table: "Reviews");

            migrationBuilder.DropIndex(
                name: "IX_Rents_CustomerId1",
                table: "Rents");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "Reviews");

            migrationBuilder.DropColumn(
                name: "CustomerId1",
                table: "Rents");

            migrationBuilder.RenameColumn(
                name: "customerId",
                table: "Reviews",
                newName: "CustomerId");

            migrationBuilder.RenameIndex(
                name: "IX_Reviews_customerId",
                table: "Reviews",
                newName: "IX_Reviews_CustomerId");

            migrationBuilder.RenameColumn(
                name: "Phone",
                table: "Customers",
                newName: "NIC");

            migrationBuilder.RenameColumn(
                name: "Password",
                table: "Customers",
                newName: "LastName");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Customers",
                newName: "FirstName");

            migrationBuilder.AlterColumn<Guid>(
                name: "CustomerId",
                table: "Reviews",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<Guid>(
                name: "CustomerId",
                table: "Payment",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Customers",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Customers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "JoinDate",
                table: "Customers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "MobileNumber",
                table: "Customers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Rents_CustomerId",
                table: "Rents",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Payment_CustomerId",
                table: "Payment",
                column: "CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Payment_Customers_CustomerId",
                table: "Payment",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Rents_Customers_CustomerId",
                table: "Rents",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Customers_CustomerId",
                table: "Reviews",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
