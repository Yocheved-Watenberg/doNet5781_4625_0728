using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotNet5781_02_4625_0728
{
    class BusLineStation : Station
    { 
        public double DistanceFromLastStation { get; set; }
        public double TimeFromLastStation { get; set; }
      
        public BusLineStation(int myBusStationKey, double myLatitude, double myLongitude, double myDistanceFromLastStation, double myTimeFromLastStation) : base(myLatitude, myLongitude)
        {
            bool flag = false;
            try
            {
                if ((myBusStationKey > 999999) || (myBusStationKey < 0))
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
               //   NewKey = BusNum * 1000000 + myBusStationKey;

            }
            catch (ArgumentException ex1)
            {
                Console.WriteLine(ex1.Message);
            }
           
        }

        public BusLineStation():base(){}

        public BusLineStation(Station s, double d, double t) : base(s.Latitude, s.Longitude)
        {
            StationKey = s.StationKey;
            DistanceFromLastStation = d;
            TimeFromLastStation = t;
        }


        public bool Equals(BusLineStation other)
        {

            if ((other == null) || (GetType() != other.GetType())||(StationKey != other.StationKey)||(Latitude != other.Latitude) ||(Longitude != other.Longitude) ||(DistanceFromLastStation != other.DistanceFromLastStation) ||(TimeFromLastStation != other.TimeFromLastStation))
            {
                return false;
            }
            return true;
        }


        static Random rand = new Random(DateTime.Now.Millisecond);
        public BusLineStation(Station s, bool flagRandom) : base(s.Latitude, s.Longitude)              //create a station with randomally parameters
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
                            flag = true; //the station is already exist 
                    }
                    if (flag == false) AllStations.Add(this);
                    DistanceFromLastStation = rand.NextDouble() * 500;
                    TimeFromLastStation = rand.NextDouble() * 10;

                }
                catch (ArgumentException ex1)
                {
                    Console.WriteLine(ex1.Message);
                }

            }
        }


    }
}
