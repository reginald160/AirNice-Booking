using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AirNice.Data.Migrations
{
    public partial class Added_FlightAirport_and_Location : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CreateById",
                table: "UserRole",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EditedById",
                table: "UserRole",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreateById",
                table: "TicketClasses",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EditedById",
                table: "TicketClasses",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreateById",
                table: "Permissions",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EditedById",
                table: "Permissions",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreateById",
                table: "Passengers",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EditedById",
                table: "Passengers",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreateById",
                table: "NumberSequences",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EditedById",
                table: "NumberSequences",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreateById",
                table: "Bookings",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EditedById",
                table: "Bookings",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "FlightId",
                table: "Bookings",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "Bookings",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "CreateById",
                table: "BookingEnquiries",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EditedById",
                table: "BookingEnquiries",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreateById",
                table: "AirLinesEnquiries",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EditedById",
                table: "AirLinesEnquiries",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreateById",
                table: "AdditionalUsers",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EditedById",
                table: "AdditionalUsers",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Bank",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AccountNumber = table.Column<long>(type: "bigint", nullable: false),
                    AccountName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    IsNewRecord = table.Column<bool>(type: "bit", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreateById = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    EditedById = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bank", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bank_AspNetUsers_CreateById",
                        column: x => x.CreateById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Bank_AspNetUsers_EditedById",
                        column: x => x.EditedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Flights",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AirLine = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FlightNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ArrivateDateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    DepartureDateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    TotalSeat = table.Column<int>(type: "int", nullable: false),
                    TotalVacantSeat = table.Column<int>(type: "int", nullable: false),
                    Seatnumber = table.Column<int>(type: "int", nullable: false),
                    CoachSeats = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsAvailable = table.Column<bool>(type: "bit", nullable: false),
                    TypeOfPlane = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Faire = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    IsNewRecord = table.Column<bool>(type: "bit", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreateById = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    EditedById = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Flights", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Flights_AspNetUsers_CreateById",
                        column: x => x.CreateById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Flights_AspNetUsers_EditedById",
                        column: x => x.EditedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ZipCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TimeZone = table.Column<int>(type: "int", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    IsNewRecord = table.Column<bool>(type: "bit", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreateById = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    EditedById = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Locations_AspNetUsers_CreateById",
                        column: x => x.CreateById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Locations_AspNetUsers_EditedById",
                        column: x => x.EditedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AirPorts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Abbreviation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LocationId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    IsNewRecord = table.Column<bool>(type: "bit", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreateById = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    EditedById = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AirPorts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AirPorts_AspNetUsers_CreateById",
                        column: x => x.CreateById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AirPorts_AspNetUsers_EditedById",
                        column: x => x.EditedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AirPorts_Locations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserRole_CreateById",
                table: "UserRole",
                column: "CreateById");

            migrationBuilder.CreateIndex(
                name: "IX_UserRole_EditedById",
                table: "UserRole",
                column: "EditedById");

            migrationBuilder.CreateIndex(
                name: "IX_TicketClasses_CreateById",
                table: "TicketClasses",
                column: "CreateById");

            migrationBuilder.CreateIndex(
                name: "IX_TicketClasses_EditedById",
                table: "TicketClasses",
                column: "EditedById");

            migrationBuilder.CreateIndex(
                name: "IX_Permissions_CreateById",
                table: "Permissions",
                column: "CreateById");

            migrationBuilder.CreateIndex(
                name: "IX_Permissions_EditedById",
                table: "Permissions",
                column: "EditedById");

            migrationBuilder.CreateIndex(
                name: "IX_Passengers_CreateById",
                table: "Passengers",
                column: "CreateById");

            migrationBuilder.CreateIndex(
                name: "IX_Passengers_EditedById",
                table: "Passengers",
                column: "EditedById");

            migrationBuilder.CreateIndex(
                name: "IX_NumberSequences_CreateById",
                table: "NumberSequences",
                column: "CreateById");

            migrationBuilder.CreateIndex(
                name: "IX_NumberSequences_EditedById",
                table: "NumberSequences",
                column: "EditedById");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_CreateById",
                table: "Bookings",
                column: "CreateById");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_EditedById",
                table: "Bookings",
                column: "EditedById");

            migrationBuilder.CreateIndex(
                name: "IX_BookingEnquiries_CreateById",
                table: "BookingEnquiries",
                column: "CreateById");

            migrationBuilder.CreateIndex(
                name: "IX_BookingEnquiries_EditedById",
                table: "BookingEnquiries",
                column: "EditedById");

            migrationBuilder.CreateIndex(
                name: "IX_AirLinesEnquiries_CreateById",
                table: "AirLinesEnquiries",
                column: "CreateById");

            migrationBuilder.CreateIndex(
                name: "IX_AirLinesEnquiries_EditedById",
                table: "AirLinesEnquiries",
                column: "EditedById");

            migrationBuilder.CreateIndex(
                name: "IX_AdditionalUsers_CreateById",
                table: "AdditionalUsers",
                column: "CreateById");

            migrationBuilder.CreateIndex(
                name: "IX_AdditionalUsers_EditedById",
                table: "AdditionalUsers",
                column: "EditedById");

            migrationBuilder.CreateIndex(
                name: "IX_AirPorts_CreateById",
                table: "AirPorts",
                column: "CreateById");

            migrationBuilder.CreateIndex(
                name: "IX_AirPorts_EditedById",
                table: "AirPorts",
                column: "EditedById");

            migrationBuilder.CreateIndex(
                name: "IX_AirPorts_LocationId",
                table: "AirPorts",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Bank_CreateById",
                table: "Bank",
                column: "CreateById");

            migrationBuilder.CreateIndex(
                name: "IX_Bank_EditedById",
                table: "Bank",
                column: "EditedById");

            migrationBuilder.CreateIndex(
                name: "IX_Flights_CreateById",
                table: "Flights",
                column: "CreateById");

            migrationBuilder.CreateIndex(
                name: "IX_Flights_EditedById",
                table: "Flights",
                column: "EditedById");

            migrationBuilder.CreateIndex(
                name: "IX_Locations_CreateById",
                table: "Locations",
                column: "CreateById");

            migrationBuilder.CreateIndex(
                name: "IX_Locations_EditedById",
                table: "Locations",
                column: "EditedById");

            migrationBuilder.AddForeignKey(
                name: "FK_AdditionalUsers_AspNetUsers_CreateById",
                table: "AdditionalUsers",
                column: "CreateById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AdditionalUsers_AspNetUsers_EditedById",
                table: "AdditionalUsers",
                column: "EditedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AirLinesEnquiries_AspNetUsers_CreateById",
                table: "AirLinesEnquiries",
                column: "CreateById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AirLinesEnquiries_AspNetUsers_EditedById",
                table: "AirLinesEnquiries",
                column: "EditedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BookingEnquiries_AspNetUsers_CreateById",
                table: "BookingEnquiries",
                column: "CreateById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BookingEnquiries_AspNetUsers_EditedById",
                table: "BookingEnquiries",
                column: "EditedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_AspNetUsers_CreateById",
                table: "Bookings",
                column: "CreateById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_AspNetUsers_EditedById",
                table: "Bookings",
                column: "EditedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_Flights_PassengerId",
                table: "Bookings",
                column: "PassengerId",
                principalTable: "Flights",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_NumberSequences_AspNetUsers_CreateById",
                table: "NumberSequences",
                column: "CreateById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_NumberSequences_AspNetUsers_EditedById",
                table: "NumberSequences",
                column: "EditedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Passengers_AspNetUsers_CreateById",
                table: "Passengers",
                column: "CreateById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Passengers_AspNetUsers_EditedById",
                table: "Passengers",
                column: "EditedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Permissions_AspNetUsers_CreateById",
                table: "Permissions",
                column: "CreateById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Permissions_AspNetUsers_EditedById",
                table: "Permissions",
                column: "EditedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TicketClasses_AspNetUsers_CreateById",
                table: "TicketClasses",
                column: "CreateById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TicketClasses_AspNetUsers_EditedById",
                table: "TicketClasses",
                column: "EditedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserRole_AspNetUsers_CreateById",
                table: "UserRole",
                column: "CreateById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserRole_AspNetUsers_EditedById",
                table: "UserRole",
                column: "EditedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AdditionalUsers_AspNetUsers_CreateById",
                table: "AdditionalUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AdditionalUsers_AspNetUsers_EditedById",
                table: "AdditionalUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AirLinesEnquiries_AspNetUsers_CreateById",
                table: "AirLinesEnquiries");

            migrationBuilder.DropForeignKey(
                name: "FK_AirLinesEnquiries_AspNetUsers_EditedById",
                table: "AirLinesEnquiries");

            migrationBuilder.DropForeignKey(
                name: "FK_BookingEnquiries_AspNetUsers_CreateById",
                table: "BookingEnquiries");

            migrationBuilder.DropForeignKey(
                name: "FK_BookingEnquiries_AspNetUsers_EditedById",
                table: "BookingEnquiries");

            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_AspNetUsers_CreateById",
                table: "Bookings");

            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_AspNetUsers_EditedById",
                table: "Bookings");

            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_Flights_PassengerId",
                table: "Bookings");

            migrationBuilder.DropForeignKey(
                name: "FK_NumberSequences_AspNetUsers_CreateById",
                table: "NumberSequences");

            migrationBuilder.DropForeignKey(
                name: "FK_NumberSequences_AspNetUsers_EditedById",
                table: "NumberSequences");

            migrationBuilder.DropForeignKey(
                name: "FK_Passengers_AspNetUsers_CreateById",
                table: "Passengers");

            migrationBuilder.DropForeignKey(
                name: "FK_Passengers_AspNetUsers_EditedById",
                table: "Passengers");

            migrationBuilder.DropForeignKey(
                name: "FK_Permissions_AspNetUsers_CreateById",
                table: "Permissions");

            migrationBuilder.DropForeignKey(
                name: "FK_Permissions_AspNetUsers_EditedById",
                table: "Permissions");

            migrationBuilder.DropForeignKey(
                name: "FK_TicketClasses_AspNetUsers_CreateById",
                table: "TicketClasses");

            migrationBuilder.DropForeignKey(
                name: "FK_TicketClasses_AspNetUsers_EditedById",
                table: "TicketClasses");

            migrationBuilder.DropForeignKey(
                name: "FK_UserRole_AspNetUsers_CreateById",
                table: "UserRole");

            migrationBuilder.DropForeignKey(
                name: "FK_UserRole_AspNetUsers_EditedById",
                table: "UserRole");

            migrationBuilder.DropTable(
                name: "AirPorts");

            migrationBuilder.DropTable(
                name: "Bank");

            migrationBuilder.DropTable(
                name: "Flights");

            migrationBuilder.DropTable(
                name: "Locations");

            migrationBuilder.DropIndex(
                name: "IX_UserRole_CreateById",
                table: "UserRole");

            migrationBuilder.DropIndex(
                name: "IX_UserRole_EditedById",
                table: "UserRole");

            migrationBuilder.DropIndex(
                name: "IX_TicketClasses_CreateById",
                table: "TicketClasses");

            migrationBuilder.DropIndex(
                name: "IX_TicketClasses_EditedById",
                table: "TicketClasses");

            migrationBuilder.DropIndex(
                name: "IX_Permissions_CreateById",
                table: "Permissions");

            migrationBuilder.DropIndex(
                name: "IX_Permissions_EditedById",
                table: "Permissions");

            migrationBuilder.DropIndex(
                name: "IX_Passengers_CreateById",
                table: "Passengers");

            migrationBuilder.DropIndex(
                name: "IX_Passengers_EditedById",
                table: "Passengers");

            migrationBuilder.DropIndex(
                name: "IX_NumberSequences_CreateById",
                table: "NumberSequences");

            migrationBuilder.DropIndex(
                name: "IX_NumberSequences_EditedById",
                table: "NumberSequences");

            migrationBuilder.DropIndex(
                name: "IX_Bookings_CreateById",
                table: "Bookings");

            migrationBuilder.DropIndex(
                name: "IX_Bookings_EditedById",
                table: "Bookings");

            migrationBuilder.DropIndex(
                name: "IX_BookingEnquiries_CreateById",
                table: "BookingEnquiries");

            migrationBuilder.DropIndex(
                name: "IX_BookingEnquiries_EditedById",
                table: "BookingEnquiries");

            migrationBuilder.DropIndex(
                name: "IX_AirLinesEnquiries_CreateById",
                table: "AirLinesEnquiries");

            migrationBuilder.DropIndex(
                name: "IX_AirLinesEnquiries_EditedById",
                table: "AirLinesEnquiries");

            migrationBuilder.DropIndex(
                name: "IX_AdditionalUsers_CreateById",
                table: "AdditionalUsers");

            migrationBuilder.DropIndex(
                name: "IX_AdditionalUsers_EditedById",
                table: "AdditionalUsers");

            migrationBuilder.DropColumn(
                name: "CreateById",
                table: "UserRole");

            migrationBuilder.DropColumn(
                name: "EditedById",
                table: "UserRole");

            migrationBuilder.DropColumn(
                name: "CreateById",
                table: "TicketClasses");

            migrationBuilder.DropColumn(
                name: "EditedById",
                table: "TicketClasses");

            migrationBuilder.DropColumn(
                name: "CreateById",
                table: "Permissions");

            migrationBuilder.DropColumn(
                name: "EditedById",
                table: "Permissions");

            migrationBuilder.DropColumn(
                name: "CreateById",
                table: "Passengers");

            migrationBuilder.DropColumn(
                name: "EditedById",
                table: "Passengers");

            migrationBuilder.DropColumn(
                name: "CreateById",
                table: "NumberSequences");

            migrationBuilder.DropColumn(
                name: "EditedById",
                table: "NumberSequences");

            migrationBuilder.DropColumn(
                name: "CreateById",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "EditedById",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "FlightId",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "CreateById",
                table: "BookingEnquiries");

            migrationBuilder.DropColumn(
                name: "EditedById",
                table: "BookingEnquiries");

            migrationBuilder.DropColumn(
                name: "CreateById",
                table: "AirLinesEnquiries");

            migrationBuilder.DropColumn(
                name: "EditedById",
                table: "AirLinesEnquiries");

            migrationBuilder.DropColumn(
                name: "CreateById",
                table: "AdditionalUsers");

            migrationBuilder.DropColumn(
                name: "EditedById",
                table: "AdditionalUsers");
        }
    }
}
