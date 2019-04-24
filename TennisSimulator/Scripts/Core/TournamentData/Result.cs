using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TennisSimulator.Scripts.Core.TournamentData
{
    class Result
    {
        public int order { get; set; }
        public int player_id { get; set; }
        public int gained_experience { get; set; }
        public int total_experience { get; set; }
    }
}
