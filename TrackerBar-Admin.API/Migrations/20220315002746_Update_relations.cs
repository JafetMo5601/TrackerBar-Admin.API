using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrackerBar_Admin.API.Migrations
{
    public partial class Update_relations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RestaurantId",
                table: "RestaurantDirection",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RestaurantId",
                table: "RestaurantDirection");
        }
    }
}
