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

            migrationBuilder.CreateTable(
                name: "FishTime",
                columns: table => new
                {
                    FishTimeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FishSpeciesId = table.Column<int>(type: "int", nullable: false),
                    BestTimes = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FishTime", x => x.FishTimeId);
                    table.ForeignKey(
                        name: "FK_FishTime_FishSpecies_FishSpeciesId",
                        column: x => x.FishSpeciesId,
                        principalTable: "FishSpecies",
                        principalColumn: "FishSpeciesId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FishWeather",
                columns: table => new
                {
                    FishWeatherId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FishSpeciesId = table.Column<int>(type: "int", nullable: false),
                    BestWeathers = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FishWeather", x => x.FishWeatherId);
                    table.ForeignKey(
                        name: "FK_FishWeather_FishSpecies_FishSpeciesId",
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
                    { 2, "Smallmouth Bass", "Ponds, Lakes, Creeks, Rivers", "Micropterus dolomieu", "27 inches", "11 Pounds 15 Ounces" },
                    { 3, "Northern Pike", "Ponds, Lakes, Creeks, Rivers", "Esox lucius", "52 Inches", "55 Pounds" },
                    { 4, "Lake Trout", "Lakes", "Salvelinus namaycush", "47 Inches", "73 Pounds 29 Ounces" },
                    { 5, "Walleye", "Lakes & Rivers", "Sander vitreus", "41 Inches", "25 Pounds" },
                    { 6, "Steelhead", "Lakes & Rivers", "Oncorhynchus mykiss", "45 Inches", "40 Pounds" },
                    { 7, "Musky", "Lakes & Rivers", "Esox masquinongy", "72 Inches", "70 Pounds" },
                    { 8, "King Salmon", "Lakes & Rivers", "Oncorhynchus tshawytscha", "58 Inches", "126 Pounds" }
                });

            migrationBuilder.InsertData(
                table: "FishLure",
                columns: new[] { "FishLureId", "FishLureName", "FishSpeciesId" },
                values: new object[,]
                {
                    { 1, "Fake Worms, Jigs, Topwater Lures, Paddletail Swimbaits", 1 },
                    { 2, "Tubes, Jigs, Topwater Lures, Paddletail Swimbaits", 2 },
                    { 3, "Spoons, Crankbaits, Jerkbaits, Large Soft Swimbaits", 3 },
                    { 4, "Spoons & Tubes", 4 },
                    { 5, "Crankbaits & Jigs", 5 },
                    { 6, "Spoons, Imitation Eggs, & Spinners", 6 },
                    { 7, "Spoons, Crankbaits, Jerkbaits, Large Soft Swimbaits", 7 },
                    { 8, "Spoons, Imitation Eggs, & Spinners", 8 }
                });

            migrationBuilder.InsertData(
                table: "FishTime",
                columns: new[] { "FishTimeId", "BestTimes", "FishSpeciesId" },
                values: new object[,]
                {
                    { 1, "Dawn & Dusk", 1 },
                    { 2, "Dawn & Dusk", 2 },
                    { 3, "Dawn & Dusk", 3 },
                    { 4, "Dawn & Dusk", 4 },
                    { 5, "Dawn, Dusk, & Night", 5 },
                    { 6, "Dawn & Dusk", 6 },
                    { 7, "Dawn & Dusk", 7 },
                    { 8, "Dawn & Dusk", 8 }
                });

            migrationBuilder.InsertData(
                table: "FishWeather",
                columns: new[] { "FishWeatherId", "BestWeathers", "FishSpeciesId" },
                values: new object[,]
                {
                    { 1, "Cloudy & warmer weather", 1 },
                    { 2, "Cloudy & cooler weather", 2 },
                    { 3, "Cloudy & cooler weather", 3 },
                    { 4, "Cloudy & very cold weather", 4 },
                    { 5, "Cloudy & cooler weather", 5 },
                    { 6, "Cloudy & very cold weather", 6 },
                    { 7, "Cloudy & cooler weather", 7 },
                    { 8, "Cloudy & very cold weather", 8 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_FishLure_FishSpeciesId",
                table: "FishLure",
                column: "FishSpeciesId");

            migrationBuilder.CreateIndex(
                name: "IX_FishTime_FishSpeciesId",
                table: "FishTime",
                column: "FishSpeciesId");

            migrationBuilder.CreateIndex(
                name: "IX_FishWeather_FishSpeciesId",
                table: "FishWeather",
                column: "FishSpeciesId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FishList");

            migrationBuilder.DropTable(
                name: "FishLure");

            migrationBuilder.DropTable(
                name: "FishTime");

            migrationBuilder.DropTable(
                name: "FishWeather");

            migrationBuilder.DropTable(
                name: "FishSpecies");
        }
    }
}
