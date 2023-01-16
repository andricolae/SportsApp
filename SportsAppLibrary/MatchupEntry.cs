using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsAppLibrary
{
    public class MatchupEntry
    {
        public int Id { get; set; }
        public int TeamCompetingId { get; set; }
        /// <summary>
        /// Models a team in a match of the competition
        /// </summary>
        public Team Team { get; set; }
        /// <summary>
        /// Sets the score for this team in the particular game
        /// </summary>
        public double Score { get; set; }
        public int ParentMatchupId { get; set; }
        /// <summary>
        /// Models the match in the previous round from which 
        /// this team advanced
        /// </summary>
        public Matchup ParentMatchup { get; set; }
    }
}