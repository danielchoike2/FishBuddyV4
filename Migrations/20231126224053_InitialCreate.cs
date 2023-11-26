using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FishBuddy.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FishList",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FishName = table.Column<string>(name: "Fish Name", type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Location = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    MaxLength = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Weight = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FishList", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "FishSpecies",
                columns: table => new
                {
                    FishSpeciesId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FishCommonName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FishSpeciesName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FishHabitat = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RecordWeight = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RecordLength = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FishSpecies", x => x.FishSpeciesId);
                });

            migrationBuilder.CreateTable(
                name: "FishLure",
                columns: table => new
                {
                    FishLureId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FishSpeciesId = table.Column<int>(type: "int", nullable: false),
                    FishLureName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FishLure", x => x.FishLureId);
                    table.ForeignKey(
                        name: "FK_FishLure_FishSpecies_FishSpeciesId",
                        column: x => x.FishSpeciesId,
                        principalTable: "FishSpecies",
                        principalColumn: "FishSpeciesId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "FishList",
                columns: new[] { "ID", "Date", "Fish Name", "Location", "MaxLength", "Weight" },
                values: new object[,]
                {
                    { 1, null, "Largemouth Bass", "Ransom Lake", "27 Inches", "11.94 Pounds" },
                    { 2, null, "Northern Pike", "Bronson Lake", "51.5 Inches", "39 Pounds" },
                    { 3, null, "Walleye", "Long Lake", "35 Inches", "17.19 Pounds" }
                });

            migrationBuilder.InsertData(
                table: "FishSpecies",
                columns: new[] { "FishSpeciesId", "FishCommonName", "FishHabitat", "FishSpeciesName", "RecordLength", "RecordWeight" },
                values: new object[,]
                {
                    { 1, "Largemouth Bass", "Ponds, Swamps, Lakes, Creeks, Rivers", "Micropterus salmoides", "25.59 inches", "22 Pounds 4 Ounces" },
                    { 2, "Smallmouth Bass", "Ponds, Lakes, Creeks, Rivers", "Micropterus salmoides", "27 inches", "11 Pounds 15 Ounces" },
                    { 3, "Northern Pike", "Ponds, Lakes, Creeks, Rivers", "Esox lucius", "52 Inches", "55 Pounds" },
                    { 4, "Lake Trout", "Lakes", "Salvelinus namaycush", "47 Inches", "73 Pounds 29 Ounces" }
                });

            migrationBuilder.InsertData(
                table: "FishLure",
                columns: new[] { "FishLureId", "FishLureName", "FishSpeciesId" },
                values: new object[,]
                {
                    { 1, "Fake Worms, Jigs, Topwater Lures, Paddletail Swimbaits", 1 },
                    { 2, "Tubes, Jigs, Topwater Lures, Paddletail Swimbaits", 2 },
                    { 3, "Spoons, Crankbaits, Jerkbaits, Large Soft Swimbaits", 3 },
                    { 4, "Spoons & Tubes", 4 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_FishLure_FishSpeciesId",
                table: "FishLure",
                column: "FishSpeciesId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FishList");

            migrationBuilder.DropTable(
                name: "FishLure");

            migrationBuilder.DropTable(
                name: "FishSpecies");
        }
    }
}
