using Microsoft.EntityFrameworkCore.Migrations;

namespace AirNice.Data.Migrations
{
    public partial class AddedRoletitle : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "RoleTitle",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RoleTitle",
                table: "AspNetUsers");
        }
    }
}
