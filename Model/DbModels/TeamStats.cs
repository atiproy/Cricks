using System.ComponentModel.DataAnnotations;

namespace Cricks.Data.DbModels
{
    // Represents the stats of a team in a group
    public class TeamStats
    {
        [Key]
        public int TeamStatsId { get; set; } // Unique identifier for the team stats
        public int TeamId { get; set; } // Identifier for the team the stats belong to
        public virtual Team Team { get; set; } // The team the stats belong to
        public int GroupId { get; set; } // Identifier for the group the stats belong to
        public virtual TournamentGroup Group { get; set; } // The group the stats belong to
        public int MatchesPlayed { get; set; } // Number of matches played by the team
        public int MatchesWon { get; set; } // Number of matches won by the team
        public int MatchesLost { get; set; } // Number of matches lost by the team
        public int Points { get; set; } // Points earned by the team
        public decimal RunRate { get; set; } // Run rate of the team
    }
}
