using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AirNice.Data.Migrations
{
    public partial class ArrivalDepartureDate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ArrivateDateTime",
                table: "Flight");

            migrationBuilder.DropColumn(
                name: "DepartureDateTime",
                table: "Flight");

            migrationBuilder.AddColumn<DateTime>(
                name: "ArrivalDate",
                table: "Flight",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DepartureDate",
                table: "Flight",
                type: "datetime2",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ArrivalDate",
                table: "Flight");

            migrationBuilder.DropColumn(
                name: "DepartureDate",
                table: "Flight");

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "ArrivateDateTime",
                table: "Flight",
                type: "datetimeoffset",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "DepartureDateTime",
                table: "Flight",
                type: "datetimeoffset",
                nullable: true);
        }
    }
}
