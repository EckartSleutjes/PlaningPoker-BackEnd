using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PlaningPoker.Infraestructure.Migrations
{
    /// <inheritdoc />
    public partial class RemovePasswordUserEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LastName",
                table: "User");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "User");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "User",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<byte[]>(
                name: "Password",
                table: "User",
                type: "bytea",
                nullable: false,
                defaultValue: new byte[0]);
        }
    }
}
