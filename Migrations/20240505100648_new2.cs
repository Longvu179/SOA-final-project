using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyHotel.Migrations
{
    public partial class new2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "InvoiceId",
                table: "BookingServices",
                newName: "DBR_Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DBR_Id",
                table: "BookingServices",
                newName: "InvoiceId");
        }
    }
}
