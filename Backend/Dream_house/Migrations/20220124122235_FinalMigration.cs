using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Dream_house.Migrations
{
    public partial class FinalMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "Room_DecorationIdea",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateModified",
                table: "Room_DecorationIdea",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "Room_DecorationIdea",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "Room_DecorationIdea");

            migrationBuilder.DropColumn(
                name: "DateModified",
                table: "Room_DecorationIdea");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Room_DecorationIdea");
        }
    }
}
