using System;

namespace dotNet5781_02_4625_0728
{
    class BusLineStation : Station
    { 
        public double DistanceFromLastStation { get; set; }
        public double TimeFromLastStation { get; set; }
       
        static Random rand = new Random(DateTime.Now.Millisecond);

        public BusLineStation() : base() { }                //empty ctor 

        public BusLineStation(int myBusStationKey, double myLatitude, double myLongitude, double myDistanceFromLastStation, double myTimeFromLastStation) : base(myLatitude, myLongitude)
        {
            bool flag = false;
            try
            {
                if ((myBusStationKey > 999999) || (myBusStationKey < 1))
                    throw new ArgumentException("The number of the station have to be a positive number of 6 digits maximum");
                StationKey = myBusStationKey;
                foreach (Station item in AllStations)
                {
                    if (item.StationKey == myBusStationKey)
                        flag = true; //the station is already exist 
                }
                if (flag == false) AllStations.Add(this);

                DistanceFromLastStation = myDistanceFromLastStation;            //in meters  
                TimeFromLastStation = myTimeFromLastStation;                    //in minutes 
            }
            catch (ArgumentException ex1)
            {
                Console.WriteLine(ex1.Message);
            }        
        }    //ctor 

        public BusLineStation(int myBusStationKey) : base((rand.NextDouble()*2.3+31),(rand.NextDouble()*1.2+34.3)) //ctor which helps us to build a BusLine Station only with its key(for creating a Line for example)
        {
            StationKey = myBusStationKey;
            DistanceFromLastStation = (rand.NextDouble() * 500);
            TimeFromLastStation = (rand.NextDouble() * 10);
        }

        public BusLineStation(Station s, double d, double t) : base(s.Latitude, s.Longitude)   //create a BusLineStation with an existing station and a new distance and time 
        {
            StationKey = s.StationKey;
            DistanceFromLastStation = d;
            TimeFromLastStation = t;
        }

        public BusLineStation(Station s, bool flagRandom) : base(s.Latitude, s.Longitude)       //create a BusLineStation with an existing station and randomaly other fields
        {
            if (flagRandom == true)
            {
                bool flag = false;
                try
                {
                    if ((s.StationKey > 999999) || (s.StationKey < 0))
                        throw new ArgumentException("The number of the station have to be a positive number of 6 digits maximum");
                    StationKey = s.StationKey;
                    foreach (Station item in AllStations)
                    {
                        if (item.StationKey == s.StationKey)
                            flag = true;                                            //if the station is already exist, flag = true 
                    }
                    if (flag == false) 
                        AllStations.Add(this);                                      //we add the station just if it isn't already in the list of all stations. 
                    DistanceFromLastStation = rand.NextDouble() * 500;              //random num for the distance from last station
                    TimeFromLastStation = rand.NextDouble() * 10;                   //random num for the distance from last station
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        public bool Equals(BusLineStation other)            //fonction Equals, check if a BusLineStation is equal to another. 
        {
            if ((other == null) || (GetType() != other.GetType()) || (StationKey != other.StationKey) || (Latitude != other.Latitude) || (Longitude != other.Longitude) || (DistanceFromLastStation != other.DistanceFromLastStation) || (TimeFromLastStation != other.TimeFromLastStation))
            {
                return false;
            }
            return true;
        }

    }
}
