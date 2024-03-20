using System.ComponentModel.DataAnnotations;

namespace Cricks.Data.DbModels
{
    // Represents a group in a tournament
    public class TournamentGroup
    {
        [Key]
        public int GroupId { get; set; } // Unique identifier for the group
        public string Name { get; set; } // Name of the group
        public int TournamentId { get; set; } // Identifier for the tournament the group belongs to
        public virtual Tournament Tournament { get; set; } // The tournament the group belongs to
        public virtual ICollection<TeamStats> TeamStats { get; set; } // Collection of team stats in the group
        public string? CreatedBy { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
