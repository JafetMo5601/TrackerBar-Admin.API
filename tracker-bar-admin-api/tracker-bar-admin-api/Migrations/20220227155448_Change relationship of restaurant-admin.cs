using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace tracker_bar_admin_api.Migrations
{
    public partial class Changerelationshipofrestaurantadmin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Receipt_ReceiptDetail_ReceiptDetailId",
                table: "Receipt");

            migrationBuilder.DropForeignKey(
                name: "FK_Receipt_User_UserId",
                table: "Receipt");

            migrationBuilder.DropForeignKey(
                name: "FK_UserDirection_Directions_DirectionId",
                table: "UserDirection");

            migrationBuilder.DropForeignKey(
                name: "FK_UserDirection_User_UserId",
                table: "UserDirection");

            migrationBuilder.DropForeignKey(
                name: "FK_UserPhone_Phone_PhoneId",
                table: "UserPhone");

            migrationBuilder.DropForeignKey(
                name: "FK_UserPhone_User_UserId",
                table: "UserPhone");

            migrationBuilder.DropTable(
                name: "AdminRestaurante");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserPhone",
                table: "UserPhone");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserDirection",
                table: "UserDirection");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Receipt",
                table: "Receipt");

            migrationBuilder.RenameTable(
                name: "UserPhone",
                newName: "UserPhones");

            migrationBuilder.RenameTable(
                name: "UserDirection",
                newName: "UserDirections");

            migrationBuilder.RenameTable(
                name: "Receipt",
                newName: "Receipts");

            migrationBuilder.RenameIndex(
                name: "IX_UserPhone_UserId",
                table: "UserPhones",
                newName: "IX_UserPhones_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_UserPhone_PhoneId",
                table: "UserPhones",
                newName: "IX_UserPhones_PhoneId");

            migrationBuilder.RenameIndex(
                name: "IX_UserDirection_UserId",
                table: "UserDirections",
                newName: "IX_UserDirections_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_UserDirection_DirectionId",
                table: "UserDirections",
                newName: "IX_UserDirections_DirectionId");

            migrationBuilder.RenameIndex(
                name: "IX_Receipt_UserId",
                table: "Receipts",
                newName: "IX_Receipts_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Receipt_ReceiptDetailId",
                table: "Receipts",
                newName: "IX_Receipts_ReceiptDetailId");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Restaurants",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserPhones",
                table: "UserPhones",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserDirections",
                table: "UserDirections",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Receipts",
                table: "Receipts",
                column: "ReceiptId");

            migrationBuilder.CreateIndex(
                name: "IX_Restaurants_UserId",
                table: "Restaurants",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Receipts_ReceiptDetail_ReceiptDetailId",
                table: "Receipts",
                column: "ReceiptDetailId",
                principalTable: "ReceiptDetail",
                principalColumn: "ReceiptDetailId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Receipts_User_UserId",
                table: "Receipts",
                column: "UserId",
                principalTable: "User",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Restaurants_User_UserId",
                table: "Restaurants",
                column: "UserId",
                principalTable: "User",
                principalColumn: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserDirections_Directions_DirectionId",
                table: "UserDirections",
                column: "DirectionId",
                principalTable: "Directions",
                principalColumn: "DirectionId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserDirections_User_UserId",
                table: "UserDirections",
                column: "UserId",
                principalTable: "User",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserPhones_Phone_PhoneId",
                table: "UserPhones",
                column: "PhoneId",
                principalTable: "Phone",
                principalColumn: "PhoneId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserPhones_User_UserId",
                table: "UserPhones",
                column: "UserId",
                principalTable: "User",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Receipts_ReceiptDetail_ReceiptDetailId",
                table: "Receipts");

            migrationBuilder.DropForeignKey(
                name: "FK_Receipts_User_UserId",
                table: "Receipts");

            migrationBuilder.DropForeignKey(
                name: "FK_Restaurants_User_UserId",
                table: "Restaurants");

            migrationBuilder.DropForeignKey(
                name: "FK_UserDirections_Directions_DirectionId",
                table: "UserDirections");

            migrationBuilder.DropForeignKey(
                name: "FK_UserDirections_User_UserId",
                table: "UserDirections");

            migrationBuilder.DropForeignKey(
                name: "FK_UserPhones_Phone_PhoneId",
                table: "UserPhones");

            migrationBuilder.DropForeignKey(
                name: "FK_UserPhones_User_UserId",
                table: "UserPhones");

            migrationBuilder.DropIndex(
                name: "IX_Restaurants_UserId",
                table: "Restaurants");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserPhones",
                table: "UserPhones");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserDirections",
                table: "UserDirections");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Receipts",
                table: "Receipts");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Restaurants");

            migrationBuilder.RenameTable(
                name: "UserPhones",
                newName: "UserPhone");

            migrationBuilder.RenameTable(
                name: "UserDirections",
                newName: "UserDirection");

            migrationBuilder.RenameTable(
                name: "Receipts",
                newName: "Receipt");

            migrationBuilder.RenameIndex(
                name: "IX_UserPhones_UserId",
                table: "UserPhone",
                newName: "IX_UserPhone_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_UserPhones_PhoneId",
                table: "UserPhone",
                newName: "IX_UserPhone_PhoneId");

            migrationBuilder.RenameIndex(
                name: "IX_UserDirections_UserId",
                table: "UserDirection",
                newName: "IX_UserDirection_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_UserDirections_DirectionId",
                table: "UserDirection",
                newName: "IX_UserDirection_DirectionId");

            migrationBuilder.RenameIndex(
                name: "IX_Receipts_UserId",
                table: "Receipt",
                newName: "IX_Receipt_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Receipts_ReceiptDetailId",
                table: "Receipt",
                newName: "IX_Receipt_ReceiptDetailId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserPhone",
                table: "UserPhone",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserDirection",
                table: "UserDirection",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Receipt",
                table: "Receipt",
                column: "ReceiptId");

            migrationBuilder.CreateTable(
                name: "AdminRestaurante",
                columns: table => new
                {
                    AdminRestauranteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RestaurantId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdminRestaurante", x => x.AdminRestauranteId);
                    table.ForeignKey(
                        name: "FK_AdminRestaurante_Restaurants_RestaurantId",
                        column: x => x.RestaurantId,
                        principalTable: "Restaurants",
                        principalColumn: "RestaurantId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AdminRestaurante_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AdminRestaurante_RestaurantId",
                table: "AdminRestaurante",
                column: "RestaurantId");

            migrationBuilder.CreateIndex(
                name: "IX_AdminRestaurante_UserId",
                table: "AdminRestaurante",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Receipt_ReceiptDetail_ReceiptDetailId",
                table: "Receipt",
                column: "ReceiptDetailId",
                principalTable: "ReceiptDetail",
                principalColumn: "ReceiptDetailId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Receipt_User_UserId",
                table: "Receipt",
                column: "UserId",
                principalTable: "User",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserDirection_Directions_DirectionId",
                table: "UserDirection",
                column: "DirectionId",
                principalTable: "Directions",
                principalColumn: "DirectionId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserDirection_User_UserId",
                table: "UserDirection",
                column: "UserId",
                principalTable: "User",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserPhone_Phone_PhoneId",
                table: "UserPhone",
                column: "PhoneId",
                principalTable: "Phone",
                principalColumn: "PhoneId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserPhone_User_UserId",
                table: "UserPhone",
                column: "UserId",
                principalTable: "User",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
