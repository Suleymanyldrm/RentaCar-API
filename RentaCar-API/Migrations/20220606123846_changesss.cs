using Microsoft.EntityFrameworkCore.Migrations;

namespace RentaCar_API.Migrations
{
    public partial class changesss : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Color",
                table: "RentedCars");

            migrationBuilder.DropColumn(
                name: "dsdffgdsgdg",
                table: "RentedCars");

            migrationBuilder.DropColumn(
                name: "motorhacmi",
                table: "RentedCars");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Color",
                table: "RentedCars",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "dsdffgdsgdg",
                table: "RentedCars",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "motorhacmi",
                table: "RentedCars",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
