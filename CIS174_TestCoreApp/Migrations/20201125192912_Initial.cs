using Microsoft.EntityFrameworkCore.Migrations;

namespace CIS174_TestCoreApp.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SportCategories",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SportCategories", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "SportGames",
                columns: table => new
                {
                    GameId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SportGames", x => x.GameId);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    StudentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Grade = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.StudentId);
                });

            migrationBuilder.CreateTable(
                name: "TicketingPointValues",
                columns: table => new
                {
                    pointValueId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    orderNum = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TicketingPointValues", x => x.pointValueId);
                });

            migrationBuilder.CreateTable(
                name: "TicketingStatuses",
                columns: table => new
                {
                    StatusId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TicketingStatuses", x => x.StatusId);
                });

            migrationBuilder.CreateTable(
                name: "SportTypes",
                columns: table => new
                {
                    SportTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
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
                name: "Ticketings",
                columns: table => new
                {
                    SprintNumberId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    pointValueId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    StatusId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ticketings", x => x.SprintNumberId);
                    table.ForeignKey(
                        name: "FK_Ticketings_TicketingPointValues_pointValueId",
                        column: x => x.pointValueId,
                        principalTable: "TicketingPointValues",
                        principalColumn: "pointValueId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ticketings_TicketingStatuses_StatusId",
                        column: x => x.StatusId,
                        principalTable: "TicketingStatuses",
                        principalColumn: "StatusId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SportCountries",
                columns: table => new
                {
                    CountryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GameId = table.Column<int>(type: "int", nullable: false),
                    SportTypeId = table.Column<int>(type: "int", nullable: false),
                    LogoImage = table.Column<string>(type: "nvarchar(max)", nullable: false)
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
                table: "Students",
                columns: new[] { "StudentId", "FirstName", "Grade", "LastName" },
                values: new object[,]
                {
                    { 4, "Nancy", "D", "Poole" },
                    { 3, "Levi", "C", "Veinkmen" },
                    { 5, "Rebecca", "F", "Swanson" },
                    { 1, "Mark", "A", "Johnson" },
                    { 2, "Sam", "B", "Samson" }
                });

            migrationBuilder.InsertData(
                table: "TicketingPointValues",
                columns: new[] { "pointValueId", "Name", "orderNum" },
                values: new object[,]
                {
                    { "one", "1", 1 },
                    { "two", "2", 2 },
                    { "three", "3", 3 },
                    { "five", "5", 4 },
                    { "eight", "8", 5 },
                    { "thirteen", "13", 6 },
                    { "twenty-one", "21", 7 }
                });

            migrationBuilder.InsertData(
                table: "TicketingStatuses",
                columns: new[] { "StatusId", "Name" },
                values: new object[,]
                {
                    { "quality", "Quality Assurance" },
                    { "todo", "To Do" },
                    { "progress", "In Progress" },
                    { "done", "Done" }
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
                table: "Ticketings",
                columns: new[] { "SprintNumberId", "Description", "Name", "StatusId", "pointValueId" },
                values: new object[,]
                {
                    { 3, "Switch to completely new Computer system", "Swap Computer Systems", "progress", "eight" },
                    { 2, "Look File over for errors", "Look File Over", "quality", "three" },
                    { 1, "Switch project files", "File Switch", "done", "one" },
                    { 4, "get coffee for group", "Get Coffeee", "done", "one" }
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

            migrationBuilder.CreateIndex(
                name: "IX_Ticketings_pointValueId",
                table: "Ticketings",
                column: "pointValueId");

            migrationBuilder.CreateIndex(
                name: "IX_Ticketings_StatusId",
                table: "Ticketings",
                column: "StatusId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SportCountries");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Ticketings");

            migrationBuilder.DropTable(
                name: "SportGames");

            migrationBuilder.DropTable(
                name: "SportTypes");

            migrationBuilder.DropTable(
                name: "TicketingPointValues");

            migrationBuilder.DropTable(
                name: "TicketingStatuses");

            migrationBuilder.DropTable(
                name: "SportCategories");
        }
    }
}
