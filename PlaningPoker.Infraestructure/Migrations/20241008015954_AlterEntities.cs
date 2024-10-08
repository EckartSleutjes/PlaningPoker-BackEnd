using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PlaningPoker.Infraestructure.Migrations
{
    /// <inheritdoc />
    public partial class AlterEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StoriePlayer_PokerItem_PokerItemId",
                table: "StoriePlayer");

            migrationBuilder.DropIndex(
                name: "IX_StoriePlayer_PokerItemId",
                table: "StoriePlayer");

            migrationBuilder.DropColumn(
                name: "PokerItemId",
                table: "StoriePlayer");

            migrationBuilder.AddColumn<string>(
                name: "PokerItem",
                table: "StoriePlayer",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PokerItem",
                table: "StoriePlayer");

            migrationBuilder.AddColumn<Guid>(
                name: "PokerItemId",
                table: "StoriePlayer",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_StoriePlayer_PokerItemId",
                table: "StoriePlayer",
                column: "PokerItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_StoriePlayer_PokerItem_PokerItemId",
                table: "StoriePlayer",
                column: "PokerItemId",
                principalTable: "PokerItem",
                principalColumn: "Id");
        }
    }
}
