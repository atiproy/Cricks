using Cricks.Data.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dto
{
    public class TournamentGroupDTO
    {
        public int GroupID { get; set; }
        public string Name { get; set; }
        public List<TeamStats> TeamStats { get; set; }


    }
}
