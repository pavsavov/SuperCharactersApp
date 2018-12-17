using Microsoft.EntityFrameworkCore.Migrations;

namespace SuperCharacters.DataAccess.Migrations
{
    public partial class AddedJunctionTableManagingCharacterAndSuperPowersRelations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SuperPowers_Characters_CharacterId",
                table: "SuperPowers");

            migrationBuilder.DropIndex(
                name: "IX_SuperPowers_CharacterId",
                table: "SuperPowers");

            migrationBuilder.DropColumn(
                name: "CharacterId",
                table: "SuperPowers");

            migrationBuilder.CreateTable(
                name: "SuperPowersCharacters",
                columns: table => new
                {
                    CharacterId = table.Column<string>(nullable: false),
                    SuperPowerId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SuperPowersCharacters", x => new { x.CharacterId, x.SuperPowerId });
                    table.ForeignKey(
                        name: "FK_SuperPowersCharacters_Characters_CharacterId",
                        column: x => x.CharacterId,
                        principalTable: "Characters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SuperPowersCharacters_SuperPowers_SuperPowerId",
                        column: x => x.SuperPowerId,
                        principalTable: "SuperPowers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SuperPowersCharacters_SuperPowerId",
                table: "SuperPowersCharacters",
                column: "SuperPowerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SuperPowersCharacters");

            migrationBuilder.AddColumn<string>(
                name: "CharacterId",
                table: "SuperPowers",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SuperPowers_CharacterId",
                table: "SuperPowers",
                column: "CharacterId");

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
