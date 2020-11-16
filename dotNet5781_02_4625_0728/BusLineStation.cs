using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotNet5781_02_4625_0728
{
    class BusLineStation : Station
    {
        public float distanceFromLastStation { get; set; }
        public float timeFromLastStation { get; set; }
        public BusLineStation(int myBusStationKey, float myLatitude, float myLongitude, float myDistanceFromLastStation, float myTimeFromLastStation) : base(myBusStationKey, myLatitude, myLongitude)
        {
            distanceFromLastStation = myDistanceFromLastStation;            //in meters  
            timeFromLastStation = myTimeFromLastStation;                    //in minutes 
        }

       public BusLineStation():base()
       {
       }
        public BusLineStation(Station s, float d, float t) : base(s.StationKey, s.Latitude, s.Longitude)
        {
            distanceFromLastStation = d;
            timeFromLastStation = t;
        }
        
    }
}
