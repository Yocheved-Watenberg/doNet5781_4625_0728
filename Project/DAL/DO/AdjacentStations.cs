using System;

namespace DO
{
    public class AdjacentStations
    {

        public int Station1 { get; set; }               //first station code
        public int Station2 { get; set; }               //second station code
        public double Distance { get; set; }            //distance between the two stations
        public TimeSpan Time { get; set; }              //average travel time between the two stations

    }
}
