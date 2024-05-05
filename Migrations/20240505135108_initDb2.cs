using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyHotel.Migrations
{
    public partial class initDb2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CheckInDate",
                table: "DetailBookingServices");

            migrationBuilder.DropColumn(
                name: "CheckInDate",
                table: "BookingServices");

            migrationBuilder.RenameColumn(
                name: "CheckOutDate",
                table: "DetailBookingServices",
                newName: "CreateDate");

            migrationBuilder.RenameColumn(
                name: "CheckOutDate",
                table: "BookingServices",
                newName: "CreateDate");

            migrationBuilder.AddColumn<int>(
                name: "Amount",
                table: "DetailBookingServices",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "StaffId",
                table: "BookingServices",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Amount",
                table: "DetailBookingServices");

            migrationBuilder.RenameColumn(
                name: "CreateDate",
                table: "DetailBookingServices",
                newName: "CheckOutDate");

            migrationBuilder.RenameColumn(
                name: "CreateDate",
                table: "BookingServices",
                newName: "CheckOutDate");

            migrationBuilder.AddColumn<DateTime>(
                name: "CheckInDate",
                table: "DetailBookingServices",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<string>(
                name: "StaffId",
                table: "BookingServices",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<DateTime>(
                name: "CheckInDate",
                table: "BookingServices",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
