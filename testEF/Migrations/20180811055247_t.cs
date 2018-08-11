using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace testEF.Migrations
{
    public partial class t : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DEPARTMENT",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DEPARTMENT", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DEPARTMENT_2",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DEPARTMENT_2", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DOCTORS",
                columns: table => new
                {
                    DOCTOR_ID = table.Column<int>(nullable: false),
                    NAME = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DOCTORS", x => x.DOCTOR_ID);
                });

            migrationBuilder.CreateTable(
                name: "EMPLOYEE",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NAME = table.Column<string>(maxLength: 50, nullable: true),
                    Num = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EMPLOYEE", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "PATIENTS",
                columns: table => new
                {
                    PATIENT_ID = table.Column<int>(nullable: false),
                    NAME = table.Column<string>(maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PATIENTS", x => x.PATIENT_ID);
                });

            migrationBuilder.CreateTable(
                name: "TEST",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TEST", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EMPLOYEE_2",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: true),
                    Department_Id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EMPLOYEE_2", x => x.Id);
                    table.ForeignKey(
                        name: "EMPLOYEE_2_DEPARTMENT_2_Id_fk",
                        column: x => x.Department_Id,
                        principalTable: "DEPARTMENT_2",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MAP_DOCTORS_PAIENTS",
                columns: table => new
                {
                    DOCTOR_ID = table.Column<int>(nullable: false),
                    PATIENT_ID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MAP_DOCTORS_PAIENTS", x => new { x.DOCTOR_ID, x.PATIENT_ID });
                    table.ForeignKey(
                        name: "FK_MAP_DOCTORS_PAIENTS_DOCTOR",
                        column: x => x.DOCTOR_ID,
                        principalTable: "DOCTORS",
                        principalColumn: "DOCTOR_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MAP_DOCTORS_PAIENTS_PATIENT",
                        column: x => x.PATIENT_ID,
                        principalTable: "PATIENTS",
                        principalColumn: "PATIENT_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EMPLOYEE_2_Department_Id",
                table: "EMPLOYEE_2",
                column: "Department_Id");

            migrationBuilder.CreateIndex(
                name: "IX_MAP_DOCTORS_PAIENTS_PATIENT_ID",
                table: "MAP_DOCTORS_PAIENTS",
                column: "PATIENT_ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DEPARTMENT");

            migrationBuilder.DropTable(
                name: "EMPLOYEE");

            migrationBuilder.DropTable(
                name: "EMPLOYEE_2");

            migrationBuilder.DropTable(
                name: "MAP_DOCTORS_PAIENTS");

            migrationBuilder.DropTable(
                name: "TEST");

            migrationBuilder.DropTable(
                name: "DEPARTMENT_2");

            migrationBuilder.DropTable(
                name: "DOCTORS");

            migrationBuilder.DropTable(
                name: "PATIENTS");
        }
    }
}
