using Microsoft.EntityFrameworkCore.Migrations;

namespace SuperCharacters.DataAccess.Migrations
{
    public partial class HitPointsColumnBugFixed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SupervillainHitPoints",
                table: "Characters",
                newName: "SuperVillain_HitPoints");

            migrationBuilder.RenameColumn(
                name: "SuperheroHitPoints",
                table: "Characters",
                newName: "HitPoints");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SuperVillain_HitPoints",
                table: "Characters",
                newName: "SupervillainHitPoints");

            migrationBuilder.RenameColumn(
                name: "HitPoints",
                table: "Characters",
                newName: "SuperheroHitPoints");
        }
    }
}
