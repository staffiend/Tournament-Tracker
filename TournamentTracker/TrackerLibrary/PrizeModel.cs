using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackerLibrary
{
    public class PrizeModel
    {
        /// <summary>
        /// Represents the finishing position of the team with a number.
        /// </summary>
        public int PlaceNumber { get; set; }

        /// <summary>
        /// Represents the finishing position of the team with a string.
        /// </summary>
        public string PlaceName { get; set; }

        /// <summary>
        /// Represents the prize amount.
        /// </summary>
        public decimal PrizeAmount { get; set; }

        /// <summary>
        /// Represents the percentage of the prize to be awarded.
        /// </summary>
        public double PrizePercentage { get; set; }
    }
}
