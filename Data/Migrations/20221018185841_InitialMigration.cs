using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Data.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "category",
                columns: table => new
                {
                    categoryname = table.Column<string>(type: "character varying", nullable: false),
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("category_pkey", x => x.categoryname);
                });

            migrationBuilder.CreateTable(
                name: "description",
                columns: table => new
                {
                    categoryname = table.Column<string>(type: "character varying", nullable: false),
                    barcode = table.Column<string>(type: "character varying", nullable: false),
                    distance = table.Column<decimal>(type: "numeric", nullable: true),
                    weight = table.Column<decimal>(type: "numeric", nullable: false),
                    capacity = table.Column<int>(type: "integer", nullable: true),
                    price = table.Column<decimal>(type: "numeric", nullable: false),
                    name = table.Column<string>(type: "character varying", nullable: false),
                    quantity = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Description_fkey", x => x.categoryname);
                    table.ForeignKey(
                        name: "description_categoryname_fkey",
                        column: x => x.categoryname,
                        principalTable: "category",
                        principalColumn: "categoryname",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "category_id_key",
                table: "category",
                column: "id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "description_barcode_key",
                table: "description",
                column: "barcode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_description_categoryname",
                table: "description",
                column: "categoryname");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "description");

            migrationBuilder.DropTable(
                name: "category");
        }
    }
}
