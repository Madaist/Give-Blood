using Microsoft.EntityFrameworkCore.Migrations;

namespace Give_Blood.Data.Migrations
{
    public partial class Added_badge_points : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "NrOfPoints",
                table: "Badges",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Badges",
                keyColumn: "Id",
                keyValue: "1",
                column: "NrOfPoints",
                value: 20);

            migrationBuilder.UpdateData(
                table: "Badges",
                keyColumn: "Id",
                keyValue: "2",
                column: "NrOfPoints",
                value: 10);

            migrationBuilder.UpdateData(
                table: "Badges",
                keyColumn: "Id",
                keyValue: "3",
                column: "NrOfPoints",
                value: 40);

            migrationBuilder.UpdateData(
                table: "Badges",
                keyColumn: "Id",
                keyValue: "4",
                column: "NrOfPoints",
                value: 50);

            migrationBuilder.UpdateData(
                table: "Badges",
                keyColumn: "Id",
                keyValue: "5",
                column: "NrOfPoints",
                value: 30);

            migrationBuilder.UpdateData(
                table: "Badges",
                keyColumn: "Id",
                keyValue: "6",
                column: "NrOfPoints",
                value: 35);

            migrationBuilder.UpdateData(
                table: "Badges",
                keyColumn: "Id",
                keyValue: "7",
                column: "NrOfPoints",
                value: 60);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NrOfPoints",
                table: "Badges");
        }
    }
}
