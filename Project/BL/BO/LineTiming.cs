using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.BO
{
    public class LineTiming                                     // The class represents a bus (of certain line) arriving soon to the bus station
    {
        private static int counter = 0;
        public int ID;
        public LineTiming() => ID = ++counter;                  //unique
        public int LineCode { get; set; }                       //Line Number as understood by the people
        public string LastStation { get; set; }                 //Last station name - so the passengers will know better which direction it is
        public TimeSpan TripStart { get; set; }                 //Time of Line start the trip
        public TimeSpan ExpectedTimeTillArrive { get; set; }    //Expected time of arrival
    }
}
