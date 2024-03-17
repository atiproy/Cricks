using System.ComponentModel.DataAnnotations;

namespace Cricks.Data.DbModels
{
    // Represents a type of dismissal
    public class DismissalType
    {
        [Key]
        public int DismissalTypeId { get; set; } // Unique identifier for the type of dismissal
        public string Name { get; set; } // Name of the type of dismissal
        public virtual ICollection<Ball> Balls { get; set; } // Collection of balls associated with this type of dismissal
    }
}
