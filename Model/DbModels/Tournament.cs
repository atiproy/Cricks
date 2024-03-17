using System.ComponentModel.DataAnnotations;

namespace Cricks.Data.DbModels
{
    // Represents a cricket tournament
    public class Tournament
    {
        [Key]
        public int TournamentId { get; set; } // Unique identifier for the tournament
        public string Name { get; set; } // Name of the tournament
        public virtual ICollection<TournamentGroup> Groups { get; set; } // Collection of groups in the tournament
    }
}
