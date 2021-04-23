using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AirNice.Data.Migrations
{
    public partial class UserProfiles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserRole_AspNetUsers_CreateById",
                table: "UserRole");

            migrationBuilder.DropForeignKey(
                name: "FK_UserRole_AspNetUsers_EditedById",
                table: "UserRole");

            migrationBuilder.DropIndex(
                name: "IX_UserRole_CreateById",
                table: "UserRole");

            migrationBuilder.DropIndex(
                name: "IX_UserRole_EditedById",
                table: "UserRole");

            migrationBuilder.DropColumn(
                name: "CreateById",
                table: "UserRole");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "UserRole");

            migrationBuilder.DropColumn(
                name: "DateModified",
                table: "UserRole");

            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "UserRole");

            migrationBuilder.DropColumn(
                name: "EditedById",
                table: "UserRole");

            migrationBuilder.DropColumn(
                name: "IsNewRecord",
                table: "UserRole");

            migrationBuilder.RenameColumn(
                name: "IsSuccessful",
                table: "AspNetUsers",
                newName: "IsProfiled");

            migrationBuilder.AddColumn<string>(
                name: "RoleId",
                table: "UserRole",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "UserRole",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Passengers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsProfiled",
                table: "Passengers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "UserProfiles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PassPort = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    picture = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DOB = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsProfiled = table.Column<bool>(type: "bit", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    IsNewRecord = table.Column<bool>(type: "bit", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreateById = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    EditedById = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserProfiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserProfiles_AspNetUsers_CreateById",
                        column: x => x.CreateById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserProfiles_AspNetUsers_EditedById",
                        column: x => x.EditedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserProfiles_UserRole_RoleId",
                        column: x => x.RoleId,
                        principalTable: "UserRole",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserProfiles_CreateById",
                table: "UserProfiles",
                column: "CreateById");

            migrationBuilder.CreateIndex(
                name: "IX_UserProfiles_EditedById",
                table: "UserProfiles",
                column: "EditedById");

            migrationBuilder.CreateIndex(
                name: "IX_UserProfiles_RoleId",
                table: "UserProfiles",
                column: "RoleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserProfiles");

            migrationBuilder.DropColumn(
                name: "RoleId",
                table: "UserRole");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "UserRole");

            migrationBuilder.DropColumn(
                name: "Image",
                table: "Passengers");

            migrationBuilder.DropColumn(
                name: "IsProfiled",
                table: "Passengers");

            migrationBuilder.RenameColumn(
                name: "IsProfiled",
                table: "AspNetUsers",
                newName: "IsSuccessful");

            migrationBuilder.AddColumn<string>(
                name: "CreateById",
                table: "UserRole",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "UserRole",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateModified",
                table: "UserRole",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                table: "UserRole",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "EditedById",
                table: "UserRole",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsNewRecord",
                table: "UserRole",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_UserRole_CreateById",
                table: "UserRole",
                column: "CreateById");

            migrationBuilder.CreateIndex(
                name: "IX_UserRole_EditedById",
                table: "UserRole",
                column: "EditedById");

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
    }
}
