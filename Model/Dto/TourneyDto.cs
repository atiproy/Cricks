using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dto
{
    public class TourneyDto
    {
        public int Id { get; set; }
        public string TournamentName { get; set; }
        public string TournamentDescription { get; set; }
        public List<TournamentGroupDTO> Groups { get; set; }
    }
}
