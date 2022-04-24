using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrackerBar_Admin.API.Migrations
{
    public partial class adddatetimeinvoices : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "boughtAt",
                table: "ReceiptDetail",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "boughtAt",
                table: "ReceiptDetail");
        }
    }
}
