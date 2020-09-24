using Microsoft.EntityFrameworkCore.Migrations;

namespace CIS174_TestCoreApp.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    StudentId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Grade = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.StudentId);
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "StudentId", "FirstName", "Grade", "LastName" },
                values: new object[,]
                {
                    { 1, "Mark", "A", "Johnson" },
                    { 2, "Sam", "B", "Samson" },
                    { 3, "Levi", "C", "Veinkmen" },
                    { 4, "Nancy", "D", "Poole" },
                    { 5, "Rebecca", "F", "Swanson" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Students");
        }
    }
}
