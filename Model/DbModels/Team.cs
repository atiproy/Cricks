using System.ComponentModel.DataAnnotations;

namespace Cricks.Data.DbModels
{
    // Represents a cricket team
    public class Team
    {
        [Key]
        public int TeamId { get; set; } // Unique identifier for the team
        public string Name { get; set; } // Name of the team
        public string Colour { get; set; }
        public int? Captain { get; set; } // Identifier for the captain of the team
        public virtual Player CaptainPlayer { get; set; } // The captain of the team
        public virtual ICollection<Player> Players { get; set; } // Collection of players in the team
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
