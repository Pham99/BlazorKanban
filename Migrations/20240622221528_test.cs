using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazorAppEmpty.Migrations
{
    /// <inheritdoc />
    public partial class test : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "columns",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddColumn<int>(
                name: "KbColumnId",
                table: "cards",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_cards_KbColumnId",
                table: "cards",
                column: "KbColumnId");

            migrationBuilder.AddForeignKey(
                name: "FK_cards_columns_KbColumnId",
                table: "cards",
                column: "KbColumnId",
                principalTable: "columns",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_cards_columns_KbColumnId",
                table: "cards");

            migrationBuilder.DropIndex(
                name: "IX_cards_KbColumnId",
                table: "cards");

            migrationBuilder.DropColumn(
                name: "KbColumnId",
                table: "cards");

            migrationBuilder.AlterColumn<int>(
                name: "Name",
                table: "columns",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT");
        }
    }
}
