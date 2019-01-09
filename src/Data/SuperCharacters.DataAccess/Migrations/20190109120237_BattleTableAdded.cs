using Microsoft.EntityFrameworkCore.Migrations;

namespace SuperCharacters.DataAccess.Migrations
{
    public partial class BattleTableAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Characters_SecretIdentities_SecretIdentityId",
                table: "Characters");

            migrationBuilder.AddForeignKey(
                name: "FK_Characters_SecretIdentities_SecretIdentityId",
                table: "Characters",
                column: "SecretIdentityId",
                principalTable: "SecretIdentities",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Characters_SecretIdentities_SecretIdentityId",
                table: "Characters");

            migrationBuilder.AddForeignKey(
                name: "FK_Characters_SecretIdentities_SecretIdentityId",
                table: "Characters",
                column: "SecretIdentityId",
                principalTable: "SecretIdentities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
