using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.BO
{
    public class Station
    {
        public int Code { get; set; }                                 //number of the station 
        public string Name { get; set; }                              //name of the station
        public double Longitude { get; set; }                         //longitude of the station
        public double Latitude { get; set; }                          //latitude of the station
        public string Adress { get; set; }                            //adress of the station 
        public IEnumerable<Line> ListOfLine { get; set; }
        public bool IsDeleted { get; set; } = false; 
        public override string ToString()                             //override ToString for a station
        {
            return "Station number: " + Code + ",  Station Name: " + Name + ", Station Adress: " + Adress;
        }
    }
}

