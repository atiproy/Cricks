using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dto
{
    public class GroupTeamDetailsDTO
    {
        public string TeamName { get; set; }
        public int MatchesPlayed { get; set; }
        public int Won { get; set; }
        public int Lost { get; set; }
        public int Points { get; set; }
        public decimal RunRate { get; set; }
    }


}
