using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace POS.Migrations
{
    /// <inheritdoc />
    public partial class Addnew2Item : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_SubCatagory_SubCatagoryId",
                table: "Items");

            migrationBuilder.DropForeignKey(
                name: "FK_SubCatagory_SalesMaster_CatagorycatId",
                table: "SubCatagory");

            migrationBuilder.DropIndex(
                name: "IX_SubCatagory_CatagorycatId",
                table: "SubCatagory");

            migrationBuilder.DropIndex(
                name: "IX_Items_SubCatagoryId",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "CatagorycatId",
                table: "SubCatagory");

            migrationBuilder.DropColumn(
                name: "SubCatagoryId",
                table: "Items");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CatagorycatId",
                table: "SubCatagory",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SubCatagoryId",
                table: "Items",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SubCatagory_CatagorycatId",
                table: "SubCatagory",
                column: "CatagorycatId");

            migrationBuilder.CreateIndex(
                name: "IX_Items_SubCatagoryId",
                table: "Items",
                column: "SubCatagoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Items_SubCatagory_SubCatagoryId",
                table: "Items",
                column: "SubCatagoryId",
                principalTable: "SubCatagory",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SubCatagory_SalesMaster_CatagorycatId",
                table: "SubCatagory",
                column: "CatagorycatId",
                principalTable: "SalesMaster",
                principalColumn: "catId");
        }
    }
}
