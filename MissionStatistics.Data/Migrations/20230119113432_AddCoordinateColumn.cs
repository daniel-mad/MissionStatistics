using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MissionStatistics.Data.Migrations
{
    public partial class AddCoordinateColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Lat",
                table: "Missions",
                type: "REAL",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Lon",
                table: "Missions",
                type: "REAL",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Lat",
                table: "Missions");

            migrationBuilder.DropColumn(
                name: "Lon",
                table: "Missions");
        }
    }
}
