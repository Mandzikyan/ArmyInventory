using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class changedescpkey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "description_pkey",
                table: "description");

            migrationBuilder.RenameIndex(
                name: "description_barcode_key",
                table: "description",
                newName: "IX_description_barcode");

            migrationBuilder.AddPrimaryKey(
                name: "description_fkey",
                table: "description",
                column: "categoryname");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "description_fkey",
                table: "description");

            migrationBuilder.RenameIndex(
                name: "IX_description_barcode",
                table: "description",
                newName: "description_barcode_key");

            migrationBuilder.AddPrimaryKey(
                name: "description_pkey",
                table: "description",
                column: "categoryname");
        }
    }
}
