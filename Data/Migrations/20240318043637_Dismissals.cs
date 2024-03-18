using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class Dismissals : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "DismissalTypes",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Balls",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "Balls",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsBye",
                table: "Balls",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsLegBye",
                table: "Balls",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsRetiredHurt",
                table: "Balls",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "SecondFielderId",
                table: "Balls",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Balls_SecondFielderId",
                table: "Balls",
                column: "SecondFielderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Balls_Players_SecondFielderId",
                table: "Balls",
                column: "SecondFielderId",
                principalTable: "Players",
                principalColumn: "PlayerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Balls_Players_SecondFielderId",
                table: "Balls");

            migrationBuilder.DropIndex(
                name: "IX_Balls_SecondFielderId",
                table: "Balls");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "DismissalTypes");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Balls");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "Balls");

            migrationBuilder.DropColumn(
                name: "IsBye",
                table: "Balls");

            migrationBuilder.DropColumn(
                name: "IsLegBye",
                table: "Balls");

            migrationBuilder.DropColumn(
                name: "IsRetiredHurt",
                table: "Balls");

            migrationBuilder.DropColumn(
                name: "SecondFielderId",
                table: "Balls");
        }
    }
}
