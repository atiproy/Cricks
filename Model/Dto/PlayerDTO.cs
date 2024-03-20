using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dto
{
    public class PlayerDTO
    {
        public int PlayerId { get; set; }
        public string Name { get; set; }
        public int? TeamId { get; set; }
        public int? PlayerTypeId { get; set; }
        public int? Rating { get; set; }
        public string? Comments { get; set; }
        public string? CreatedBy { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public bool IsCaptain { get; set; }
    }

}
