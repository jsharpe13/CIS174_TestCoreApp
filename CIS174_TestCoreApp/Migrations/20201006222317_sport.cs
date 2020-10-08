using Microsoft.EntityFrameworkCore.Migrations;

namespace CIS174_TestCoreApp.Migrations
{
    public partial class sport : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SportCategories",
                columns: table => new
                {
                    CategoryId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SportCategories", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "SportGames",
                columns: table => new
                {
                    GameId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SportGames", x => x.GameId);
                });

            migrationBuilder.CreateTable(
                name: "SportTypes",
                columns: table => new
                {
                    SportTypeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    CategoryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SportTypes", x => x.SportTypeId);
                    table.ForeignKey(
                        name: "FK_SportTypes_SportCategories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "SportCategories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SportCountries",
                columns: table => new
                {
                    CountryId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    GameId = table.Column<int>(nullable: false),
                    SportTypeId = table.Column<int>(nullable: false),
                    LogoImage = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SportCountries", x => x.CountryId);
                    table.ForeignKey(
                        name: "FK_SportCountries_SportGames_GameId",
                        column: x => x.GameId,
                        principalTable: "SportGames",
                        principalColumn: "GameId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SportCountries_SportTypes_SportTypeId",
                        column: x => x.SportTypeId,
                        principalTable: "SportTypes",
                        principalColumn: "SportTypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "SportCategories",
                columns: new[] { "CategoryId", "Name" },
                values: new object[,]
                {
                    { 1, "Indoor" },
                    { 2, "Outdoor" }
                });

            migrationBuilder.InsertData(
                table: "SportGames",
                columns: new[] { "GameId", "Name" },
                values: new object[,]
                {
                    { 1, "Winter Olympics" },
                    { 2, "Summer Olympics" },
                    { 3, "Paralympics" },
                    { 4, "Youth Olympic Games" }
                });

            migrationBuilder.InsertData(
                table: "SportTypes",
                columns: new[] { "SportTypeId", "CategoryId", "Name" },
                values: new object[,]
                {
                    { 1, 1, "Curling" },
                    { 3, 1, "Diving" },
                    { 5, 1, "Archery" },
                    { 7, 1, "Breakdancing" },
                    { 2, 2, "Bobsleigh" },
                    { 4, 2, " Road Cycling" },
                    { 6, 2, "Canoe Sprint" },
                    { 8, 2, "Skateboarding" }
                });

            migrationBuilder.InsertData(
                table: "SportCountries",
                columns: new[] { "CountryId", "GameId", "LogoImage", "Name", "SportTypeId" },
                values: new object[,]
                {
                    { 1, 1, "canadaflag.png", "Canada", 1 },
                    { 22, 4, "finlandflag.png", "Finland", 8 },
                    { 18, 3, "zimbabweflag.png", "Zimbabwe", 6 },
                    { 17, 3, "pakistanflag.png", "Pakistan", 6 },
                    { 16, 3, "austriaflag.png", "Austria", 6 },
                    { 12, 2, "usaflag.png", "USA", 4 },
                    { 11, 2, "netherlandsflag.png", "Netherlands", 4 },
                    { 10, 2, "brazilflag.png", "Brazil", 4 },
                    { 6, 1, "japanflag.png", "Japan", 2 },
                    { 5, 1, "italyflag.png", "Italy", 2 },
                    { 4, 1, "jamaicaflag.png", "Jamaica", 2 },
                    { 21, 4, "russiaflag.png", "Russia", 7 },
                    { 20, 4, "cyprusflag.png", "Cyprus", 7 },
                    { 19, 4, "franceflag.png", "France", 7 },
                    { 15, 3, "ukraineflag.png", "Ukraine", 5 },
                    { 14, 3, "uruguayflag.png", "Uruguay", 5 },
                    { 13, 3, "thailandflag.png", "Thailand", 5 },
                    { 9, 2, "mexicoflag.png", "Mexico", 3 },
                    { 8, 2, "chinaflag.png", "China", 3 },
                    { 7, 2, "germanyflag.png", "Germany", 3 },
                    { 3, 1, "britainflag.png", "Great Britain", 1 },
                    { 2, 1, "swedenflag.png", "Sweden", 1 },
                    { 23, 4, "slovakiaflag.png", "Slovakia", 8 },
                    { 24, 4, "portugalflag.png", "Portugal", 8 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_SportCountries_GameId",
                table: "SportCountries",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_SportCountries_SportTypeId",
                table: "SportCountries",
                column: "SportTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_SportTypes_CategoryId",
                table: "SportTypes",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SportCountries");

            migrationBuilder.DropTable(
                name: "SportGames");

            migrationBuilder.DropTable(
                name: "SportTypes");

            migrationBuilder.DropTable(
                name: "SportCategories");
        }
    }
}
