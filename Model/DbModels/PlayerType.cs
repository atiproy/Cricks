using System.ComponentModel.DataAnnotations;

namespace Cricks.Data.DbModels
{
    // Represents a type of player (e.g., Batsman, Bowler, All-Rounder)
    public class PlayerType
    {
        [Key]
        public int PlayerTypeId { get; set; } // Unique identifier for the player type
        public string Name { get; set; } // Name of the player type
        public virtual ICollection<Player> Players { get; set; } // Collection of players of this type
    }
}
