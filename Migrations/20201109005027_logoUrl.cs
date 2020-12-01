using Microsoft.EntityFrameworkCore.Migrations;

namespace Job_Management_API.Migrations
{
    public partial class logoUrl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "logoUrl",
                table: "Company",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "logoUrl",
                table: "Company");
        }
    }
}
