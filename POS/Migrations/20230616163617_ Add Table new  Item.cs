using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace POS.Migrations
{
    /// <inheritdoc />
    public partial class AddTablenewItem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CatagoryId",
                table: "SubCatagory",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ItemId",
                table: "SubCatagory",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SubCatagoryId",
                table: "Items",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SubCatagoryId",
                table: "Catagory",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_SubCatagory_CatagoryId",
                table: "SubCatagory",
                column: "CatagoryId");

            migrationBuilder.CreateIndex(
                name: "IX_SubCatagory_ItemId",
                table: "SubCatagory",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Items_SubCatagoryId",
                table: "Items",
                column: "SubCatagoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Catagory_SubCatagoryId",
                table: "Catagory",
                column: "SubCatagoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Catagory_SubCatagory_SubCatagoryId",
                table: "Catagory",
                column: "SubCatagoryId",
                principalTable: "SubCatagory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Items_SubCatagory_SubCatagoryId",
                table: "Items",
                column: "SubCatagoryId",
                principalTable: "SubCatagory",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SubCatagory_Catagory_CatagoryId",
                table: "SubCatagory",
                column: "CatagoryId",
                principalTable: "Catagory",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SubCatagory_Items_ItemId",
                table: "SubCatagory",
                column: "ItemId",
                principalTable: "Items",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Catagory_SubCatagory_SubCatagoryId",
                table: "Catagory");

            migrationBuilder.DropForeignKey(
                name: "FK_Items_SubCatagory_SubCatagoryId",
                table: "Items");

            migrationBuilder.DropForeignKey(
                name: "FK_SubCatagory_Catagory_CatagoryId",
                table: "SubCatagory");

            migrationBuilder.DropForeignKey(
                name: "FK_SubCatagory_Items_ItemId",
                table: "SubCatagory");

            migrationBuilder.DropIndex(
                name: "IX_SubCatagory_CatagoryId",
                table: "SubCatagory");

            migrationBuilder.DropIndex(
                name: "IX_SubCatagory_ItemId",
                table: "SubCatagory");

            migrationBuilder.DropIndex(
                name: "IX_Items_SubCatagoryId",
                table: "Items");

            migrationBuilder.DropIndex(
                name: "IX_Catagory_SubCatagoryId",
                table: "Catagory");

            migrationBuilder.DropColumn(
                name: "CatagoryId",
                table: "SubCatagory");

            migrationBuilder.DropColumn(
                name: "ItemId",
                table: "SubCatagory");

            migrationBuilder.DropColumn(
                name: "SubCatagoryId",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "SubCatagoryId",
                table: "Catagory");
        }
    }
}
