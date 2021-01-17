﻿using System;

namespace DO
{
    public class Station
    {
        public int Code { get; set; }                                  //attention ca doit etre unique // number of the station //attribute feature
        public string Name { get; set; }                               //name of the station
        public double Longitude { get; set; }                         //longitude of the station
        public double Latitude { get; set; }                          //latitude of the station
        public string Adress { get; set; }                            //adress of the station optionnel

        public object StationDoBoAdapter()
        {
            throw new NotImplementedException();
        }
        public override string ToString()                                                //override ToString for a station
        {
            return "Station number: " + Code + ",  " + Name + " " + Latitude + "°N " + Longitude + "°E"+Adress;
        }
    }
}
