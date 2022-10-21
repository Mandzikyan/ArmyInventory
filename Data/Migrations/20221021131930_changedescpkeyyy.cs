using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class changedescpkeyyy : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameIndex(
                name: "description_barcode_key",
                table: "description",
                newName: "IX_description_barcode");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameIndex(
                name: "IX_description_barcode",
                table: "description",
                newName: "description_barcode_key");
        }
    }
}
