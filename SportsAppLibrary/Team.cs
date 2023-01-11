using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsAppLibrary
{
    public class Team
    {
        public int Id { get; set; }
        /// <summary>
        /// The teams name
        /// </summary>
        public string TeamName { get; set; }
        /// <summary>
        /// The list with the teams members
        /// </summary>
        public List<Person> TeamMembers { get; set; } = new List<Person>();
    }
}