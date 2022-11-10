using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MissionStatistics.Data.Migrations
{
    public partial class SeedindDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Missions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Agent = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Country = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Address = table.Column<string>(type: "TEXT", maxLength: 150, nullable: false),
                    Date = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Missions", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Missions",
                columns: new[] { "Id", "Address", "Agent", "Country", "Date" },
                values: new object[] { 1, "Avenida Vieira Souto 168 Ipanema, Rio de Janeiro'", "007", "Brazil", new DateTime(1995, 12, 17, 21, 45, 17, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Missions",
                columns: new[] { "Id", "Address", "Agent", "Country", "Date" },
                values: new object[] { 2, "Rynek Glowny 12, Krakow", "005", "Poland", new DateTime(2011, 4, 5, 17, 5, 12, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Missions",
                columns: new[] { "Id", "Address", "Agent", "Country", "Date" },
                values: new object[] { 3, "27 Derb Lferrane, Marrakech'", "007", "Morocco", new DateTime(2001, 1, 1, 12, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Missions",
                columns: new[] { "Id", "Address", "Agent", "Country", "Date" },
                values: new object[] { 4, "Rua Roberto Simonsen 122, Sao Paulo", "005", "Brazil", new DateTime(1986, 5, 5, 8, 40, 23, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Missions",
                columns: new[] { "Id", "Address", "Agent", "Country", "Date" },
                values: new object[] { 5, "swietego Tomasza 35, Krakow'", "011", "Poland", new DateTime(1997, 9, 7, 19, 12, 53, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Missions",
                columns: new[] { "Id", "Address", "Agent", "Country", "Date" },
                values: new object[] { 6, "Rue Al-Aidi Ali Al-Maaroufi, Casablanca", "003", "Morocco", new DateTime(2012, 8, 29, 10, 17, 5, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Missions",
                columns: new[] { "Id", "Address", "Agent", "Country", "Date" },
                values: new object[] { 7, "Rua tamoana 418, tefe", "008", "Brazil", new DateTime(2005, 11, 10, 13, 25, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Missions",
                columns: new[] { "Id", "Address", "Agent", "Country", "Date" },
                values: new object[] { 8, "Zlota 9, Lublin'", "013", "Poland", new DateTime(2002, 10, 17, 10, 52, 19, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Missions",
                columns: new[] { "Id", "Address", "Agent", "Country", "Date" },
                values: new object[] { 9, "Riad Sultan 19, Tangier'", "002", "Morocco", new DateTime(2017, 1, 1, 17, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Missions",
                columns: new[] { "Id", "Address", "Agent", "Country", "Date" },
                values: new object[] { 10, "atlas marina beach, agadir", "009", "Morocco", new DateTime(2016, 12, 1, 21, 21, 21, 0, DateTimeKind.Unspecified) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Missions");
        }
    }
}
