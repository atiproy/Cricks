using Cricks.Data.DbModels;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

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

            modelBuilder.Entity<CricketMatch>()
                .HasOne(cm => cm.Team1)
                .WithMany(t => t.CricketMatchesAsTeam1)
                .HasForeignKey(cm => cm.Team1Id)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<CricketMatch>()
                .HasOne(cm => cm.Team2)
                .WithMany(t => t.CricketMatchesAsTeam2)
                .HasForeignKey(cm => cm.Team2Id)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Innings>()
                .HasOne(i => i.BattingTeam)
                .WithMany(t => t.InningsAsBattingTeam)
                .HasForeignKey(i => i.BattingTeamId)
                .OnDelete(DeleteBehavior.NoAction); // or .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Innings>()
                .HasOne(i => i.BowlingTeam)
                .WithMany(t => t.InningsAsBowlingTeam)
                .HasForeignKey(i => i.BowlingTeamId)
                .OnDelete(DeleteBehavior.NoAction); // or .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Ball>()
                .HasOne(b => b.Batsman)
                .WithMany(p => p.BatsmanBalls)
                .HasForeignKey(b => b.BatsmanId)
                .OnDelete(DeleteBehavior.NoAction); // or .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Ball>()
                .HasOne(b => b.Bowler)
                .WithMany(p => p.BowlerBalls)
                .HasForeignKey(b => b.BowlerId)
                .OnDelete(DeleteBehavior.NoAction); // or .OnDelete(DeleteBehavior.SetNull);


            modelBuilder.Entity<Ball>()
               .HasOne(b => b.Fielder)
               .WithMany(p => p.FielderBalls)
               .HasForeignKey(b => b.FielderId)
               .OnDelete(DeleteBehavior.NoAction); // or .OnDelete(DeleteBehavior.SetNull);


        }
    }
}
