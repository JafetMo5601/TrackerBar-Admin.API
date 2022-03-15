using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrackerBar_Admin.API.Migrations
{
    public partial class Add_relation_invoice_restaurant : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RestaurantId",
                table: "ReceiptDetail",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ReceiptDetail_RestaurantId",
                table: "ReceiptDetail",
                column: "RestaurantId");

            migrationBuilder.AddForeignKey(
                name: "FK_ReceiptDetail_Restaurant_RestaurantId",
                table: "ReceiptDetail",
                column: "RestaurantId",
                principalTable: "Restaurant",
                principalColumn: "RestaurantId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ReceiptDetail_Restaurant_RestaurantId",
                table: "ReceiptDetail");

            migrationBuilder.DropIndex(
                name: "IX_ReceiptDetail_RestaurantId",
                table: "ReceiptDetail");

            migrationBuilder.DropColumn(
                name: "RestaurantId",
                table: "ReceiptDetail");
        }
    }
}
