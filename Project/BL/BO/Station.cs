using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.BO
{
    public class Station
    {
        public int Code { get; set; }                                  //attention ca doit etre unique // number of the station //attribute feature
        public string Name { get; set; }                               //name of the station
        public double Longitude { get; set; }                         //longitude of the station
        public double Latitude { get; set; }                          //latitude of the station
        public string Adress { get; set; }                            //adress of the station optionnel
        public IEnumerable<Line> ListOfLine { get; set; }
    }
}

