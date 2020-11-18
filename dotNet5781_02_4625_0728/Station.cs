using System;
using System.Collections.Generic;

namespace dotNet5781_02_4625_0728
{
    class Station
    {
        public int StationKey { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string Adresse { get; set; } 

        public static List<Station> AllStations = new List<Station>();                  //list of all stations to keep in memory all the station that we created 
        static Random rand = new Random(DateTime.Now.Millisecond);                      //for the random nums

        public Station(){}                                                              //empty ctor 

        public Station(int myStationKey, double myLatitude, double myLongitude)         //ctor: we put the station key, latitude and longitude
        {
            try
            {
                foreach (Station item in AllStations)
                {
                    if (item.StationKey == myStationKey)
                        throw new ArgumentException($"the station with the key {myStationKey} already exist");
                }

                if ((myStationKey > 999999) || (myStationKey < 1))
                    throw new ArgumentException("The number of the station have to be a positive number of 6 digits maximum");
                StationKey = myStationKey;

                if ((myLatitude > 90) || (myLatitude < -90))
                    throw new ArgumentException("The latitude have to be between -90 and 90");
                Latitude = myLatitude;

                if ((myLongitude > 180) || (myLongitude < -180))
                    throw new ArgumentException("The longitude have to be between -180 and 180");
                Longitude = myLongitude;

                Station.AllStations.Add(this);                                                        //add the station to the list of all stations
            }
            catch (ArgumentException ex1)
            {
                Console.WriteLine(ex1.Message);
            }
        }

        public Station(double myLatitude, double myLongitude)                            //this ctor is called just when we create a BusLineStation because we want to create a new busLineStation without putting it in the list of all the stations if the station already exist
        {
            try
            {
                if ((myLatitude > 90) || (myLatitude < -90))
                    throw new ArgumentException("The latitude have to be between -90 and 90");
                Latitude = myLatitude;

                if ((myLongitude > 180) || (myLongitude < -180))
                    throw new ArgumentException("The latitude have to be between -180 and 180");
                Longitude = myLongitude;
            }
            catch (ArgumentException ex3)
            {
                Console.WriteLine(ex3.Message);
            }
        }

        public Station(bool flagRandom)                                                  //create a station with randomally parameters
        {
            if (flagRandom==true)
            {
                StationKey = rand.Next(1, 1000000);
                Latitude = (rand.NextDouble() * 2.3) + 31;
                Longitude = (rand.NextDouble() * 1.2) + 34.3;
            }
        }

        public override string ToString()                                                //override ToString for a station
        {
            return "Bus Station Code: " + StationKey +",  " + Latitude + "°N " + Longitude + "°E";
        }  

        public static Station FindStation(int key)                                        //function to return a Station when we send a key station (check in the list of all stations) 
        {
            foreach (Station item in AllStations)
            {
                if (key == item.StationKey)
                {
                    return item;
                }
            }
            return new Station();
        }

        public static bool StationIsExist(int key)                                        //boolean function to check if a station is exist or not when we send a key station (check in the list of all stations)
        {
            foreach (Station item in AllStations)
            {
                if (key == item.StationKey)
                {
                    return true;
                }
            }
            return false;
        }

    }
}
