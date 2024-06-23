using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazorAppEmpty.Migrations
{
    /// <inheritdoc />
    public partial class fixextrakeysmaybe : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_cards_columns_KbColumnId",
                table: "cards");

            migrationBuilder.DropForeignKey(
                name: "FK_cards_users_UserId",
                table: "cards");

            migrationBuilder.DropIndex(
                name: "IX_cards_KbColumnId",
                table: "cards");

            migrationBuilder.DropIndex(
                name: "IX_cards_UserId",
                table: "cards");

            migrationBuilder.DropColumn(
                name: "KbColumnId",
                table: "cards");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "cards");

            migrationBuilder.CreateIndex(
                name: "IX_cards_IdColumn",
                table: "cards",
                column: "IdColumn");

            migrationBuilder.CreateIndex(
                name: "IX_cards_IdUser",
                table: "cards",
                column: "IdUser");

            migrationBuilder.AddForeignKey(
                name: "FK_cards_columns_IdColumn",
                table: "cards",
                column: "IdColumn",
                principalTable: "columns",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_cards_users_IdUser",
                table: "cards",
                column: "IdUser",
                principalTable: "users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_cards_columns_IdColumn",
                table: "cards");

            migrationBuilder.DropForeignKey(
                name: "FK_cards_users_IdUser",
                table: "cards");

            migrationBuilder.DropIndex(
                name: "IX_cards_IdColumn",
                table: "cards");

            migrationBuilder.DropIndex(
                name: "IX_cards_IdUser",
                table: "cards");

            migrationBuilder.AddColumn<int>(
                name: "KbColumnId",
                table: "cards",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "cards",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_cards_KbColumnId",
                table: "cards",
                column: "KbColumnId");

            migrationBuilder.CreateIndex(
                name: "IX_cards_UserId",
                table: "cards",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_cards_columns_KbColumnId",
                table: "cards",
                column: "KbColumnId",
                principalTable: "columns",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_cards_users_UserId",
                table: "cards",
                column: "UserId",
                principalTable: "users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
