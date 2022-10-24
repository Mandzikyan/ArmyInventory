using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class Changedesckey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddPrimaryKey(
                name: "Description_pkey",
                table: "description",
                column: "barcode");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "Description_pkey",
                table: "description");
        }
    }
}
