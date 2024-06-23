using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazorAppEmpty.Migrations
{
    /// <inheritdoc />
    public partial class test2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "cards",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_cards_UserId",
                table: "cards",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_cards_users_UserId",
                table: "cards",
                column: "UserId",
                principalTable: "users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_cards_users_UserId",
                table: "cards");

            migrationBuilder.DropIndex(
                name: "IX_cards_UserId",
                table: "cards");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "cards");
        }
    }
}
