using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class ChangeFkeytoPkey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "Description_fkey",
                table: "description");

            migrationBuilder.AddPrimaryKey(
                name: "description_pkey",
                table: "description",
                column: "categoryname");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "description_pkey",
                table: "description");

            migrationBuilder.AddPrimaryKey(
                name: "Description_fkey",
                table: "description",
                column: "categoryname");
        }
    }
}
