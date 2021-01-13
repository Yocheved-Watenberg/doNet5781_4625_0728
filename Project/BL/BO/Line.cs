using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BL.BO.Enum;

namespace BL.BO
{
    class Line
    {
        public int Id { get; set; }                                         //Busline number(rats automati)
        public int Code { get; set; }                                       //line number                                  
        public Areas Area { get; set; }                                     //in which area the bus travel
        public int FirstStation { get; set; }                               //name of the first station
        public double LastStation { get; set; }                              //name of the last station
        public IEnumerable<DO.AdjacentStations> ListOfAdjacentStations { get; set; }    // has the list of all the adjacents stations of the line
        public IEnumerable<LineStation> ListOfLineStations { get; set; }                //has the list of all the stations

    }
}
