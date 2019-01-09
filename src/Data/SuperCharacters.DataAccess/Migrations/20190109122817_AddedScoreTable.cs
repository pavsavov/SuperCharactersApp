using Microsoft.EntityFrameworkCore.Migrations;

namespace SuperCharacters.DataAccess.Migrations
{
    public partial class AddedScoreTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Score_Characters_CharacterScoreId",
                table: "Score");

            migrationBuilder.DropForeignKey(
                name: "FK_Score_AspNetUsers_PlayerScoreId",
                table: "Score");

            migrationBuilder.DropForeignKey(
                name: "FK_Score_Teams_TeamScoreId",
                table: "Score");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Score",
                table: "Score");

            migrationBuilder.RenameTable(
                name: "Score",
                newName: "Scores");

            migrationBuilder.RenameIndex(
                name: "IX_Score_TeamScoreId",
                table: "Scores",
                newName: "IX_Scores_TeamScoreId");

            migrationBuilder.RenameIndex(
                name: "IX_Score_PlayerScoreId",
                table: "Scores",
                newName: "IX_Scores_PlayerScoreId");

            migrationBuilder.RenameIndex(
                name: "IX_Score_CharacterScoreId",
                table: "Scores",
                newName: "IX_Scores_CharacterScoreId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Scores",
                table: "Scores",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "BattleStatus",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    InProgress = table.Column<string>(nullable: true),
                    Completed = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BattleStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Battles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    SuperHeroId = table.Column<string>(nullable: true),
                    SuperVillainId = table.Column<string>(nullable: true),
                    StatusId = table.Column<string>(nullable: true),
                    WinnerId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Battles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Battles_BattleStatus_StatusId",
                        column: x => x.StatusId,
                        principalTable: "BattleStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Battles_Characters_SuperHeroId",
                        column: x => x.SuperHeroId,
                        principalTable: "Characters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Battles_Characters_SuperVillainId",
                        column: x => x.SuperVillainId,
                        principalTable: "Characters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Battles_Characters_WinnerId",
                        column: x => x.WinnerId,
                        principalTable: "Characters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Battles_StatusId",
                table: "Battles",
                column: "StatusId",
                unique: true,
                filter: "[StatusId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Battles_SuperHeroId",
                table: "Battles",
                column: "SuperHeroId");

            migrationBuilder.CreateIndex(
                name: "IX_Battles_SuperVillainId",
                table: "Battles",
                column: "SuperVillainId");

            migrationBuilder.CreateIndex(
                name: "IX_Battles_WinnerId",
                table: "Battles",
                column: "WinnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Scores_Characters_CharacterScoreId",
                table: "Scores",
                column: "CharacterScoreId",
                principalTable: "Characters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Scores_AspNetUsers_PlayerScoreId",
                table: "Scores",
                column: "PlayerScoreId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Scores_Teams_TeamScoreId",
                table: "Scores",
                column: "TeamScoreId",
                principalTable: "Teams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Scores_Characters_CharacterScoreId",
                table: "Scores");

            migrationBuilder.DropForeignKey(
                name: "FK_Scores_AspNetUsers_PlayerScoreId",
                table: "Scores");

            migrationBuilder.DropForeignKey(
                name: "FK_Scores_Teams_TeamScoreId",
                table: "Scores");

            migrationBuilder.DropTable(
                name: "Battles");

            migrationBuilder.DropTable(
                name: "BattleStatus");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Scores",
                table: "Scores");

            migrationBuilder.RenameTable(
                name: "Scores",
                newName: "Score");

            migrationBuilder.RenameIndex(
                name: "IX_Scores_TeamScoreId",
                table: "Score",
                newName: "IX_Score_TeamScoreId");

            migrationBuilder.RenameIndex(
                name: "IX_Scores_PlayerScoreId",
                table: "Score",
                newName: "IX_Score_PlayerScoreId");

            migrationBuilder.RenameIndex(
                name: "IX_Scores_CharacterScoreId",
                table: "Score",
                newName: "IX_Score_CharacterScoreId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Score",
                table: "Score",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Score_Characters_CharacterScoreId",
                table: "Score",
                column: "CharacterScoreId",
                principalTable: "Characters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Score_AspNetUsers_PlayerScoreId",
                table: "Score",
                column: "PlayerScoreId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Score_Teams_TeamScoreId",
                table: "Score",
                column: "TeamScoreId",
                principalTable: "Teams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
