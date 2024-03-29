using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Cricks.Data.DbModels
{
    public class Player
    {
        [Key]
        public int PlayerId { get; set; } // Unique identifier for the player
        public string Name { get; set; } // Name of the player
        public int? TeamId { get; set; } // Identifier for the team the player belongs to
        public virtual Team? Team { get; set; } // The team the player belongs to
        public int? PlayerTypeId { get; set; } // Identifier for the type of player
        public virtual PlayerType PlayerType { get; set; } // The type of player
        public int? Rating { get; set; }
        public string? Comments { get; set; }
        public string? CreatedBy { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public bool IsCaptain { get; set; }
        public virtual ICollection<Ball> BatsmanBalls { get; set; } // Balls where this player is the batsman
        public virtual ICollection<Ball> BowlerBalls { get; set; } // Balls where this player is the bowler
        public virtual ICollection<Ball> FielderBalls { get; set; } // Balls where this player is the fielder
    }
}
