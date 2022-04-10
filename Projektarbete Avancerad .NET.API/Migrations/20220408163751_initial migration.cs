using Microsoft.EntityFrameworkCore.Migrations;

namespace Projektarbete_Avancerad_.NET.API.Migrations
{
    public partial class initialmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    ProjectID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.ProjectID);
                });

            migrationBuilder.CreateTable(
                name: "TimeReports",
                columns: table => new
                {
                    TimeReportID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HoursWorked = table.Column<int>(nullable: false),
                    Week = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimeReports", x => x.TimeReportID);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    EmployeeID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    ProjectID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.EmployeeID);
                    table.ForeignKey(
                        name: "FK_Employees_Projects_ProjectID",
                        column: x => x.ProjectID,
                        principalTable: "Projects",
                        principalColumn: "ProjectID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TimeRepEmployees",
                columns: table => new
                {
                    TimeRepEmployeeID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TimeReportID = table.Column<int>(nullable: false),
                    EmployeeID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimeRepEmployees", x => x.TimeRepEmployeeID);
                    table.ForeignKey(
                        name: "FK_TimeRepEmployees_Employees_EmployeeID",
                        column: x => x.EmployeeID,
                        principalTable: "Employees",
                        principalColumn: "EmployeeID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TimeRepEmployees_TimeReports_TimeReportID",
                        column: x => x.TimeReportID,
                        principalTable: "TimeReports",
                        principalColumn: "TimeReportID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "ProjectID", "ProjectName" },
                values: new object[,]
                {
                    { 1, "New Website" },
                    { 2, "Car building" },
                    { 3, "Sleep and eat" }
                });

            migrationBuilder.InsertData(
                table: "TimeReports",
                columns: new[] { "TimeReportID", "HoursWorked", "Week" },
                values: new object[,]
                {
                    { 1, 35, 23 },
                    { 2, 43, 23 },
                    { 3, 25, 23 },
                    { 4, 12, 24 },
                    { 5, 80, 24 },
                    { 6, 22, 24 },
                    { 7, 2, 25 },
                    { 8, 333, 25 }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmployeeID", "Email", "FirstName", "LastName", "Phone", "ProjectID" },
                values: new object[,]
                {
                    { 1, "jack@jack.com", "Jack", "Niklasson", "0750030030", 1 },
                    { 3, "timmo@timmo.com", "Timothy", "Borgäng", "0782221121", 1 },
                    { 2, "emma@emma.com", "Emma", "Whiteside", "0788484884", 2 },
                    { 4, "alice@alice.com", "Alice", "Höök", "0789989899", 3 },
                    { 5, "jonathan@jonthan.com", "Jonathan", "Björck", "0742421133", 3 }
                });

            migrationBuilder.InsertData(
                table: "TimeRepEmployees",
                columns: new[] { "TimeRepEmployeeID", "EmployeeID", "TimeReportID" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 1, 2 },
                    { 4, 3, 4 },
                    { 3, 2, 3 },
                    { 5, 4, 5 },
                    { 6, 4, 6 },
                    { 7, 5, 7 },
                    { 8, 5, 8 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employees_ProjectID",
                table: "Employees",
                column: "ProjectID");

            migrationBuilder.CreateIndex(
                name: "IX_TimeRepEmployees_EmployeeID",
                table: "TimeRepEmployees",
                column: "EmployeeID");

            migrationBuilder.CreateIndex(
                name: "IX_TimeRepEmployees_TimeReportID",
                table: "TimeRepEmployees",
                column: "TimeReportID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TimeRepEmployees");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "TimeReports");

            migrationBuilder.DropTable(
                name: "Projects");
        }
    }
}
