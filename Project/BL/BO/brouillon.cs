using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.BO
{
    public class brouillon
    {
        public class adjacentsStations { 
        public int Station1 { get; set; }               //first station code
        public int Station2 { get; set; }               //second station code
        public double Distance { get; set; }            //distance between the two stations in meters
        public TimeSpan Time { get; set; }              //average travel time between the two stations

    }

}
