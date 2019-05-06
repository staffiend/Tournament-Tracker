using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackerLibrary
{
    public class MatchupModel
    {
        /// <summary>
        /// Represents matchups of teams entered in tournament.
        /// </summary>
        public List<MatchupEntryModel> Entries { get; set; } = new List<MatchupEntryModel>();

        /// <summary>
        /// Represents the winning team of this matchup.
        /// </summary>
        public TeamModel Winner { get; set; }

        /// <summary>
        /// Represents the round the matchup is taking place in.
        /// </summary>
        public int MatchupRound { get; set; }
    }
}
