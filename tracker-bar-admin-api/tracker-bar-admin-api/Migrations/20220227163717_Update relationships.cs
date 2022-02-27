using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace tracker_bar_admin_api.Migrations
{
    public partial class Updaterelationships : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserDirections");

            migrationBuilder.DropTable(
                name: "UserPhones");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Phone",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Directions",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Phone_UserId",
                table: "Phone",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Directions_UserId",
                table: "Directions",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Directions_User_UserId",
                table: "Directions",
                column: "UserId",
                principalTable: "User",
                principalColumn: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Phone_User_UserId",
                table: "Phone",
                column: "UserId",
                principalTable: "User",
                principalColumn: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Directions_User_UserId",
                table: "Directions");

            migrationBuilder.DropForeignKey(
                name: "FK_Phone_User_UserId",
                table: "Phone");

            migrationBuilder.DropIndex(
                name: "IX_Phone_UserId",
                table: "Phone");

            migrationBuilder.DropIndex(
                name: "IX_Directions_UserId",
                table: "Directions");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Phone");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Directions");

            migrationBuilder.CreateTable(
                name: "UserDirections",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DirectionId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserDirections", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserDirections_Directions_DirectionId",
                        column: x => x.DirectionId,
                        principalTable: "Directions",
                        principalColumn: "DirectionId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserDirections_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserPhones",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PhoneId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserPhones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserPhones_Phone_PhoneId",
                        column: x => x.PhoneId,
                        principalTable: "Phone",
                        principalColumn: "PhoneId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserPhones_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserDirections_DirectionId",
                table: "UserDirections",
                column: "DirectionId");

            migrationBuilder.CreateIndex(
                name: "IX_UserDirections_UserId",
                table: "UserDirections",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserPhones_PhoneId",
                table: "UserPhones",
                column: "PhoneId");

            migrationBuilder.CreateIndex(
                name: "IX_UserPhones_UserId",
                table: "UserPhones",
                column: "UserId");
        }
    }
}
