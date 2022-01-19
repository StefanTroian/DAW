using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Dream_house.Migrations
{
    public partial class CreatedDBRelationTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Homes",
                table: "Homes");

            migrationBuilder.RenameTable(
                name: "Homes",
                newName: "Home");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Home",
                table: "Home",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "DecorationIdea",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Idea_description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DecorationIdea", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Room",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HomeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Home_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Room", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Room_Home_HomeId",
                        column: x => x.HomeId,
                        principalTable: "Home",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Room_DecorationIdea",
                columns: table => new
                {
                    RoomId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DecorationIdeaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Room_DecorationIdea", x => new { x.RoomId, x.DecorationIdeaId });
                    table.ForeignKey(
                        name: "FK_Room_DecorationIdea_DecorationIdea_DecorationIdeaId",
                        column: x => x.DecorationIdeaId,
                        principalTable: "DecorationIdea",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Room_DecorationIdea_Room_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Room",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Room_HomeId",
                table: "Room",
                column: "HomeId");

            migrationBuilder.CreateIndex(
                name: "IX_Room_DecorationIdea_DecorationIdeaId",
                table: "Room_DecorationIdea",
                column: "DecorationIdeaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Room_DecorationIdea");

            migrationBuilder.DropTable(
                name: "DecorationIdea");

            migrationBuilder.DropTable(
                name: "Room");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Home",
                table: "Home");

            migrationBuilder.RenameTable(
                name: "Home",
                newName: "Homes");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Homes",
                table: "Homes",
                column: "Id");
        }
    }
}
