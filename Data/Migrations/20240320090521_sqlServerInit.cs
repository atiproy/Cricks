using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class sqlServerInit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DismissalTypes",
                columns: table => new
                {
                    DismissalTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DismissalTypes", x => x.DismissalTypeId);
                });

            migrationBuilder.CreateTable(
                name: "ExtraTypes",
                columns: table => new
                {
                    ExtraTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExtraTypes", x => x.ExtraTypeId);
                });

            migrationBuilder.CreateTable(
                name: "PlayerTypes",
                columns: table => new
                {
                    PlayerTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerTypes", x => x.PlayerTypeId);
                });

            migrationBuilder.CreateTable(
                name: "Teams",
                columns: table => new
                {
                    TeamId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Colour = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teams", x => x.TeamId);
                });

            migrationBuilder.CreateTable(
                name: "Tournaments",
                columns: table => new
                {
                    TournamentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tournaments", x => x.TournamentId);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Players",
                columns: table => new
                {
                    PlayerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TeamId = table.Column<int>(type: "int", nullable: true),
                    PlayerTypeId = table.Column<int>(type: "int", nullable: false),
                    Rating = table.Column<int>(type: "int", nullable: false),
                    Comments = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsCaptain = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.PlayerId);
                    table.ForeignKey(
                        name: "FK_Players_PlayerTypes_PlayerTypeId",
                        column: x => x.PlayerTypeId,
                        principalTable: "PlayerTypes",
                        principalColumn: "PlayerTypeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Players_Teams_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Teams",
                        principalColumn: "TeamId");
                });

            migrationBuilder.CreateTable(
                name: "TournamentGroups",
                columns: table => new
                {
                    GroupId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TournamentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TournamentGroups", x => x.GroupId);
                    table.ForeignKey(
                        name: "FK_TournamentGroups_Tournaments_TournamentId",
                        column: x => x.TournamentId,
                        principalTable: "Tournaments",
                        principalColumn: "TournamentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CricketMatches",
                columns: table => new
                {
                    MatchId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Team1Id = table.Column<int>(type: "int", nullable: false),
                    Team2Id = table.Column<int>(type: "int", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Comments = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TournamentID = table.Column<int>(type: "int", nullable: true),
                    GroupID = table.Column<int>(type: "int", nullable: true),
                    Umpire1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Umpire2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Scorer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Started = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Finished = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CricketMatches", x => x.MatchId);
                    table.ForeignKey(
                        name: "FK_CricketMatches_Teams_Team1Id",
                        column: x => x.Team1Id,
                        principalTable: "Teams",
                        principalColumn: "TeamId");
                    table.ForeignKey(
                        name: "FK_CricketMatches_Teams_Team2Id",
                        column: x => x.Team2Id,
                        principalTable: "Teams",
                        principalColumn: "TeamId");
                    table.ForeignKey(
                        name: "FK_CricketMatches_TournamentGroups_GroupID",
                        column: x => x.GroupID,
                        principalTable: "TournamentGroups",
                        principalColumn: "GroupId");
                    table.ForeignKey(
                        name: "FK_CricketMatches_Tournaments_TournamentID",
                        column: x => x.TournamentID,
                        principalTable: "Tournaments",
                        principalColumn: "TournamentId");
                });

            migrationBuilder.CreateTable(
                name: "TeamStats",
                columns: table => new
                {
                    TeamStatsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TeamId = table.Column<int>(type: "int", nullable: false),
                    GroupId = table.Column<int>(type: "int", nullable: false),
                    MatchesPlayed = table.Column<int>(type: "int", nullable: false),
                    MatchesWon = table.Column<int>(type: "int", nullable: false),
                    MatchesLost = table.Column<int>(type: "int", nullable: false),
                    Points = table.Column<int>(type: "int", nullable: false),
                    RunRate = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeamStats", x => x.TeamStatsId);
                    table.ForeignKey(
                        name: "FK_TeamStats_Teams_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Teams",
                        principalColumn: "TeamId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TeamStats_TournamentGroups_GroupId",
                        column: x => x.GroupId,
                        principalTable: "TournamentGroups",
                        principalColumn: "GroupId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Innings",
                columns: table => new
                {
                    InningsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MatchId = table.Column<int>(type: "int", nullable: false),
                    BattingTeamId = table.Column<int>(type: "int", nullable: false),
                    BowlingTeamId = table.Column<int>(type: "int", nullable: false),
                    TotalRuns = table.Column<int>(type: "int", nullable: true),
                    Wickets = table.Column<int>(type: "int", nullable: true),
                    Overs = table.Column<int>(type: "int", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Innings", x => x.InningsId);
                    table.ForeignKey(
                        name: "FK_Innings_CricketMatches_MatchId",
                        column: x => x.MatchId,
                        principalTable: "CricketMatches",
                        principalColumn: "MatchId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Innings_Teams_BattingTeamId",
                        column: x => x.BattingTeamId,
                        principalTable: "Teams",
                        principalColumn: "TeamId");
                    table.ForeignKey(
                        name: "FK_Innings_Teams_BowlingTeamId",
                        column: x => x.BowlingTeamId,
                        principalTable: "Teams",
                        principalColumn: "TeamId");
                });

            migrationBuilder.CreateTable(
                name: "Balls",
                columns: table => new
                {
                    BallId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InningsId = table.Column<int>(type: "int", nullable: false),
                    OverNumber = table.Column<int>(type: "int", nullable: false),
                    BallNumber = table.Column<int>(type: "int", nullable: false),
                    BowlerId = table.Column<int>(type: "int", nullable: false),
                    BatsmanId = table.Column<int>(type: "int", nullable: false),
                    Runs = table.Column<int>(type: "int", nullable: false),
                    BatsmanRun = table.Column<int>(type: "int", nullable: false),
                    PenaltyRun = table.Column<int>(type: "int", nullable: false),
                    Bye = table.Column<int>(type: "int", nullable: false),
                    LegBye = table.Column<int>(type: "int", nullable: false),
                    IsWicket = table.Column<bool>(type: "bit", nullable: false),
                    IsRetiredHurt = table.Column<bool>(type: "bit", nullable: false),
                    IsWide = table.Column<bool>(type: "bit", nullable: false),
                    IsNoBall = table.Column<bool>(type: "bit", nullable: false),
                    DismissalTypeId = table.Column<int>(type: "int", nullable: true),
                    FielderId = table.Column<int>(type: "int", nullable: true),
                    SecondFielderId = table.Column<int>(type: "int", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Balls", x => x.BallId);
                    table.ForeignKey(
                        name: "FK_Balls_DismissalTypes_DismissalTypeId",
                        column: x => x.DismissalTypeId,
                        principalTable: "DismissalTypes",
                        principalColumn: "DismissalTypeId");
                    table.ForeignKey(
                        name: "FK_Balls_Innings_InningsId",
                        column: x => x.InningsId,
                        principalTable: "Innings",
                        principalColumn: "InningsId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Balls_Players_BatsmanId",
                        column: x => x.BatsmanId,
                        principalTable: "Players",
                        principalColumn: "PlayerId");
                    table.ForeignKey(
                        name: "FK_Balls_Players_BowlerId",
                        column: x => x.BowlerId,
                        principalTable: "Players",
                        principalColumn: "PlayerId");
                    table.ForeignKey(
                        name: "FK_Balls_Players_FielderId",
                        column: x => x.FielderId,
                        principalTable: "Players",
                        principalColumn: "PlayerId");
                    table.ForeignKey(
                        name: "FK_Balls_Players_SecondFielderId",
                        column: x => x.SecondFielderId,
                        principalTable: "Players",
                        principalColumn: "PlayerId");
                });

            migrationBuilder.CreateTable(
                name: "Extras",
                columns: table => new
                {
                    ExtraId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InningsId = table.Column<int>(type: "int", nullable: false),
                    ExtraTypeId = table.Column<int>(type: "int", nullable: false),
                    Runs = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Extras", x => x.ExtraId);
                    table.ForeignKey(
                        name: "FK_Extras_ExtraTypes_ExtraTypeId",
                        column: x => x.ExtraTypeId,
                        principalTable: "ExtraTypes",
                        principalColumn: "ExtraTypeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Extras_Innings_InningsId",
                        column: x => x.InningsId,
                        principalTable: "Innings",
                        principalColumn: "InningsId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Balls_BatsmanId",
                table: "Balls",
                column: "BatsmanId");

            migrationBuilder.CreateIndex(
                name: "IX_Balls_BowlerId",
                table: "Balls",
                column: "BowlerId");

            migrationBuilder.CreateIndex(
                name: "IX_Balls_DismissalTypeId",
                table: "Balls",
                column: "DismissalTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Balls_FielderId",
                table: "Balls",
                column: "FielderId");

            migrationBuilder.CreateIndex(
                name: "IX_Balls_InningsId",
                table: "Balls",
                column: "InningsId");

            migrationBuilder.CreateIndex(
                name: "IX_Balls_SecondFielderId",
                table: "Balls",
                column: "SecondFielderId");

            migrationBuilder.CreateIndex(
                name: "IX_CricketMatches_GroupID",
                table: "CricketMatches",
                column: "GroupID");

            migrationBuilder.CreateIndex(
                name: "IX_CricketMatches_Team1Id",
                table: "CricketMatches",
                column: "Team1Id");

            migrationBuilder.CreateIndex(
                name: "IX_CricketMatches_Team2Id",
                table: "CricketMatches",
                column: "Team2Id");

            migrationBuilder.CreateIndex(
                name: "IX_CricketMatches_TournamentID",
                table: "CricketMatches",
                column: "TournamentID");

            migrationBuilder.CreateIndex(
                name: "IX_Extras_ExtraTypeId",
                table: "Extras",
                column: "ExtraTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Extras_InningsId",
                table: "Extras",
                column: "InningsId");

            migrationBuilder.CreateIndex(
                name: "IX_Innings_BattingTeamId",
                table: "Innings",
                column: "BattingTeamId");

            migrationBuilder.CreateIndex(
                name: "IX_Innings_BowlingTeamId",
                table: "Innings",
                column: "BowlingTeamId");

            migrationBuilder.CreateIndex(
                name: "IX_Innings_MatchId",
                table: "Innings",
                column: "MatchId");

            migrationBuilder.CreateIndex(
                name: "IX_Players_PlayerTypeId",
                table: "Players",
                column: "PlayerTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Players_TeamId",
                table: "Players",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_TeamStats_GroupId",
                table: "TeamStats",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_TeamStats_TeamId",
                table: "TeamStats",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_TournamentGroups_TournamentId",
                table: "TournamentGroups",
                column: "TournamentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Balls");

            migrationBuilder.DropTable(
                name: "Extras");

            migrationBuilder.DropTable(
                name: "TeamStats");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "DismissalTypes");

            migrationBuilder.DropTable(
                name: "Players");

            migrationBuilder.DropTable(
                name: "ExtraTypes");

            migrationBuilder.DropTable(
                name: "Innings");

            migrationBuilder.DropTable(
                name: "PlayerTypes");

            migrationBuilder.DropTable(
                name: "CricketMatches");

            migrationBuilder.DropTable(
                name: "Teams");

            migrationBuilder.DropTable(
                name: "TournamentGroups");

            migrationBuilder.DropTable(
                name: "Tournaments");
        }
    }
}
