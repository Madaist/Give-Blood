using Microsoft.EntityFrameworkCore.Migrations;

namespace Give_Blood.Data.Migrations
{
    public partial class AddedNumberOfPoints : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NumberOfPoints",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<int>(
                name: "NrOfPoints",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NrOfPoints",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<int>(
                name: "NumberOfPoints",
                table: "AspNetUsers",
                type: "int",
                nullable: true);
        }
    }
}
