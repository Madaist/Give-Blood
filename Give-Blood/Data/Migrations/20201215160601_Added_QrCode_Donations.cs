using Microsoft.EntityFrameworkCore.Migrations;

namespace Give_Blood.Data.Migrations
{
    public partial class Added_QrCode_Donations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "QrCode",
                table: "Donations",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Badges",
                keyColumn: "Id",
                keyValue: "2",
                column: "NrOfPoints",
                value: 10);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "QrCode",
                table: "Donations");

            migrationBuilder.UpdateData(
                table: "Badges",
                keyColumn: "Id",
                keyValue: "2",
                column: "NrOfPoints",
                value: 5);
        }
    }
}
