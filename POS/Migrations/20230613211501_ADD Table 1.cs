using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace POS.Migrations
{
    /// <inheritdoc />
    public partial class ADDTable1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "OrderType",
                table: "Sales",
                newName: "CustomerName");

            migrationBuilder.RenameColumn(
                name: "OrderNumber",
                table: "Sales",
                newName: "SalesNumber");

            migrationBuilder.AddColumn<DateOnly>(
                name: "SalesDate",
                table: "Sales",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.AddColumn<bool>(
                name: "Status",
                table: "Sales",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<double>(
                name: "Tax",
                table: "Sales",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SalesDate",
                table: "Sales");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Sales");

            migrationBuilder.DropColumn(
                name: "Tax",
                table: "Sales");

            migrationBuilder.RenameColumn(
                name: "SalesNumber",
                table: "Sales",
                newName: "OrderNumber");

            migrationBuilder.RenameColumn(
                name: "CustomerName",
                table: "Sales",
                newName: "OrderType");
        }
    }
}
