using Microsoft.EntityFrameworkCore.Migrations;

namespace Give_Blood.Data.Migrations
{
    public partial class Added_database_seeder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Badges",
                columns: new[] { "Id", "Icon", "Name" },
                values: new object[,]
                {
                    { "1", "https://i.ibb.co/3rzcKMM/first-donation-badge.png", "FIRST_DONATION" },
                    { "2", "https://i.ibb.co/3rzcKMM/first-donation-badge.png", "DONATION_AFTER_LONG_TIME" },
                    { "3", "https://i.ibb.co/3rzcKMM/first-donation-badge.png", "DONATION_AFTER_3_MONTHS" },
                    { "4", "https://i.ibb.co/3rzcKMM/first-donation-badge.png", "HOLIDAY_DONATION" },
                    { "5", "https://i.ibb.co/3rzcKMM/first-donation-badge.png", "COVID_PLASMA_DONATION" },
                    { "6", "https://i.ibb.co/3rzcKMM/first-donation-badge.png", "FIRST_SPECIAL_DONATION" },
                    { "7", "https://i.ibb.co/3rzcKMM/first-donation-badge.png", "FIRST_SPECIAL_DONATION" },
                    { "8", "https://i.ibb.co/3rzcKMM/first-donation-badge.png", "3_DONATIONS_IN_9_MONTHS" }
                });

            migrationBuilder.InsertData(
                table: "DonationInfo",
                columns: new[] { "DonationType", "NrOfPeopleHelped", "NrOfPoints" },
                values: new object[,]
                {
                    { "COVID_PLASMA", 3, 35 },
                    { "SPECIAL_DONATION", 1, 25 },
                    { "ORDINARY_DONATION", 3, 20 }
                });

            migrationBuilder.InsertData(
                table: "Leagues",
                columns: new[] { "Id", "Icon", "MaxPoints", "MinPoints", "Name" },
                values: new object[,]
                {
                    { "1", "https://i.ibb.co/x2XhmKb/Badge-Bronze-Blank.png", 35, 0, "Bronze" },
                    { "2", "https://i.ibb.co/N1WvGS7/Badge-Silver-Blank.png", 70, 36, "Silver" },
                    { "3", "https://i.ibb.co/ZKkccn9/Badge-Gold-Blank.png", 120, 71, "Gold" },
                    { "4", "https://i.ibb.co/vYB15Vr/Badge-Sapphire-Blank.png", 160, 121, "Sapphire" },
                    { "5", "https://i.ibb.co/h1LK5dT/Badge-Ruby-Blank.png", 200, 161, "Ruby" },
                    { "6", "https://i.ibb.co/cLtG5RC/Badge-Amethyst-Blank.png", 250, 201, "Amethyst" },
                    { "7", "https://i.ibb.co/jMRMtRV/Badge-Pearl-Blank.png", 290, 251, "Pearl" },
                    { "8", "https://i.ibb.co/kBdQq6p/Badge-Obsidian-Blank.png", 400, 291, "Obsidian" },
                    { "9", "https://i.ibb.co/DMRB8k9/Badge-Diamond-Blank.png", 10000, 401, "Diamond" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Badges",
                keyColumn: "Id",
                keyValue: "1");

            migrationBuilder.DeleteData(
                table: "Badges",
                keyColumn: "Id",
                keyValue: "2");

            migrationBuilder.DeleteData(
                table: "Badges",
                keyColumn: "Id",
                keyValue: "3");

            migrationBuilder.DeleteData(
                table: "Badges",
                keyColumn: "Id",
                keyValue: "4");

            migrationBuilder.DeleteData(
                table: "Badges",
                keyColumn: "Id",
                keyValue: "5");

            migrationBuilder.DeleteData(
                table: "Badges",
                keyColumn: "Id",
                keyValue: "6");

            migrationBuilder.DeleteData(
                table: "Badges",
                keyColumn: "Id",
                keyValue: "7");

            migrationBuilder.DeleteData(
                table: "Badges",
                keyColumn: "Id",
                keyValue: "8");

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

            migrationBuilder.DeleteData(
                table: "Leagues",
                keyColumn: "Id",
                keyValue: "1");

            migrationBuilder.DeleteData(
                table: "Leagues",
                keyColumn: "Id",
                keyValue: "2");

            migrationBuilder.DeleteData(
                table: "Leagues",
                keyColumn: "Id",
                keyValue: "3");

            migrationBuilder.DeleteData(
                table: "Leagues",
                keyColumn: "Id",
                keyValue: "4");

            migrationBuilder.DeleteData(
                table: "Leagues",
                keyColumn: "Id",
                keyValue: "5");

            migrationBuilder.DeleteData(
                table: "Leagues",
                keyColumn: "Id",
                keyValue: "6");

            migrationBuilder.DeleteData(
                table: "Leagues",
                keyColumn: "Id",
                keyValue: "7");

            migrationBuilder.DeleteData(
                table: "Leagues",
                keyColumn: "Id",
                keyValue: "8");

            migrationBuilder.DeleteData(
                table: "Leagues",
                keyColumn: "Id",
                keyValue: "9");
        }
    }
}
