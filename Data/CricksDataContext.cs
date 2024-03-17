using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Cricks.Data.DbModels;
using System.Collections.Generic;
using System.Numerics;
using System.Reflection.Emit;
using System.Text.RegularExpressions;

namespace Cricks.Data
{
    // Inherits from IdentityDbContext to include Identity related tables
    public class CricksDataContext : IdentityDbContext
    {
        public CricksDataContext(DbContextOptions<CricksDataContext> options)
            : base(options)
        {
        }

        // DbSets for your models
        public DbSet<Player> Players { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<CricketMatch> CricketMatches { get; set; }
        public DbSet<Innings> Innings { get; set; }
        public DbSet<Ball> Balls { get; set; }
        public DbSet<DismissalType> DismissalTypes { get; set; }
        public DbSet<ExtraType> ExtraTypes { get; set; }
        public DbSet<Extra> Extras { get; set; }
        public DbSet<PlayerType> PlayerTypes { get; set; }
        public DbSet<TournamentGroup> TournamentGroups { get; set; }
        public DbSet<TeamStats> TeamStats { get; set; }
        public DbSet<Tournament> Tournaments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure relationships between your models here
            // For example:
            // modelBuilder.Entity<Team>()
            //     .HasMany(t => t.Players)
            //     .WithOne(p => p.Team)
            //     .HasForeignKey(p => p.TeamId);
        }
    }
}
