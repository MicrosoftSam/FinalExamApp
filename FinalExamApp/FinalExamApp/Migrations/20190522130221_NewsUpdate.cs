using Microsoft.EntityFrameworkCore.Migrations;

namespace FinalExamApp.Migrations
{
    public partial class NewsUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "NewsName",
                table: "News",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NewsName",
                table: "News");
        }
    }
}
