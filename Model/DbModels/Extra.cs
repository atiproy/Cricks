using System.ComponentModel.DataAnnotations;

namespace Cricks.Data.DbModels
{
    // Represents an extra run in an innings
    public class Extra
    {
        [Key]
        public int ExtraId { get; set; } // Unique identifier for the extra run
        public int InningsId { get; set; } // Identifier for the innings the extra run belongs to
        public virtual Innings Innings { get; set; } // The innings the extra run belongs to
        public int ExtraTypeId { get; set; } // Identifier for the type of extra run
        public virtual ExtraType ExtraType { get; set; } // The type of extra run
        public int Runs { get; set; } // The number of extra runs
    }
}
