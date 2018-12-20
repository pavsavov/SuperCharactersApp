using Microsoft.EntityFrameworkCore.Migrations;

namespace SuperCharacters.DataAccess.Migrations
{
    public partial class CharacterSuperPowersDeleteBehaviourSetv20 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SuperPowers_Characters_CharacterId",
                table: "SuperPowers");

            migrationBuilder.AddForeignKey(
                name: "FK_SuperPowers_Characters_CharacterId",
                table: "SuperPowers",
                column: "CharacterId",
                principalTable: "Characters",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SuperPowers_Characters_CharacterId",
                table: "SuperPowers");

            migrationBuilder.AddForeignKey(
                name: "FK_SuperPowers_Characters_CharacterId",
                table: "SuperPowers",
                column: "CharacterId",
                principalTable: "Characters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
