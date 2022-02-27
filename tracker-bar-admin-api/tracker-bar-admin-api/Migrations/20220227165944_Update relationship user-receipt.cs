using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace tracker_bar_admin_api.Migrations
{
    public partial class Updaterelationshipuserreceipt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Receipts_User_UserId",
                table: "Receipts");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Receipts",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Receipts_User_UserId",
                table: "Receipts",
                column: "UserId",
                principalTable: "User",
                principalColumn: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Receipts_User_UserId",
                table: "Receipts");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Receipts",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Receipts_User_UserId",
                table: "Receipts",
                column: "UserId",
                principalTable: "User",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
