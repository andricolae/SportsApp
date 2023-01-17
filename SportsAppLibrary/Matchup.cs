using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace SportsAppLibrary
{
    public class Matchup
    {
        /// <summary>
        /// A unique identifier for each round
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Consists in the teams matched up in a rounds match 
        /// </summary>
        public List<MatchupEntry> Entries { get; set; } = new List<MatchupEntry>();
        public int WinnerId { get; set; }

        /// <summary>
        /// Contains the winner team in the match
        /// </summary>
        public Team Winner { get; set; }
        /// <summary>
        /// Holds the round in which this match was played
        /// </summary>
        public int MatchupRound { get; set; }
        public string Display
        {
            get
            {
                string output = "";
                foreach(MatchupEntry me in Entries)
                {
                    if (me.TeamCompeting != null)
                    {
                        if (output.Length == 0)
                        {
                            output = me.TeamCompeting.TeamName;
                        }
                        else
                        {
                            output += $" vs. {me.TeamCompeting.TeamName}";
                        } 
                    }
                    else
                    {
                        output = "Too soon";
                        break;
                    }
                }
                return output;
            }
        }
    }
}