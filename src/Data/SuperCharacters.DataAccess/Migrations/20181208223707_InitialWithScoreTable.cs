using Microsoft.EntityFrameworkCore.Migrations;

namespace SuperCharacters.DataAccess.Migrations
{
    public partial class InitialWithScoreTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Score",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Wins = table.Column<int>(nullable: false),
                    Loses = table.Column<int>(nullable: false),
                    CharacterScoreId = table.Column<string>(nullable: true),
                    TeamScoreId = table.Column<string>(nullable: true),
                    PlayerScoreId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Score", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Score_Characters_CharacterScoreId",
                        column: x => x.CharacterScoreId,
                        principalTable: "Characters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Score_AspNetUsers_PlayerScoreId",
                        column: x => x.PlayerScoreId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Score_Teams_TeamScoreId",
                        column: x => x.TeamScoreId,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Score_CharacterScoreId",
                table: "Score",
                column: "CharacterScoreId",
                unique: true,
                filter: "[CharacterScoreId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Score_PlayerScoreId",
                table: "Score",
                column: "PlayerScoreId",
                unique: true,
                filter: "[PlayerScoreId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Score_TeamScoreId",
                table: "Score",
                column: "TeamScoreId",
                unique: true,
                filter: "[TeamScoreId] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Score");
        }
    }
}
