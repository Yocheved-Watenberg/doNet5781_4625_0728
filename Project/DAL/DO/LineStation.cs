using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DO
{
    class LineStation
    {
        public int LineId{ get; set; }                                  //line number (first attribute feature)
        public int Station { get; set; }                               //station number(second attribute feature)
        public int LineStationIndex { get; set; }                      //place of the station in the line
        public int PrevStation { get; set; }                           //?
        public int NextStation { get; set; }                           //?
    }
}
