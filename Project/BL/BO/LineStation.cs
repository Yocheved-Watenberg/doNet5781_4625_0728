using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.BO
{
    public class LineStation                                           //a lineStation is a Station in which the line goes throuh
    {  public int LineId { get; set; }                                //pour effacer une station ds une ligne mezae qui va m aider a le fr
        public double DistanceFromLastStation { get; set; }
        public TimeSpan TimeFromLastStation { get; set; }
        public int StationCode { get; set; }                                  //attention ca doit etre unique // number of the station //attribute feature
        public string StationName { get; set; }                               //name of the station
    }
}
