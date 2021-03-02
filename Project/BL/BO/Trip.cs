using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.BO
{
    class Trip
    {
        public int Id { get; set; }                 
        public int LineId { get; set; }       
        public int InStation { get; set; }          //station number the user wants to travel from
        public TimeSpan InAt { get; set; }          //zman alia
        public int OutStation { get; set; }         //station number the user wants to travel to
        public TimeSpan OutAt { get; set; }         //zman yerida
    }
}
