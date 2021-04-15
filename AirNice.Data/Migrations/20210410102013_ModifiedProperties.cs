using Microsoft.EntityFrameworkCore.Migrations;

namespace AirNice.Data.Migrations
{
    public partial class ModifiedProperties : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FlightCategory",
                table: "Flights",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "FlightCategoryToDisplay",
                table: "Flights",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "Flights",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "TripTypes",
                table: "Flights",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BookingTypeToDisplay",
                table: "Bookings",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NumberOfAdult",
                table: "Bookings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "NumberOfChildren",
                table: "Bookings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "NumberOfInfant",
                table: "Bookings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TripeType",
                table: "Bookings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "TripeTypeToDisplay",
                table: "Bookings",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FlightCategory",
                table: "Flights");

            migrationBuilder.DropColumn(
                name: "FlightCategoryToDisplay",
                table: "Flights");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Flights");

            migrationBuilder.DropColumn(
                name: "TripTypes",
                table: "Flights");

            migrationBuilder.DropColumn(
                name: "BookingTypeToDisplay",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "NumberOfAdult",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "NumberOfChildren",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "NumberOfInfant",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "TripeType",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "TripeTypeToDisplay",
                table: "Bookings");
        }
    }
}
