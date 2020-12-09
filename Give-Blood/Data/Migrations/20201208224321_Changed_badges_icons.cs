using Microsoft.EntityFrameworkCore.Migrations;

namespace Give_Blood.Data.Migrations
{
    public partial class Changed_badges_icons : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Badges",
                keyColumn: "Id",
                keyValue: "8");

            migrationBuilder.UpdateData(
                table: "Badges",
                keyColumn: "Id",
                keyValue: "1",
                column: "Icon",
                value: "https://i.ibb.co/sR1DLrn/first-donation.png");

            migrationBuilder.UpdateData(
                table: "Badges",
                keyColumn: "Id",
                keyValue: "2",
                column: "Icon",
                value: "https://i.ibb.co/n0g1vd6/donation-long-time.png");

            migrationBuilder.UpdateData(
                table: "Badges",
                keyColumn: "Id",
                keyValue: "3",
                column: "Icon",
                value: "https://i.ibb.co/CzCdhfC/three-months.png");

            migrationBuilder.UpdateData(
                table: "Badges",
                keyColumn: "Id",
                keyValue: "4",
                column: "Icon",
                value: "https://i.ibb.co/qWNvzRx/holiday-donation1.png");

            migrationBuilder.UpdateData(
                table: "Badges",
                keyColumn: "Id",
                keyValue: "5",
                column: "Icon",
                value: "https://i.ibb.co/QkPq2R9/covid-donation.png");

            migrationBuilder.UpdateData(
                table: "Badges",
                keyColumn: "Id",
                keyValue: "6",
                column: "Icon",
                value: "https://i.ibb.co/5hrRy80/special-badge.png");

            migrationBuilder.UpdateData(
                table: "Badges",
                keyColumn: "Id",
                keyValue: "7",
                columns: new[] { "Icon", "Name" },
                values: new object[] { "https://i.ibb.co/SJW0h2j/three-nine.png", "3_DONATIONS_IN_9_MONTHS" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Badges",
                keyColumn: "Id",
                keyValue: "1",
                column: "Icon",
                value: "https://i.ibb.co/3rzcKMM/first-donation-badge.png");

            migrationBuilder.UpdateData(
                table: "Badges",
                keyColumn: "Id",
                keyValue: "2",
                column: "Icon",
                value: "https://i.ibb.co/3rzcKMM/first-donation-badge.png");

            migrationBuilder.UpdateData(
                table: "Badges",
                keyColumn: "Id",
                keyValue: "3",
                column: "Icon",
                value: "https://i.ibb.co/3rzcKMM/first-donation-badge.png");

            migrationBuilder.UpdateData(
                table: "Badges",
                keyColumn: "Id",
                keyValue: "4",
                column: "Icon",
                value: "https://i.ibb.co/3rzcKMM/first-donation-badge.png");

            migrationBuilder.UpdateData(
                table: "Badges",
                keyColumn: "Id",
                keyValue: "5",
                column: "Icon",
                value: "https://i.ibb.co/3rzcKMM/first-donation-badge.png");

            migrationBuilder.UpdateData(
                table: "Badges",
                keyColumn: "Id",
                keyValue: "6",
                column: "Icon",
                value: "https://i.ibb.co/3rzcKMM/first-donation-badge.png");

            migrationBuilder.UpdateData(
                table: "Badges",
                keyColumn: "Id",
                keyValue: "7",
                columns: new[] { "Icon", "Name" },
                values: new object[] { "https://i.ibb.co/3rzcKMM/first-donation-badge.png", "FIRST_SPECIAL_DONATION" });

            migrationBuilder.InsertData(
                table: "Badges",
                columns: new[] { "Id", "Icon", "Name" },
                values: new object[] { "8", "https://i.ibb.co/3rzcKMM/first-donation-badge.png", "3_DONATIONS_IN_9_MONTHS" });
        }
    }
}
