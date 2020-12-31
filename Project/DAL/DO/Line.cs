using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DO
{
    class Line
    {public int Id{ get; set; }                                         //line number
        public int Code { get; set; }                                  //bus number
        public Areas Area { get; set; }                                 //in which area the bus travel
        public int FirstStation { get; set; }                           //name of the first station
        public double LastStation { get; set; }                         //name of the last station
        //meda nossaf optionel?

    }
}
