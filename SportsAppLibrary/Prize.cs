using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsAppLibrary
{
    public class Prize
    {
        /// <summary>
        /// Stores a unique identifier for the prize
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// The place no., ex. 1/ 2/ 3
        /// </summary>
        public int Place { get; set; }
        /// <summary>
        /// Will consist of the name of the place, 
        /// whatever the organiser will want to name it
        /// </summary>
        public string PlaceName { get; set; }
        /// <summary>
        /// The value in money of the prize
        /// </summary>
        public double Amount { get; set; }
        /// <summary>
        /// The prize value in percentage
        /// </summary>
        public double Percentage { get; set; }
    }
}