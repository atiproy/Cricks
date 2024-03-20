using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class Team2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GroupId",
                table: "Teams",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TournamentGroupGroupId",
                table: "Teams",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Teams_TournamentGroupGroupId",
                table: "Teams",
                column: "TournamentGroupGroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_Teams_TournamentGroups_TournamentGroupGroupId",
                table: "Teams",
                column: "TournamentGroupGroupId",
                principalTable: "TournamentGroups",
                principalColumn: "GroupId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Teams_TournamentGroups_TournamentGroupGroupId",
                table: "Teams");

            migrationBuilder.DropIndex(
                name: "IX_Teams_TournamentGroupGroupId",
                table: "Teams");

            migrationBuilder.DropColumn(
                name: "GroupId",
                table: "Teams");

            migrationBuilder.DropColumn(
                name: "TournamentGroupGroupId",
                table: "Teams");
        }
    }
}
