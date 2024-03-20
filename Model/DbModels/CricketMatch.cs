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
        public string? Location { get; set; } // Location of the match
        public string? Comments { get; set; } // Comments about the match
        public int? TournamentID { get; set; } // Identifier for the tournament the match belongs to
        public virtual Tournament Tournament { get; set; } // The tournament the match belongs to
        public int? GroupID { get; set; } // Identifier for the group the match belongs to
        public virtual TournamentGroup Group { get; set; } // The group the match belongs to
        public string? Umpire1 { get; set; } // The first umpire for the match
        public string? Umpire2 { get; set; } // The second umpire for the match
        public string? Scorer { get; set; } // The scorer for the match
        public int? Team1Score { get; set; }
        public int? Team1Balls { get; set; }
        public int? Team2Score { get; set; }
        public int? Team2Balls { get; set; }
        public bool? Team1TossWin { get; set; } // 
        public DateTime? Started { get; set; } // The date and time the match started
        public DateTime? Finished { get; set; } // The date and time the match finished
        public bool? IsDrawn { get; set; }
        public bool Team1Winner { get; set; }
        public string? CreatedBy { get; set; } // The user who created the match
        public string? ModifiedBy { get; set; } // The user who last modified the match
        public DateTime? CreatedDate { get; set; } // The date and time the match was created
        public DateTime? ModifiedDate { get; set; } // The date and time the match was last modified

    }
}
