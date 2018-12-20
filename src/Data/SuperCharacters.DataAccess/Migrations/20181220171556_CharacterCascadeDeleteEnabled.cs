using Microsoft.EntityFrameworkCore.Migrations;

namespace SuperCharacters.DataAccess.Migrations
{
    public partial class CharacterCascadeDeleteEnabled : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SecretIdentities_Characters_CharacterId",
                table: "SecretIdentities");

            migrationBuilder.DropIndex(
                name: "IX_Score_CharacterScoreId",
                table: "Score");

            migrationBuilder.CreateIndex(
                name: "IX_Score_CharacterScoreId",
                table: "Score",
                column: "CharacterScoreId");

            migrationBuilder.AddForeignKey(
                name: "FK_SecretIdentities_Characters_CharacterId",
                table: "SecretIdentities",
                column: "CharacterId",
                principalTable: "Characters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SecretIdentities_Characters_CharacterId",
                table: "SecretIdentities");

            migrationBuilder.DropIndex(
                name: "IX_Score_CharacterScoreId",
                table: "Score");

            migrationBuilder.CreateIndex(
                name: "IX_Score_CharacterScoreId",
                table: "Score",
                column: "CharacterScoreId",
                unique: true,
                filter: "[CharacterScoreId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_SecretIdentities_Characters_CharacterId",
                table: "SecretIdentities",
                column: "CharacterId",
                principalTable: "Characters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
