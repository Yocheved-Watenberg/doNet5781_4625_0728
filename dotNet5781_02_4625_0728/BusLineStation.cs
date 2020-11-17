using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotNet5781_02_4625_0728
{
    class BusLineStation : Station
    { 
        public float DistanceFromLastStation { get; set; }
        public float TimeFromLastStation { get; set; }
      //  public int NewKey { get; set; }
      
        public BusLineStation(int myBusStationKey, /*int BusNum,*/ float myLatitude, float myLongitude, float myDistanceFromLastStation, float myTimeFromLastStation) : base(myLatitude, myLongitude)
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

        //public Station(bool flagRandom)               //create a station with randomally parameters
        //{
        //    if (flagRandom == true)
        //    {
        //        StationKey = rand.Next(1, 1000000);
        //        Latitude = (rand.NextDouble() * 2.3) + 31;
        //        Longitude = (rand.NextDouble() * 1.2) + 34.3;
        //    }
        //}
        static Random rand = new Random(DateTime.Now.Millisecond);
        public BusLineStation(int myBusStationKey) : base(2,3)//ctor which helps us to build a BusLine Station only with its key(for creating a Line for example)
        {
            StationKey = myBusStationKey;
            DistanceFromLastStation = (rand.NextDouble() * 500);
            TimeFromLastStation = (rand.NextDouble() * 10);





        }










        public BusLineStation():base(){}

        public BusLineStation(Station s, float d, float t) : base(s.Latitude, s.Longitude)
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

    }
}
