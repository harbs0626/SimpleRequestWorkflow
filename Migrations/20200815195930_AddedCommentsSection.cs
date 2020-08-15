using Microsoft.EntityFrameworkCore.Migrations;

namespace SimpleRequestWorkflow.Migrations
{
    public partial class AddedCommentsSection : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Comments",
                table: "Workflows",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Comments",
                table: "Workflows");
        }
    }
}
