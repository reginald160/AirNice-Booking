using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AirNice.Data.Migrations
{
    public partial class Addedimage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "picture",
                table: "Passengers",
                type: "varbinary(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "picture",
                table: "Passengers");
        }
    }
}
