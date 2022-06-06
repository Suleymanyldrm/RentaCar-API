using Microsoft.EntityFrameworkCore.Migrations;

namespace RentaCar_API.Migrations
{
    public partial class changes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Year",
                table: "RentedCars");

            migrationBuilder.AddColumn<string>(
                name: "dsdffgdsgdg",
                table: "RentedCars",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "dsdffgdsgdg",
                table: "RentedCars");

            migrationBuilder.AddColumn<int>(
                name: "Year",
                table: "RentedCars",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
