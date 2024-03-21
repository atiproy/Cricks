﻿// <auto-generated />
using System;
using Cricks.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Data.Migrations
{
    [DbContext(typeof(CricksDataContext))]
    [Migration("20240320141252_aLot")]
    partial class aLot
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Cricks.Data.DbModels.Ball", b =>
                {
                    b.Property<int>("BallId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BallId"));

                    b.Property<int>("BallNumber")
                        .HasColumnType("int");

                    b.Property<int>("BatsmanId")
                        .HasColumnType("int");

                    b.Property<int>("BatsmanRun")
                        .HasColumnType("int");

                    b.Property<int>("BowlerId")
                        .HasColumnType("int");

                    b.Property<int>("Bye")
                        .HasColumnType("int");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<int?>("DismissalTypeId")
                        .HasColumnType("int");

                    b.Property<int?>("FielderId")
                        .HasColumnType("int");

                    b.Property<int>("InningsId")
                        .HasColumnType("int");

                    b.Property<bool>("IsNoBall")
                        .HasColumnType("bit");

                    b.Property<bool>("IsRetiredHurt")
                        .HasColumnType("bit");

                    b.Property<bool>("IsWicket")
                        .HasColumnType("bit");

                    b.Property<bool>("IsWide")
                        .HasColumnType("bit");

                    b.Property<int>("LegBye")
                        .HasColumnType("int");

                    b.Property<int>("OverNumber")
                        .HasColumnType("int");

                    b.Property<int>("PenaltyRun")
                        .HasColumnType("int");

                    b.Property<int>("Runs")
                        .HasColumnType("int");

                    b.Property<int?>("SecondFielderId")
                        .HasColumnType("int");

                    b.HasKey("BallId");

                    b.HasIndex("BatsmanId");

                    b.HasIndex("BowlerId");

                    b.HasIndex("DismissalTypeId");

                    b.HasIndex("FielderId");

                    b.HasIndex("InningsId");

                    b.HasIndex("SecondFielderId");

                    b.ToTable("Balls");
                });

            modelBuilder.Entity("Cricks.Data.DbModels.CricketMatch", b =>
                {
                    b.Property<int>("MatchId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MatchId"));

                    b.Property<string>("Comments")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("Finished")
                        .HasColumnType("datetime2");

                    b.Property<int?>("GroupID")
                        .HasColumnType("int");

                    b.Property<bool?>("IsDrawn")
                        .HasColumnType("bit");

                    b.Property<string>("Location")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Scorer")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("Started")
                        .HasColumnType("datetime2");

                    b.Property<int?>("Team1Balls")
                        .HasColumnType("int");

                    b.Property<int>("Team1Id")
                        .HasColumnType("int");

                    b.Property<int?>("Team1Score")
                        .HasColumnType("int");

                    b.Property<bool?>("Team1TossWin")
                        .HasColumnType("bit");

                    b.Property<bool>("Team1Winner")
                        .HasColumnType("bit");

                    b.Property<int?>("Team2Balls")
                        .HasColumnType("int");

                    b.Property<int>("Team2Id")
                        .HasColumnType("int");

                    b.Property<int?>("Team2Score")
                        .HasColumnType("int");

                    b.Property<int?>("TournamentID")
                        .HasColumnType("int");

                    b.Property<string>("Umpire1")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Umpire2")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MatchId");

                    b.HasIndex("GroupID");

                    b.HasIndex("Team1Id");

                    b.HasIndex("Team2Id");

                    b.HasIndex("TournamentID");

                    b.ToTable("CricketMatches");
                });

            modelBuilder.Entity("Cricks.Data.DbModels.DismissalType", b =>
                {
                    b.Property<int>("DismissalTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DismissalTypeId"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DismissalTypeId");

                    b.ToTable("DismissalTypes");
                });

            modelBuilder.Entity("Cricks.Data.DbModels.Extra", b =>
                {
                    b.Property<int>("ExtraId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ExtraId"));

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("ExtraTypeId")
                        .HasColumnType("int");

                    b.Property<int>("InningsId")
                        .HasColumnType("int");

                    b.Property<string>("ModifiedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Runs")
                        .HasColumnType("int");

                    b.HasKey("ExtraId");

                    b.HasIndex("ExtraTypeId");

                    b.HasIndex("InningsId");

                    b.ToTable("Extras");
                });

            modelBuilder.Entity("Cricks.Data.DbModels.ExtraType", b =>
                {
                    b.Property<int>("ExtraTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ExtraTypeId"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ExtraTypeId");

                    b.ToTable("ExtraTypes");
                });

            modelBuilder.Entity("Cricks.Data.DbModels.Innings", b =>
                {
                    b.Property<int>("InningsId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("InningsId"));

                    b.Property<int>("BattingTeamId")
                        .HasColumnType("int");

                    b.Property<int>("BowlingTeamId")
                        .HasColumnType("int");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("MatchId")
                        .HasColumnType("int");

                    b.Property<string>("ModifiedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("Overs")
                        .HasColumnType("int");

                    b.Property<int?>("TotalRuns")
                        .HasColumnType("int");

                    b.Property<int?>("Wickets")
                        .HasColumnType("int");

                    b.HasKey("InningsId");

                    b.HasIndex("BattingTeamId");

                    b.HasIndex("BowlingTeamId");

                    b.HasIndex("MatchId");

                    b.ToTable("Innings");
                });

            modelBuilder.Entity("Cricks.Data.DbModels.Player", b =>
                {
                    b.Property<int>("PlayerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PlayerId"));

                    b.Property<string>("Comments")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsCaptain")
                        .HasColumnType("bit");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("PlayerTypeId")
                        .HasColumnType("int");

                    b.Property<int?>("Rating")
                        .HasColumnType("int");

                    b.Property<int?>("TeamId")
                        .HasColumnType("int");

                    b.HasKey("PlayerId");

                    b.HasIndex("PlayerTypeId");

                    b.HasIndex("TeamId");

                    b.ToTable("Players");
                });

            modelBuilder.Entity("Cricks.Data.DbModels.PlayerType", b =>
                {
                    b.Property<int>("PlayerTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PlayerTypeId"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PlayerTypeId");

                    b.ToTable("PlayerTypes");
                });

            modelBuilder.Entity("Cricks.Data.DbModels.Team", b =>
                {
                    b.Property<int>("TeamId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TeamId"));

                    b.Property<string>("Colour")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TeamId");

                    b.ToTable("Teams");
                });

            modelBuilder.Entity("Cricks.Data.DbModels.TeamStats", b =>
                {
                    b.Property<int>("TeamStatsId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TeamStatsId"));

                    b.Property<int>("GroupId")
                        .HasColumnType("int");

                    b.Property<int>("MatchesLost")
                        .HasColumnType("int");

                    b.Property<int>("MatchesPlayed")
                        .HasColumnType("int");

                    b.Property<int>("MatchesWon")
                        .HasColumnType("int");

                    b.Property<int>("Points")
                        .HasColumnType("int");

                    b.Property<decimal>("RunRate")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("TeamId")
                        .HasColumnType("int");

                    b.HasKey("TeamStatsId");

                    b.HasIndex("GroupId");

                    b.HasIndex("TeamId");

                    b.ToTable("TeamStats");
                });

            modelBuilder.Entity("Cricks.Data.DbModels.Tournament", b =>
                {
                    b.Property<int>("TournamentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TournamentId"));

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TournamentId");

                    b.ToTable("Tournaments");
                });

            modelBuilder.Entity("Cricks.Data.DbModels.TournamentGroup", b =>
                {
                    b.Property<int>("GroupId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("GroupId"));

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ModifiedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TournamentId")
                        .HasColumnType("int");

                    b.HasKey("GroupId");

                    b.HasIndex("TournamentId");

                    b.ToTable("TournamentGroups");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("Cricks.Data.DbModels.Ball", b =>
                {
                    b.HasOne("Cricks.Data.DbModels.Player", "Batsman")
                        .WithMany("BatsmanBalls")
                        .HasForeignKey("BatsmanId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Cricks.Data.DbModels.Player", "Bowler")
                        .WithMany("BowlerBalls")
                        .HasForeignKey("BowlerId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Cricks.Data.DbModels.DismissalType", "DismissalType")
                        .WithMany("Balls")
                        .HasForeignKey("DismissalTypeId");

                    b.HasOne("Cricks.Data.DbModels.Player", "Fielder")
                        .WithMany("FielderBalls")
                        .HasForeignKey("FielderId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("Cricks.Data.DbModels.Innings", "Innings")
                        .WithMany("Balls")
                        .HasForeignKey("InningsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Cricks.Data.DbModels.Player", "SecondFielder")
                        .WithMany()
                        .HasForeignKey("SecondFielderId");

                    b.Navigation("Batsman");

                    b.Navigation("Bowler");

                    b.Navigation("DismissalType");

                    b.Navigation("Fielder");

                    b.Navigation("Innings");

                    b.Navigation("SecondFielder");
                });

            modelBuilder.Entity("Cricks.Data.DbModels.CricketMatch", b =>
                {
                    b.HasOne("Cricks.Data.DbModels.TournamentGroup", "Group")
                        .WithMany()
                        .HasForeignKey("GroupID");

                    b.HasOne("Cricks.Data.DbModels.Team", "Team1")
                        .WithMany("CricketMatchesAsTeam1")
                        .HasForeignKey("Team1Id")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Cricks.Data.DbModels.Team", "Team2")
                        .WithMany("CricketMatchesAsTeam2")
                        .HasForeignKey("Team2Id")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Cricks.Data.DbModels.Tournament", "Tournament")
                        .WithMany("Matches")
                        .HasForeignKey("TournamentID");

                    b.Navigation("Group");

                    b.Navigation("Team1");

                    b.Navigation("Team2");

                    b.Navigation("Tournament");
                });

            modelBuilder.Entity("Cricks.Data.DbModels.Extra", b =>
                {
                    b.HasOne("Cricks.Data.DbModels.ExtraType", "ExtraType")
                        .WithMany("Extras")
                        .HasForeignKey("ExtraTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Cricks.Data.DbModels.Innings", "Innings")
                        .WithMany()
                        .HasForeignKey("InningsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ExtraType");

                    b.Navigation("Innings");
                });

            modelBuilder.Entity("Cricks.Data.DbModels.Innings", b =>
                {
                    b.HasOne("Cricks.Data.DbModels.Team", "BattingTeam")
                        .WithMany("InningsAsBattingTeam")
                        .HasForeignKey("BattingTeamId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Cricks.Data.DbModels.Team", "BowlingTeam")
                        .WithMany("InningsAsBowlingTeam")
                        .HasForeignKey("BowlingTeamId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Cricks.Data.DbModels.CricketMatch", "Match")
                        .WithMany("Innings")
                        .HasForeignKey("MatchId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BattingTeam");

                    b.Navigation("BowlingTeam");

                    b.Navigation("Match");
                });

            modelBuilder.Entity("Cricks.Data.DbModels.Player", b =>
                {
                    b.HasOne("Cricks.Data.DbModels.PlayerType", "PlayerType")
                        .WithMany("Players")
                        .HasForeignKey("PlayerTypeId");

                    b.HasOne("Cricks.Data.DbModels.Team", "Team")
                        .WithMany("Players")
                        .HasForeignKey("TeamId");

                    b.Navigation("PlayerType");

                    b.Navigation("Team");
                });

            modelBuilder.Entity("Cricks.Data.DbModels.TeamStats", b =>
                {
                    b.HasOne("Cricks.Data.DbModels.TournamentGroup", "Group")
                        .WithMany("TeamStats")
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Cricks.Data.DbModels.Team", "Team")
                        .WithMany()
                        .HasForeignKey("TeamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Group");

                    b.Navigation("Team");
                });

            modelBuilder.Entity("Cricks.Data.DbModels.TournamentGroup", b =>
                {
                    b.HasOne("Cricks.Data.DbModels.Tournament", "Tournament")
                        .WithMany("Groups")
                        .HasForeignKey("TournamentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Tournament");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Cricks.Data.DbModels.CricketMatch", b =>
                {
                    b.Navigation("Innings");
                });

            modelBuilder.Entity("Cricks.Data.DbModels.DismissalType", b =>
                {
                    b.Navigation("Balls");
                });

            modelBuilder.Entity("Cricks.Data.DbModels.ExtraType", b =>
                {
                    b.Navigation("Extras");
                });

            modelBuilder.Entity("Cricks.Data.DbModels.Innings", b =>
                {
                    b.Navigation("Balls");
                });

            modelBuilder.Entity("Cricks.Data.DbModels.Player", b =>
                {
                    b.Navigation("BatsmanBalls");

                    b.Navigation("BowlerBalls");

                    b.Navigation("FielderBalls");
                });

            modelBuilder.Entity("Cricks.Data.DbModels.PlayerType", b =>
                {
                    b.Navigation("Players");
                });

            modelBuilder.Entity("Cricks.Data.DbModels.Team", b =>
                {
                    b.Navigation("CricketMatchesAsTeam1");

                    b.Navigation("CricketMatchesAsTeam2");

                    b.Navigation("InningsAsBattingTeam");

                    b.Navigation("InningsAsBowlingTeam");

                    b.Navigation("Players");
                });

            modelBuilder.Entity("Cricks.Data.DbModels.Tournament", b =>
                {
                    b.Navigation("Groups");

                    b.Navigation("Matches");
                });

            modelBuilder.Entity("Cricks.Data.DbModels.TournamentGroup", b =>
                {
                    b.Navigation("TeamStats");
                });
#pragma warning restore 612, 618
        }
    }
}
