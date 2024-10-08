using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PlaningPoker.Infraestructure.Migrations
{
    /// <inheritdoc />
    public partial class AddEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Storie",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Played = table.Column<bool>(type: "boolean", nullable: false),
                    RoomId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Storie", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Storie_Room_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Room",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StoriePlayer",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    PlayerId = table.Column<Guid>(type: "uuid", nullable: false),
                    StorieId = table.Column<Guid>(type: "uuid", nullable: false),
                    PokerItemId = table.Column<Guid>(type: "uuid", nullable: true),
                    Flip = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StoriePlayer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StoriePlayer_Player_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Player",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StoriePlayer_PokerItem_PokerItemId",
                        column: x => x.PokerItemId,
                        principalTable: "PokerItem",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_StoriePlayer_Storie_StorieId",
                        column: x => x.StorieId,
                        principalTable: "Storie",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Storie_RoomId",
                table: "Storie",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_StoriePlayer_PlayerId",
                table: "StoriePlayer",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_StoriePlayer_PokerItemId",
                table: "StoriePlayer",
                column: "PokerItemId");

            migrationBuilder.CreateIndex(
                name: "IX_StoriePlayer_StorieId",
                table: "StoriePlayer",
                column: "StorieId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StoriePlayer");

            migrationBuilder.DropTable(
                name: "Storie");
        }
    }
}
