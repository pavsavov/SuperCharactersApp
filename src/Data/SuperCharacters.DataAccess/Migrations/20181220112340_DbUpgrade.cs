using Microsoft.EntityFrameworkCore.Migrations;

namespace SuperCharacters.DataAccess.Migrations
{
    public partial class DbUpgrade : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Characters_SecretIdentities_SecretIdentityId",
                table: "Characters");

            migrationBuilder.DropTable(
                name: "SuperPowersCharacters");

            migrationBuilder.DropIndex(
                name: "IX_Characters_SecretIdentityId",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "SecretIdentityId",
                table: "Characters");

            migrationBuilder.AddColumn<string>(
                name: "CharacterId",
                table: "SuperPowers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CharacterId",
                table: "SecretIdentities",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SuperPowers_CharacterId",
                table: "SuperPowers",
                column: "CharacterId");

            migrationBuilder.CreateIndex(
                name: "IX_SecretIdentities_CharacterId",
                table: "SecretIdentities",
                column: "CharacterId",
                unique: true,
                filter: "[CharacterId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_SecretIdentities_Characters_CharacterId",
                table: "SecretIdentities",
                column: "CharacterId",
                principalTable: "Characters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SuperPowers_Characters_CharacterId",
                table: "SuperPowers",
                column: "CharacterId",
                principalTable: "Characters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SecretIdentities_Characters_CharacterId",
                table: "SecretIdentities");

            migrationBuilder.DropForeignKey(
                name: "FK_SuperPowers_Characters_CharacterId",
                table: "SuperPowers");

            migrationBuilder.DropIndex(
                name: "IX_SuperPowers_CharacterId",
                table: "SuperPowers");

            migrationBuilder.DropIndex(
                name: "IX_SecretIdentities_CharacterId",
                table: "SecretIdentities");

            migrationBuilder.DropColumn(
                name: "CharacterId",
                table: "SuperPowers");

            migrationBuilder.DropColumn(
                name: "CharacterId",
                table: "SecretIdentities");

            migrationBuilder.AddColumn<string>(
                name: "SecretIdentityId",
                table: "Characters",
                nullable: true);

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
                name: "IX_Characters_SecretIdentityId",
                table: "Characters",
                column: "SecretIdentityId");

            migrationBuilder.CreateIndex(
                name: "IX_SuperPowersCharacters_SuperPowerId",
                table: "SuperPowersCharacters",
                column: "SuperPowerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Characters_SecretIdentities_SecretIdentityId",
                table: "Characters",
                column: "SecretIdentityId",
                principalTable: "SecretIdentities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
