 using System;

namespace DO
{
    public class Station
    {
        public int Code { get; set; }                                  //number of the station
        public string Name { get; set; }                               //name of the station
        public double Longitude { get; set; }                          //longitude of the station
        public double Latitude { get; set; }                           //latitude of the station
        public string Adress { get; set; }                             //adress of the station
        public bool IsDeleted { get; set; } = false; 
    }
}
