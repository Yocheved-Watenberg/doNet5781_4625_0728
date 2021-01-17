using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.BO
{
    public class LineStation                                           //a lineStation is a Station in which the line goes through
    {
        public int LineId { get; set; }                                //pour effacer une station ds une ligne mezae qui va m aider a le fr
        public int StationCode { get; set; }                           //attention ca doit etre unique // number of the station //attribute feature
        public double DistanceFromLastStation { get; set; }
        public TimeSpan TimeFromLastStation { get; set; }
        public string StationName { get; set; }                               //name of the station
        public int PrevStation { get; set; }
        public int NextStation { get; set; }
        public override string ToString()                                                //override ToString for a Linestation
        {
            return "Station number: " + StationCode + ",  " +/*+ DistanceFromLastStation + " " + TimeFromLastStation + " "*/ "Station name: " + StationName + " " ;
        }                                                   //a reflechir si on met et si oui a initialiser
    }
}
