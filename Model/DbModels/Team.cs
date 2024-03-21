using System.ComponentModel.DataAnnotations;

namespace Cricks.Data.DbModels
{
    public class Team
    {
        [Key]
        public int TeamId { get; set; } // Unique identifier for the team
        public string Name { get; set; } // Name of the team
        public string? Colour { get; set; }
        public virtual ICollection<Player> Players { get; set; } // Collection of players in the team
        public virtual ICollection<CricketMatch> CricketMatchesAsTeam1 { get; set; } // Matches where this team is Team1
        public virtual ICollection<CricketMatch> CricketMatchesAsTeam2 { get; set; } // Matches where this team is Team2
        public virtual ICollection<Innings> InningsAsBattingTeam { get; set; } // Innings where this team is the batting team
        public virtual ICollection<Innings> InningsAsBowlingTeam { get; set; } // Innings where this team is the bowling team
        public int? GroupId { get; set; }
        public virtual  TournamentGroup? TournamentGroup { get; set; }
        public string? CreatedBy { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
