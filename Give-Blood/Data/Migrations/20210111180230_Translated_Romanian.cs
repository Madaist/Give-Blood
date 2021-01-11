using Microsoft.EntityFrameworkCore.Migrations;

namespace Give_Blood.Data.Migrations
{
    public partial class Translated_Romanian : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DonationInfo",
                keyColumn: "DonationType",
                keyValue: "COVID_PLASMA");

            migrationBuilder.DeleteData(
                table: "DonationInfo",
                keyColumn: "DonationType",
                keyValue: "ORDINARY_DONATION");

            migrationBuilder.DeleteData(
                table: "DonationInfo",
                keyColumn: "DonationType",
                keyValue: "SPECIAL_DONATION");

            migrationBuilder.UpdateData(
                table: "Badges",
                keyColumn: "Id",
                keyValue: "1",
                column: "Name",
                value: "PRIMA_DONARE");

            migrationBuilder.UpdateData(
                table: "Badges",
                keyColumn: "Id",
                keyValue: "2",
                column: "Name",
                value: "DONARE_DUPA_MULT_TIMP");

            migrationBuilder.UpdateData(
                table: "Badges",
                keyColumn: "Id",
                keyValue: "3",
                column: "Name",
                value: "DONARE_DUPA_3_LUNI");

            migrationBuilder.UpdateData(
                table: "Badges",
                keyColumn: "Id",
                keyValue: "4",
                column: "Name",
                value: "DONARE_DE_SARBATORI");

            migrationBuilder.UpdateData(
                table: "Badges",
                keyColumn: "Id",
                keyValue: "5",
                column: "Name",
                value: "DONARE_DE_PLASMA_COVID");

            migrationBuilder.UpdateData(
                table: "Badges",
                keyColumn: "Id",
                keyValue: "6",
                column: "Name",
                value: "PRIMA_DONARE_SPECIALA");

            migrationBuilder.UpdateData(
                table: "Badges",
                keyColumn: "Id",
                keyValue: "7",
                column: "Name",
                value: "3_DONARI_IN_9_LUNI");

            migrationBuilder.InsertData(
                table: "DonationInfo",
                columns: new[] { "DonationType", "NrOfPeopleHelped", "NrOfPoints" },
                values: new object[,]
                {
                    { "DONARE_NORMALA", 3, 20 },
                    { "PLASMA_COVID", 3, 35 },
                    { "DONARE_SPECIALA", 1, 25 }
                });

            migrationBuilder.UpdateData(
                table: "Leagues",
                keyColumn: "Id",
                keyValue: "1",
                column: "Name",
                value: "Bronz");

            migrationBuilder.UpdateData(
                table: "Leagues",
                keyColumn: "Id",
                keyValue: "2",
                column: "Name",
                value: "Argint");

            migrationBuilder.UpdateData(
                table: "Leagues",
                keyColumn: "Id",
                keyValue: "3",
                column: "Name",
                value: "Aur");

            migrationBuilder.UpdateData(
                table: "Leagues",
                keyColumn: "Id",
                keyValue: "4",
                column: "Name",
                value: "Safir");

            migrationBuilder.UpdateData(
                table: "Leagues",
                keyColumn: "Id",
                keyValue: "5",
                column: "Name",
                value: "Rubin");

            migrationBuilder.UpdateData(
                table: "Leagues",
                keyColumn: "Id",
                keyValue: "6",
                column: "Name",
                value: "Ametist");

            migrationBuilder.UpdateData(
                table: "Leagues",
                keyColumn: "Id",
                keyValue: "7",
                column: "Name",
                value: "Perla");

            migrationBuilder.UpdateData(
                table: "Leagues",
                keyColumn: "Id",
                keyValue: "9",
                column: "Name",
                value: "Diamant");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DonationInfo",
                keyColumn: "DonationType",
                keyValue: "DONARE_NORMALA");

            migrationBuilder.DeleteData(
                table: "DonationInfo",
                keyColumn: "DonationType",
                keyValue: "DONARE_SPECIALA");

            migrationBuilder.DeleteData(
                table: "DonationInfo",
                keyColumn: "DonationType",
                keyValue: "PLASMA_COVID");

            migrationBuilder.UpdateData(
                table: "Badges",
                keyColumn: "Id",
                keyValue: "1",
                column: "Name",
                value: "FIRST_DONATION");

            migrationBuilder.UpdateData(
                table: "Badges",
                keyColumn: "Id",
                keyValue: "2",
                column: "Name",
                value: "DONATION_AFTER_LONG_TIME");

            migrationBuilder.UpdateData(
                table: "Badges",
                keyColumn: "Id",
                keyValue: "3",
                column: "Name",
                value: "DONATION_AFTER_3_MONTHS");

            migrationBuilder.UpdateData(
                table: "Badges",
                keyColumn: "Id",
                keyValue: "4",
                column: "Name",
                value: "HOLIDAY_DONATION");

            migrationBuilder.UpdateData(
                table: "Badges",
                keyColumn: "Id",
                keyValue: "5",
                column: "Name",
                value: "COVID_PLASMA_DONATION");

            migrationBuilder.UpdateData(
                table: "Badges",
                keyColumn: "Id",
                keyValue: "6",
                column: "Name",
                value: "FIRST_SPECIAL_DONATION");

            migrationBuilder.UpdateData(
                table: "Badges",
                keyColumn: "Id",
                keyValue: "7",
                column: "Name",
                value: "3_DONATIONS_IN_9_MONTHS");

            migrationBuilder.InsertData(
                table: "DonationInfo",
                columns: new[] { "DonationType", "NrOfPeopleHelped", "NrOfPoints" },
                values: new object[,]
                {
                    { "ORDINARY_DONATION", 3, 20 },
                    { "COVID_PLASMA", 3, 35 },
                    { "SPECIAL_DONATION", 1, 25 }
                });

            migrationBuilder.UpdateData(
                table: "Leagues",
                keyColumn: "Id",
                keyValue: "1",
                column: "Name",
                value: "Bronze");

            migrationBuilder.UpdateData(
                table: "Leagues",
                keyColumn: "Id",
                keyValue: "2",
                column: "Name",
                value: "Silver");

            migrationBuilder.UpdateData(
                table: "Leagues",
                keyColumn: "Id",
                keyValue: "3",
                column: "Name",
                value: "Gold");

            migrationBuilder.UpdateData(
                table: "Leagues",
                keyColumn: "Id",
                keyValue: "4",
                column: "Name",
                value: "Sapphire");

            migrationBuilder.UpdateData(
                table: "Leagues",
                keyColumn: "Id",
                keyValue: "5",
                column: "Name",
                value: "Ruby");

            migrationBuilder.UpdateData(
                table: "Leagues",
                keyColumn: "Id",
                keyValue: "6",
                column: "Name",
                value: "Amethyst");

            migrationBuilder.UpdateData(
                table: "Leagues",
                keyColumn: "Id",
                keyValue: "7",
                column: "Name",
                value: "Pearl");

            migrationBuilder.UpdateData(
                table: "Leagues",
                keyColumn: "Id",
                keyValue: "9",
                column: "Name",
                value: "Diamond");
        }
    }
}
