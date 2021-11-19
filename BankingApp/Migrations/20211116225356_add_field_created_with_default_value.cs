using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BankingApp.Migrations
{
    public partial class add_field_created_with_default_value : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Created",
                schema: "dbo",
                table: "Transactions",
                type: "datetime2",
                nullable: true,
                defaultValueSql: "getdate()");

            migrationBuilder.AddColumn<DateTime>(
                name: "Created",
                schema: "dbo",
                table: "Customers",
                type: "datetime2",
                nullable: true,
                defaultValueSql: "getdate()");

            migrationBuilder.AddColumn<DateTime>(
                name: "Created",
                schema: "dbo",
                table: "Accounts",
                type: "datetime2",
                nullable: true,
                defaultValueSql: "getdate()");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
    }
}
