using System.ComponentModel.DataAnnotations;

namespace Cricks.Data.DbModels
{
    // Represents a cricket tournament
    public class Tournament
    {
        [Key]
        public int TournamentId { get; set; } // Unique identifier for the tournament
        public string Name { get; set; } // Name of the tournament
        public string? Description { get; set; } // Description of the tournament
        public virtual ICollection<TournamentGroup> Groups { get; set; } // Collection of groups in the tournament
        public virtual ICollection<CricketMatch> Matches { get; set; } // Collection of matches in the tournament
        public string? CreatedBy { get; set; } // User who created the tournament
        public string? ModifiedBy { get; set; } // User who last modified the tournament
        public DateTime? CreatedDate { get; set; } // Date and time the tournament was created
        public DateTime? ModifiedDate { get; set; } // Date and time the tournament was last modified

    }
}
