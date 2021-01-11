using Microsoft.EntityFrameworkCore.Migrations;

namespace Give_Blood.Data.Migrations
{
    public partial class Added_diacritics : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DonationInfo",
                keyColumn: "DonationType",
                keyValue: "DONARE_NORMALA");

            migrationBuilder.DeleteData(
                table: "DonationInfo",
                keyColumn: "DonationType",
                keyValue: "DONARE_SPECIALA");

            migrationBuilder.UpdateData(
                table: "Badges",
                keyColumn: "Id",
                keyValue: "2",
                column: "Name",
                value: "DONARE_DUPĂ_MULT_TIMP");

            migrationBuilder.UpdateData(
                table: "Badges",
                keyColumn: "Id",
                keyValue: "3",
                column: "Name",
                value: "DONARE_DUPĂ_3_LUNI");

            migrationBuilder.UpdateData(
                table: "Badges",
                keyColumn: "Id",
                keyValue: "4",
                column: "Name",
                value: "DONARE_DE_SĂRBĂTORI");

            migrationBuilder.UpdateData(
                table: "Badges",
                keyColumn: "Id",
                keyValue: "5",
                column: "Name",
                value: "DONARE_DE_PLASMĂ_COVID");

            migrationBuilder.UpdateData(
                table: "Badges",
                keyColumn: "Id",
                keyValue: "6",
                column: "Name",
                value: "PRIMA_DONARE_SPECIALĂ");

            migrationBuilder.UpdateData(
                table: "Badges",
                keyColumn: "Id",
                keyValue: "7",
                column: "Name",
                value: "3_DONĂRI_ÎN_9_LUNI");

            migrationBuilder.InsertData(
                table: "DonationInfo",
                columns: new[] { "DonationType", "NrOfPeopleHelped", "NrOfPoints" },
                values: new object[,]
                {
                    { "DONARE_NORMALĂ", 3, 20 },
                    { "DONARE_SPECIALĂ", 1, 25 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DonationInfo",
                keyColumn: "DonationType",
                keyValue: "DONARE_NORMALĂ");

            migrationBuilder.DeleteData(
                table: "DonationInfo",
                keyColumn: "DonationType",
                keyValue: "DONARE_SPECIALĂ");

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
                value: "DOANRE_DE_PLASMA_COVID");

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
                    { "DONARE_SPECIALA", 1, 25 }
                });
        }
    }
}
