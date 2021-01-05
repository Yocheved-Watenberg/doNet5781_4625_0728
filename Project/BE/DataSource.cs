using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DO;

namespace DS//memamech le Idal
{//a garder??       // ici il a mis la classe student a la classe Class1

    public static class DataSource
    {
        //rechimot de tt
        public static List<Bus> ListBus;
        public static List<AdjacentStations> ListAdjStations;
        public static List<BusOnTrip> ListBusOnTrip;
        public static List<Line> ListLine;
        public static List<LineStation> ListLinStations;
        public static List<LineTrip> ListLinTrip;
        public static List<Station> ListStations;
        public static List<Trip> ListTrip;
        public static List<User> ListUser;
        static DataSource()
        {
            InitAllLists();//pour initialiser ttes les lists
        }
        //static void InitAllLists() //a faire
        //{

        //}
    }
}
