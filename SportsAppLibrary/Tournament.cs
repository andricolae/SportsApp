using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsAppLibrary
{
    public class Tournament
    {
        /// <summary>
        /// The name of the tournament
        /// </summary>
        public string TournamentName { get; set; }
        /// <summary>
        /// The entry fee for the tournament
        /// </summary>
        public double Fee { get; set; }
        /// <summary>
        /// Models the list of teams to participate
        /// </summary>
        public List<Team> Teams { get; set; } = new List<Team>();
        /// <summary>
        /// The prizes for the first places
        /// </summary>
        public List<Prize> Prizes { get; set; } = new List<Prize>();
        /// <summary>
        /// The list of rounds computed by the app
        /// </summary>
        public List<List<Matchup>> Rounds {get; set;} = new List<List<Matchup>>();
    }
}