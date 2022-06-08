using Microsoft.EntityFrameworkCore.Migrations;

namespace RentaCar_API.Migrations
{
    public partial class changeslocationImgURL : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImgURL",
                table: "Cars");

            migrationBuilder.AddColumn<double>(
                name: "EngineCapacity",
                table: "CarModals",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "ImgURL",
                table: "CarModals",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EngineCapacity",
                table: "CarModals");

            migrationBuilder.DropColumn(
                name: "ImgURL",
                table: "CarModals");

            migrationBuilder.AddColumn<string>(
                name: "ImgURL",
                table: "Cars",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
