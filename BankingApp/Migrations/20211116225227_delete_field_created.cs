using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BankingApp.Migrations
{
    public partial class delete_field_created : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Created",
                schema: "dbo",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "Created",
                schema: "dbo",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "Created",
                schema: "dbo",
                table: "Accounts");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Created",
                schema: "dbo",
                table: "Accounts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Created",
                schema: "dbo",
                table: "Transactions",
                type: "datetime2",
                nullable: false,
                computedColumnSql: "getdate()");

            migrationBuilder.AddColumn<DateTime>(
                name: "Created",
                schema: "dbo",
                table: "Customers",
                type: "datetime2",
                nullable: false,
                computedColumnSql: "getdate()");
        }
    }
}
