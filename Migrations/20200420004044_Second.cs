using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SimpleRequestWorkflow.Migrations
{
    public partial class Second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "RequestedBy",
                table: "Workflows",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.CreateTable(
                name: "TransactionTypes",
                columns: table => new
                {
                    TransactionTypeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(nullable: true),
                    Code = table.Column<string>(nullable: true),
                    MinimumLimit = table.Column<decimal>(nullable: false),
                    MaximumLimit = table.Column<decimal>(nullable: false),
                    AddedBy = table.Column<string>(nullable: true),
                    AddedDateTime = table.Column<DateTime>(nullable: false),
                    ModifiedBy = table.Column<string>(nullable: true),
                    ModifiedDateTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransactionTypes", x => x.TransactionTypeId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TransactionTypes");

            migrationBuilder.AlterColumn<string>(
                name: "RequestedBy",
                table: "Workflows",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
