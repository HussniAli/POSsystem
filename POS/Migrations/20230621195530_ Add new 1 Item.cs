using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace POS.Migrations
{
    /// <inheritdoc />
    public partial class Addnew1Item : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Catagory_SubCatagory_SubCatagoryId",
                table: "Catagory");

            migrationBuilder.DropForeignKey(
                name: "FK_SubCatagory_Catagory_CatagoryId",
                table: "SubCatagory");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Catagory",
                table: "Catagory");

            migrationBuilder.RenameTable(
                name: "Catagory",
                newName: "SalesMaster");

            migrationBuilder.RenameColumn(
                name: "CatagoryId",
                table: "SubCatagory",
                newName: "CatagorycatId");

            migrationBuilder.RenameIndex(
                name: "IX_SubCatagory_CatagoryId",
                table: "SubCatagory",
                newName: "IX_SubCatagory_CatagorycatId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "SalesMaster",
                newName: "catId");

            migrationBuilder.RenameIndex(
                name: "IX_Catagory_SubCatagoryId",
                table: "SalesMaster",
                newName: "IX_SalesMaster_SubCatagoryId");

            migrationBuilder.AlterColumn<int>(
                name: "catId",
                table: "SalesMaster",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .Annotation("Relational:ColumnOrder", 0)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_SalesMaster",
                table: "SalesMaster",
                column: "catId");

            migrationBuilder.AddForeignKey(
                name: "FK_SalesMaster_SubCatagory_SubCatagoryId",
                table: "SalesMaster",
                column: "SubCatagoryId",
                principalTable: "SubCatagory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SubCatagory_SalesMaster_CatagorycatId",
                table: "SubCatagory",
                column: "CatagorycatId",
                principalTable: "SalesMaster",
                principalColumn: "catId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SalesMaster_SubCatagory_SubCatagoryId",
                table: "SalesMaster");

            migrationBuilder.DropForeignKey(
                name: "FK_SubCatagory_SalesMaster_CatagorycatId",
                table: "SubCatagory");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SalesMaster",
                table: "SalesMaster");

            migrationBuilder.RenameTable(
                name: "SalesMaster",
                newName: "Catagory");

            migrationBuilder.RenameColumn(
                name: "CatagorycatId",
                table: "SubCatagory",
                newName: "CatagoryId");

            migrationBuilder.RenameIndex(
                name: "IX_SubCatagory_CatagorycatId",
                table: "SubCatagory",
                newName: "IX_SubCatagory_CatagoryId");

            migrationBuilder.RenameColumn(
                name: "catId",
                table: "Catagory",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_SalesMaster_SubCatagoryId",
                table: "Catagory",
                newName: "IX_Catagory_SubCatagoryId");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Catagory",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .OldAnnotation("Relational:ColumnOrder", 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Catagory",
                table: "Catagory",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Catagory_SubCatagory_SubCatagoryId",
                table: "Catagory",
                column: "SubCatagoryId",
                principalTable: "SubCatagory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SubCatagory_Catagory_CatagoryId",
                table: "SubCatagory",
                column: "CatagoryId",
                principalTable: "Catagory",
                principalColumn: "Id");
        }
    }
}
