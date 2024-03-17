using System.ComponentModel.DataAnnotations;

namespace Cricks.Data.DbModels
{
    // Represents a cricket team
    public class Team
    {
        [Key]
        public int TeamId { get; set; } // Unique identifier for the team
        public string Name { get; set; } // Name of the team
        public virtual ICollection<Player> Players { get; set; } // Collection of players in the team
    }
}
