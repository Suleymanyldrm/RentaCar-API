using Microsoft.EntityFrameworkCore.Migrations;

namespace RentaCar_API.Migrations
{
    public partial class UpdateSlug : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Slug",
                table: "Officies",
                newName: "Location");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Location",
                table: "Officies",
                newName: "Slug");
        }
    }
}
