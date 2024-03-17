using System.ComponentModel.DataAnnotations;

namespace Cricks.Data.DbModels
{
    // Represents a cricket match
    public class CricketMatch
    {
        [Key]
        public int MatchId { get; set; } // Unique identifier for the match
        public int Team1Id { get; set; } // Identifier for the first team in the match
        public virtual Team Team1 { get; set; } // The first team in the match
        public int Team2Id { get; set; } // Identifier for the second team in the match
        public virtual Team Team2 { get; set; } // The second team in the match
        public virtual ICollection<Innings> Innings { get; set; } // Collection of innings in the match
    }
}
