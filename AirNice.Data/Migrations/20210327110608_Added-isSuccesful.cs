using Microsoft.EntityFrameworkCore.Migrations;

namespace AirNice.Data.Migrations
{
    public partial class AddedisSuccesful : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsSuccessful",
                table: "AspNetUsers",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsSuccessful",
                table: "AspNetUsers");
        }
    }
}
