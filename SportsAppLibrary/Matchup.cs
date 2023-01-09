using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsAppLibrary
{
    public class Matchup
    {
        /// <summary>
        /// Consists in the teams matched up in a rounds match 
        /// </summary>
        public List<MatchupEntry> Entries { get; set; } = new List<MatchupEntry>();
        /// <summary>
        /// Contains the winner team in the match
        /// </summary>
        public Team Winner { get; set; }
        /// <summary>
        /// Holds the round in which this match was played
        /// </summary>
        public int MatchupRound { get; set; }
    }
}