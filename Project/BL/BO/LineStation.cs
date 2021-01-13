using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.BO
{
    public class LineStation:Station                                           //a lineStation is a Station in which the line goes throuh
    {
        public int LineId { get; set; }                                //pour effacer une station ds une ligne mezae qui va m aider a le fr
        public int LineStationIndex { get; set; }                      //place of the station in the line
        public int PrevStation { get; set; }                           //?
        public int NextStation { get; set; }                           //?
    }
}
