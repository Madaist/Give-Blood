using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Give_Blood.Data.Migrations
{
    public partial class RegisterDate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LoginDate",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<DateTime>(
                name: "RegisterDate",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RegisterDate",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<DateTime>(
                name: "LoginDate",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
