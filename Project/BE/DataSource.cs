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
        public static List<AdjacentStations> ListAdjacentStations;
        public static List<BusOnTrip> ListBusOnTrip;
        public static List<Line> ListLine;
        public static List<LineStation> ListLineStation;
        public static List<LineTrip> ListLineTrip;
        public static List<Station> ListStation;
        public static List<Trip> ListTrip;
        public static List<User> ListUser;
        static DataSource()
        {
            InitAllLists();//pour initialiser ttes les lists
        }
        static void InitAllLists() //a faire
        {
            ListBus = new List<Bus>
            {
                new Bus
                {
                    LicenseNum=11111222 ,
                    FromDate = DateTime.Parse("24.03.19"),
                    TotalTrip=
                    FuelRemain(int)
                    BusState(State)
                    MaxTravellers(int)
                    DateTime.Parse("24.03.85")
                },

                new Person
                {
                    Name = "Yossi",
                    ID = 23,
                    Street = "Moshe Dayan",
                    HouseNumber = 145,
                    City = "Jerusalem",
                    PersonalStatus = PersonalStatus.SINGLE,
                    BirthDate = DateTime.Parse("13.10.95")
                },

                new Person
                {
                    Name = "Roni",
                    ID = 15,
                    Street = "Dayan",
                    HouseNumber = 33,
                    City = "Petach Tikva",
                    PersonalStatus = PersonalStatus.MARRIED,
                    BirthDate = DateTime.Parse("14.02.98")
                },

                new Person
                {
                    Name = "Shira",
                    ID = 3,
                    Street = "Moshe",
                    HouseNumber = 33,
                    City = "Eilat",
                    PersonalStatus = PersonalStatus.SINGLE,
                    BirthDate = DateTime.Parse("13.10.95")
                },

                new Person
                {
                    Name = "Gila",
                    ID = 67,
                    Street = "Marom",
                    HouseNumber = 56,
                    City = "Givataiim",
                    PersonalStatus = PersonalStatus.MARRIED,
                    BirthDate = DateTime.Parse("14.11.90")
                }


            };


        }
    }
}
