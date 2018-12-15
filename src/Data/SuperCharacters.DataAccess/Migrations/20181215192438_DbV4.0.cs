using Microsoft.EntityFrameworkCore.Migrations;

namespace SuperCharacters.DataAccess.Migrations
{
    public partial class DbV40 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Characters_SecretIdentityId",
                table: "Characters");

            migrationBuilder.CreateIndex(
                name: "IX_Characters_SecretIdentityId",
                table: "Characters",
                column: "SecretIdentityId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Characters_SecretIdentityId",
                table: "Characters");

            migrationBuilder.CreateIndex(
                name: "IX_Characters_SecretIdentityId",
                table: "Characters",
                column: "SecretIdentityId",
                unique: true,
                filter: "[SecretIdentityId] IS NOT NULL");
        }
    }
}
