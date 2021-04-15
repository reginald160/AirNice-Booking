using Microsoft.EntityFrameworkCore.Migrations;

namespace AirNice.Data.Migrations
{
    public partial class Added_DepartureAndArivalCountries : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ArrivalCity",
                table: "Flights",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ArrivalCountry",
                table: "Flights",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ArrivalState",
                table: "Flights",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DepartureCity",
                table: "Flights",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DepartureCountry",
                table: "Flights",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DepartureState",
                table: "Flights",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ArrivalCity",
                table: "Flights");

            migrationBuilder.DropColumn(
                name: "ArrivalCountry",
                table: "Flights");

            migrationBuilder.DropColumn(
                name: "ArrivalState",
                table: "Flights");

            migrationBuilder.DropColumn(
                name: "DepartureCity",
                table: "Flights");

            migrationBuilder.DropColumn(
                name: "DepartureCountry",
                table: "Flights");

            migrationBuilder.DropColumn(
                name: "DepartureState",
                table: "Flights");
        }
    }
}
