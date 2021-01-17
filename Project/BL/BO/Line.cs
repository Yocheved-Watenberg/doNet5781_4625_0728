using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BL.BO.Enum;

namespace BL.BO
{
    public class Line
    {
        public int Id { get; set; }                                         //Isnt shown on Pl ,Busline number(rats automati)
        public int Code { get; set; }                                       //line number                                  
        public Areas Area { get; set; }                                     //in which area the bus travel
   
        public IEnumerable<BO.LineStation> ListOfStations { get; set; }                //has the list of all the Linestations
                                                                                       //query on Do.lineStation withlineId=XXX
        public override string ToString()                                                //override ToString for a station
        {
            return "Line number: " + Code + ",  " + Area + " " ;
        }
    }
}
