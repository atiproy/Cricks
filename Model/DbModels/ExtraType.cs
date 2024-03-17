using System.ComponentModel.DataAnnotations;

namespace Cricks.Data.DbModels
{
    // Represents a type of extra run
    public class ExtraType
    {
        [Key]
        public int ExtraTypeId { get; set; } // Unique identifier for the type of extra run
        public string Name { get; set; } // Name of the type of extra run
        public virtual ICollection<Extra> Extras { get; set; } // Collection of extra runs associated with this type
    }
}
