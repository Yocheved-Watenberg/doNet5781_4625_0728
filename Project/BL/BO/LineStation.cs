using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.BO
{
    public class LineStation                                        
    {
        public int LineCode { get; set; }                             
        public int StationCode { get; set; } 
        public double DistanceFromLastStation { get; set; }
        public TimeSpan TimeFromLastStation { get; set; }
        public string StationName { get; set; }                       
        public override string ToString()                           
        {
            return "Station number: " + StationCode + ",  " + "Station name: " + StationName + " " + "Line number: " + LineCode;
        }
    }
}
