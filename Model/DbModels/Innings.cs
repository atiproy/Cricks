using System.ComponentModel.DataAnnotations;

namespace Cricks.Data.DbModels
{
    // Represents an innings of a cricket match
    public class Innings
    {
        [Key]
        public int InningsId { get; set; } // Unique identifier for the innings
        public int MatchId { get; set; } // Identifier for the match the innings belongs to
        public virtual CricketMatch Match { get; set; } // The match the innings belongs to
        public int BattingTeamId { get; set; } // Identifier for the batting team in the innings
        public virtual Team BattingTeam { get; set; } // The batting team in the innings
        public int BowlingTeamId { get; set; } // Identifier for the bowling team in the innings
        public virtual Team BowlingTeam { get; set; } // The bowling team in the innings
        public virtual ICollection<Ball> Balls { get; set; } // Collection of balls bowled in the innings
        public int? TotalRuns { get; set; } // The total runs scored in the innings
        public int? Wickets { get; set; } // The number of wickets lost in the innings
        public int? Overs { get; set; } // The number of overs bowled in the innings
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }

    }
}
