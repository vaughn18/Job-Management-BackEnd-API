using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Job_Management_API.Migrations
{
    public partial class initTableaa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Company",
                columns: table => new
                {
                    companyId = table.Column<Guid>(nullable: false),
                    companyName = table.Column<string>(nullable: true),
                    description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Company", x => x.companyId);
                });

            migrationBuilder.CreateTable(
                name: "Workers",
                columns: table => new
                {
                    workerId = table.Column<Guid>(nullable: false),
                    firstName = table.Column<string>(nullable: true),
                    lastName = table.Column<string>(nullable: true),
                    description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Workers", x => x.workerId);
                });

            migrationBuilder.CreateTable(
                name: "Jobs",
                columns: table => new
                {
                    jobId = table.Column<Guid>(nullable: false),
                    jobName = table.Column<string>(nullable: true),
                    jobStatus = table.Column<bool>(nullable: false),
                    companyId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jobs", x => x.jobId);
                    table.ForeignKey(
                        name: "FK_Jobs_Company_companyId",
                        column: x => x.companyId,
                        principalTable: "Company",
                        principalColumn: "companyId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WorkersJobs",
                columns: table => new
                {
                    workersJobsId = table.Column<Guid>(nullable: false),
                    workerId = table.Column<Guid>(nullable: false),
                    jobId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkersJobs", x => x.workersJobsId);
                    table.ForeignKey(
                        name: "FK_WorkersJobs_Jobs_jobId",
                        column: x => x.jobId,
                        principalTable: "Jobs",
                        principalColumn: "jobId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WorkersJobs_Workers_workerId",
                        column: x => x.workerId,
                        principalTable: "Workers",
                        principalColumn: "workerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Jobs_companyId",
                table: "Jobs",
                column: "companyId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkersJobs_jobId",
                table: "WorkersJobs",
                column: "jobId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkersJobs_workerId",
                table: "WorkersJobs",
                column: "workerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WorkersJobs");

            migrationBuilder.DropTable(
                name: "Jobs");

            migrationBuilder.DropTable(
                name: "Workers");

            migrationBuilder.DropTable(
                name: "Company");
        }
    }
}
