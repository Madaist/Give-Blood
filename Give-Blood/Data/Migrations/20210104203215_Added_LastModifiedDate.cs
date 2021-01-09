using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Give_Blood.Data.Migrations
{
    public partial class Added_LastModifiedDate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "LastWeightUpdate",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LastWeightUpdate",
                table: "AspNetUsers");
        }
    }
}
