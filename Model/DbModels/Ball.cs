using System.ComponentModel.DataAnnotations;

namespace Cricks.Data.DbModels
{
    // Represents a ball bowled in an innings
    public class Ball
    {
        [Key]
        public int BallId { get; set; } // Unique identifier for the ball
        public int InningsId { get; set; } // Identifier for the innings the ball belongs to
        public virtual Innings Innings { get; set; } // The innings the ball belongs to
        public int BowlerId { get; set; } // Identifier for the player who bowled the ball
        public virtual Player Bowler { get; set; } // The player who bowled the ball
        public int BatsmanId { get; set; } // Identifier for the player who faced the ball
        public virtual Player Batsman { get; set; } // The player who faced the ball
        public int Runs { get; set; } // Runs scored from the ball
        public bool IsWicket { get; set; } // Whether a wicket fell on the ball
        public bool IsWide { get; set; } // Whether the ball was a wide
        public bool IsNoBall { get; set; } // Whether the ball was a no ball
        public int? DismissalTypeId { get; set; } // Identifier for the type of dismissal, if any
        public virtual DismissalType DismissalType { get; set; } // The type of dismissal, if any
        public int? FielderId { get; set; } // Identifier for the fielder involved in the dismissal, if any
        public virtual Player Fielder { get; set; } // The fielder involved in the dismissal, if any
    }
}
