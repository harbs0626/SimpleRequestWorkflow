using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SimpleRequestWorkflow.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Workflows",
                columns: table => new
                {
                    WorkflowId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(nullable: false),
                    Requestor = table.Column<string>(nullable: false),
                    TransactionType = table.Column<string>(nullable: false),
                    TransactionAmount = table.Column<double>(nullable: false),
                    Remarks = table.Column<string>(nullable: false),
                    RequestStatus = table.Column<string>(nullable: true),
                    RequestedBy = table.Column<string>(nullable: false),
                    RequestedDateTime = table.Column<DateTime>(nullable: false),
                    ProcessedBy = table.Column<string>(nullable: true),
                    ProcessedDateTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Workflows", x => x.WorkflowId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Workflows");
        }
    }
}
