using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Company.Repository.Migrations
{
    public partial class initial5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    CompanyType = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    TaxOffice = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    TaxNumber = table.Column<int>(type: "int", maxLength: 100, nullable: true),
                    Province = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    District = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Address = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    CompanyID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Departments_Companies_CompanyID",
                        column: x => x.CompanyID,
                        principalTable: "Companies",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Subdepartments",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    DepartmentsId = table.Column<int>(type: "int", nullable: false),
                    CompanyId = table.Column<int>(type: "int", nullable: false),
                    CompaniesID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subdepartments", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Subdepartments_Companies_CompaniesID",
                        column: x => x.CompaniesID,
                        principalTable: "Companies",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Subdepartments_Departments_DepartmentsId",
                        column: x => x.DepartmentsId,
                        principalTable: "Departments",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TopDepartments",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    DepartmentsId = table.Column<int>(type: "int", nullable: false),
                    CompanyId = table.Column<int>(type: "int", nullable: false),
                    CompaniesID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TopDepartments", x => x.ID);
                    table.ForeignKey(
                        name: "FK_TopDepartments_Companies_CompaniesID",
                        column: x => x.CompaniesID,
                        principalTable: "Companies",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_TopDepartments_Departments_DepartmentsId",
                        column: x => x.DepartmentsId,
                        principalTable: "Departments",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "ID", "Address", "CompanyType", "District", "Name", "Province", "TaxNumber", "TaxOffice" },
                values: new object[] { 1, "Ataşehir-İstanbul", "Limited", "Ataşehir", "Şirket1", "İstanbul", 111111, "İstanbul Vergi Daiesi" });

            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "ID", "Address", "CompanyType", "District", "Name", "Province", "TaxNumber", "TaxOffice" },
                values: new object[] { 2, "Kartal-İstanbul", "Limited", "Kartal", "Şirket2", "İstanbul", 111122, "Kartal Vergi Daiesi" });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "ID", "CompanyID", "Name" },
                values: new object[] { 1, 1, "Departman1" });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "ID", "CompanyID", "Name" },
                values: new object[] { 2, 2, "Departman2" });

            migrationBuilder.InsertData(
                table: "Subdepartments",
                columns: new[] { "ID", "CompaniesID", "CompanyId", "DepartmentsId", "Name" },
                values: new object[,]
                {
                    { 1, null, 0, 1, "AltD1" },
                    { 2, null, 0, 2, "AltD2" },
                    { 3, null, 0, 1, "AltD3" },
                    { 4, null, 0, 2, "AltD4" }
                });

            migrationBuilder.InsertData(
                table: "TopDepartments",
                columns: new[] { "ID", "CompaniesID", "CompanyId", "DepartmentsId", "Name" },
                values: new object[,]
                {
                    { 1, null, 0, 1, "ÜstD1" },
                    { 2, null, 0, 1, "ÜstD2" },
                    { 3, null, 0, 2, "ÜstD3" },
                    { 4, null, 0, 2, "ÜstD4" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Departments_CompanyID",
                table: "Departments",
                column: "CompanyID");

            migrationBuilder.CreateIndex(
                name: "IX_Subdepartments_CompaniesID",
                table: "Subdepartments",
                column: "CompaniesID");

            migrationBuilder.CreateIndex(
                name: "IX_Subdepartments_DepartmentsId",
                table: "Subdepartments",
                column: "DepartmentsId");

            migrationBuilder.CreateIndex(
                name: "IX_TopDepartments_CompaniesID",
                table: "TopDepartments",
                column: "CompaniesID");

            migrationBuilder.CreateIndex(
                name: "IX_TopDepartments_DepartmentsId",
                table: "TopDepartments",
                column: "DepartmentsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Subdepartments");

            migrationBuilder.DropTable(
                name: "TopDepartments");

            migrationBuilder.DropTable(
                name: "Departments");

            migrationBuilder.DropTable(
                name: "Companies");
        }
    }
}
