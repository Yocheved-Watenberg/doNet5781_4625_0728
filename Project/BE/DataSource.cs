using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.DO;
using DO;


namespace DS
{

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
            # region Bus
            ListBus = new List<Bus>
            {
                new Bus
                {
                   LicenseNum=00003939 ,
                    FromDate = DateTime.Parse("19.12.18"),
                    TotalTrip=17000,
                    FuelRemain=670,
                    BusState= (State) 1,
                    MaxTravellers=35,
                 },
                new Bus
                {
                    LicenseNum=11112121 ,
                    FromDate = DateTime.Parse("24.03.19"),
                    TotalTrip=17000,
                    FuelRemain=1000,
                    BusState= (State) 1,
                    MaxTravellers=40,
                },

                new Bus
                {
                    LicenseNum=22223333,
                    FromDate = DateTime.Parse("30.11.18"),
                    TotalTrip=18000,
                    FuelRemain=500,
                    BusState=(State)1,
                    MaxTravellers=35,
                },
                 new Bus
                {
                    LicenseNum=33333535 ,
                    FromDate = DateTime.Parse("15.08.20"),
                    TotalTrip=6000,
                    FuelRemain=250,
                    BusState=(State)1,
                    MaxTravellers=45,
                 },

                new Bus
                {
                   LicenseNum=44443939 ,
                    FromDate = DateTime.Parse("19.12.18"),
                    TotalTrip=17990,
                    FuelRemain=670,
                    BusState=(State)1,
                    MaxTravellers=35,
                 },

                new Bus
                {
                   LicenseNum=55552828 ,
                    FromDate = DateTime.Parse("15.10.19"),
                    TotalTrip=17060,
                    FuelRemain=680,
                    BusState= (State) 1,
                    MaxTravellers=40,
                 },
                new Bus
                {
                   LicenseNum=66661616 ,
                    FromDate = DateTime.Parse("25.04.19"),
                    TotalTrip=17006,
                    FuelRemain=555,
                    BusState= (State) 1,
                    MaxTravellers=40,
                 },
                new Bus
                {
                   LicenseNum=77774040 ,
                    FromDate = DateTime.Parse("01.01.21"),
                    TotalTrip=19009,
                    FuelRemain=1000,
                    BusState= (State) 1,
                    MaxTravellers=50,
                 },
                new Bus
                {
                   LicenseNum=88880505 ,
                    FromDate = DateTime.Parse("03.10.18"),
                    TotalTrip=17059,
                    FuelRemain=587,
                    BusState= (State) 1,
                    MaxTravellers=35,
                 },
                new Bus
                {
                   LicenseNum=99993131 ,
                    FromDate = DateTime.Parse("31.01.20"),
                    TotalTrip=19007,
                    FuelRemain=670,
                    BusState= (State) 1,
                    MaxTravellers=40,
                 },

                new Bus
                {
                   LicenseNum=10103232 ,
                    FromDate = DateTime.Parse("06.05.18"),
                    TotalTrip=17690,
                    FuelRemain=700,
                    BusState= (State) 1,
                    MaxTravellers=35,
                 },
                new Bus
                {
                   LicenseNum=11120404 ,
                    FromDate = DateTime.Parse("04.06.18"),
                    TotalTrip=17990,
                    FuelRemain=700,
                    BusState= (State) 1,
                    MaxTravellers=35,
                 },new Bus
                {
                   LicenseNum=12120101 ,
                    FromDate = DateTime.Parse("19.12.18"),
                    TotalTrip=17500,
                    FuelRemain=750,
                    BusState= (State) 0,
                    MaxTravellers=35,
                 },new Bus
                {
                   LicenseNum=13130303 ,
                    FromDate = DateTime.Parse("27.12.19"),
                    TotalTrip=17000,
                    FuelRemain=690,
                    BusState= (State) 0,
                    MaxTravellers=40,
                 },new Bus
                {
                   LicenseNum=14140404 ,
                    FromDate = DateTime.Parse("03.01.21"),
                    TotalTrip=19000,
                    FuelRemain=1020,
                    BusState= (State) 0,
                    MaxTravellers=50,
                 },new Bus
                {
                   LicenseNum=15150606 ,
                    FromDate = DateTime.Parse("08.08.20"),
                    TotalTrip=19008,
                    FuelRemain=1004,
                    BusState= (State) 0,
                    MaxTravellers=45,
                 },new Bus
                {
                   LicenseNum=16160808 ,
                    FromDate = DateTime.Parse("11.11.18"),
                    TotalTrip=16000,
                    FuelRemain=400,
                    BusState= (State) 0,
                    MaxTravellers=35,
                 },
                new Bus
                {
                   LicenseNum=17170909 ,
                    FromDate = DateTime.Parse("16.03.19"),
                    TotalTrip=17666,
                    FuelRemain=600,
                    BusState= (State) 0,
                    MaxTravellers=40,
                 },
                new Bus
                {
                   LicenseNum=18181010 ,
                    FromDate = DateTime.Parse("25.07.20"),
                    TotalTrip=18500,
                    FuelRemain=1000,
                    BusState= (State) 0,
                    MaxTravellers=45,
                 },
                new Bus
                {
                   LicenseNum=19191111 ,
                    FromDate = DateTime.Parse("27.08.19"),
                    TotalTrip=17590,
                    FuelRemain=570,
                    BusState= (State) 0,
                    MaxTravellers=40,
                 },



            };
            #endregion
            #region Station
            ListStation = new List<Station>

            {
                new Station             //  station33
                {
                    Code=38862,
                    Name="Expand 1",
                    Longitude=34.940529,
                    Latitude=32.302957,
                    Adress="Expand Street",
                },
                new Station             //  station33
                {
                    Code=38863,
                    Name="Expand 2",
                    Longitude=34.939512,
                    Latitude=32.300264,
                    Adress="Expand Street",
                },
                new Station             //    station 42473
                {
                    Code=1130,
                    Name="El Toel / Al Mazar",
                    Longitude=35.196285,
                    Latitude=31.74317,
                    Adress="El Batan Street",
                },

                new Station             //station 44253
                {
                    Code=20637,
                    Name="Lehi / Operation Kadesh",
                    Longitude=34.82791,
                    Latitude=32.103914,
                    Adress="Lehi Street",
                },
                new Station             //station 42254 way back
                {
                   Code=20638,
                    Name="Lehi / Operation Kadesh",
                    Longitude=34.827875,
                    Latitude=32.104003,
                    Adress="Lehi Street",
                },
                 new Station             //
                {
                   Code=20641,
                    Name="Bayas Behachat/Mkhel",
                    Longitude=34.806271,
                    Latitude=32.049042,
                    Adress="Mkhel 42",
                }, new Station
                {
                   Code=20640,
                    Name="Mahal / Rabbi Alenkawa",
                    Longitude=34.801942,
                    Latitude=32.049425,
                    Adress="Mahal 14",
                },
                  new Station             //station 44257
                  {
                   Code=20639,
                    Name="Mahal / Rabbi Alenkawa",
                    Longitude=34.802053,
                    Latitude=32.049633,
                    Adress="Mahal 15",
                  },
                 new Station             //station 44272
                  {
                   Code=12550,
                    Name="Station on Sderot / Sdocks",
                    Longitude=34.587095,
                    Latitude=31.51648,
                    Adress="Sderot 15",
                  },
                  new Station
                  {
                   Code=35505,
                    Name="Herzl/Rotshild",
                    Longitude=34.743063,
                    Latitude=32.026119,
                    Adress="Herzl 38",
                  },

                   new Station
                  {
                   Code=18317,
                    Name="Bar Yehuda Boulevard/Muata Gur",
                    Longitude=34.749105,
                    Latitude=31.735511,
                    Adress="Bar Yehuda Boulevard",
                  },

 new Station
                  {
                   Code=18112,
                    Name="Secretarial/Avigdor",
                    Longitude=34.744586,
                    Latitude=31.711082,
                    Adress="Yael Street",
                  },
 new Station
                  {
                   Code=18111,
                    Name="Memorial/Avigdor",
                    Longitude=34.739468,
                    Latitude=31.712156,
                    Adress="Yael Street",
                  },
 new Station
                  {
                   Code=12551,
                    Name="Central/village of Werborg",
                    Longitude=34.732568,
                    Latitude=31.716725,
                    Adress="Habeher Street",
                  },

                 new Station
                {
                    Code=63410,
                    Name="Zionism way/Masada",
                    Longitude=35.194993,
                    Latitude=32.105309,
                    Adress="Zionism way 67",
                },
                 new Station
                {
                    Code=63411,
                    Name="Zionism way/Hiram operation",
                    Longitude=35.186293,
                    Latitude=32.108308,
                    Adress="Zionism way 23",
                },
                 new Station
                {
                    Code=63412,
                    Name="Afron/Samaria Road",
                    Longitude=35.172848,
                    Latitude=32.103739,
                    Adress="Afron road 8",
                },
                 new Station
                 {
                    Code=63413,
                    Name="The Golan/Gilboa level",
                    Longitude=35.201375,
                    Latitude=32.104832,
                    Adress="Gilboa 6",
                 },

                   new Station
                 {
                    Code=63414,
                    Name="Independence/Gardens",
                    Longitude=35.178637,
                    Latitude=32.103785,
                    Adress="Independence street",
                 },
                    new Station
                 {
                    Code=63415,
                    Name="Berkan/Shaham Road",
                    Longitude=35.117691,
                    Latitude=32.109122,
                    Adress="Shaham 1",
                 },

                     new Station
                      {
                    Code=63417,
                    Name="Shaham/Odem",
                    Longitude=35.120412,
                    Latitude=32.104466,
                    Adress="Shaham 15",
                 },
                      new Station           //way back
                      {
                    Code=63418,
                    Name="Shaham/Odem",
                    Longitude=35.120031,
                    Latitude=32.104213,
                    Adress="Shaham 16",
                 },

                       new Station
                 {
                    Code=63419,
                    Name="Shaham/growers",
                    Longitude=35.119862,
                    Latitude=32.107863,
                    Adress="Shaham 7",
                 },
                       new Station          //way back
                 {
                    Code=63420,
                    Name="Shaham/growers",
                    Longitude=35.119922,
                    Latitude=32.107747,
                    Adress="Shaham 6",
                 },

                         new Station
                 {
                    Code=63421,
                    Name="Shaham / Ivory",
                    Longitude=35.201375,
                    Latitude=32.101647,
                    Adress="Gilboa 6",
                 },
                          new Station
                 {
                    Code=63413,
                    Name="The Golan/Gilboa level",
                    Longitude=35.201375,
                    Latitude=32.104832,
                    Adress="Gilboa 6",
                 },
                           new Station
                 {
                    Code=38832,
                    Name="Herzl/Intersection Bilo",
                    Longitude=34.819541,
                    Latitude=31.870034,
                    Adress="Herzl",
                 },
                            new Station
                 {
                    Code=38833,
                    Name="The surge/fishermen",
                    Longitude=34.782828,
                    Latitude=31.984553,
                    Adress="The surge 30",
                 },
                             new Station
                 {
                    Code=38834,
                    Name="Separating/Six days",
                    Longitude=34.790904,
                    Latitude=31.88855,
                    Adress="Moshe Parid 9",
                 },
                              new Station
                 {
                    Code=38836,
                    Name="Lod central Station/Down",
                    Longitude=34.898098,
                    Latitude=31.956392,
                    Adress="Lod Street",
                 },
                               new Station
                 {
                    Code=38837,
                    Name="Hannah Abach/volcanic",
                    Longitude=34.796071,
                    Latitude=31.892166,
                    Adress="Hannah Abach 9",
                 },
                               new Station
                 {
                    Code=38838,
                    Name="Herzl/Moshe Sharet",
                    Longitude=34.824106,
                    Latitude=31.857565,
                    Adress="Herzl 20",
                 },
                                new Station
                 {
                    Code=38839,
                    Name="Children/Eli Cohen",
                    Longitude=34.821857,
                    Latitude=31.862305,
                    Adress="Habanim 4",
                 },
                               new Station
                 {
                    Code=38840,
                    Name="Weizmann/children",
                    Longitude=34.822237,
                    Latitude=31.865085,
                    Adress="Weizmann 11",
                 },
                               new Station
                 {
                    Code=38841,
                    Name="Eryl/economist",
                    Longitude=34.818957,
                    Latitude=31.865222,
                    Adress="Eryl 13",
                 },
                                new Station
                 {
                    Code=38842,
                    Name="The economist/Henrkis ",
                    Longitude=34.818392,
                    Latitude=31.867597,
                    Adress="Haklanit Street",
                 },
                                 new Station
                 {
                    Code=38844,
                    Name="Eli Cohen/ghetto fighters",
                    Longitude=34.827023,
                    Latitude=31.86244,
                    Adress="Eli Cohen 62",
                 },
                                    new Station
                 {
                    Code=38845,
                    Name="My brethren/blabbings",
                    Longitude=34.828702,
                    Latitude=31.863501,
                    Adress="Shivzei 51",
                 },
                                    new Station
                 {
                    Code=38846,
                    Name="My brethren/Weizmann Haim Bar-Lev/Yitzhak Rabin Avenue",
                    Longitude=34.827102,
                    Latitude=31.865348,
                    Adress="Shivzei 31",
                 },
                                    new Station
                 {
                    Code=38847,
                    Name="Haim Bar-Lev/Yitzhak Rabin Avenue",
                    Longitude=34.763896,
                    Latitude=31.977409,
                    Adress="Haim Bar-Lev Street",
                 },

                                       new Station
                 {
                    Code=38852,
                    Name="Holtzman/Science",
                    Longitude=34.807944,
                    Latitude=31.914255,
                    Adress="Haim Holtzman 2",
                 },
                                       new Station
                 {
                    Code=38854,
                    Name="Christian camp/club",
                    Longitude=34.836363,
                    Latitude=31.963668,
                    Adress="Christian Street",
                 },
                                        new Station
                 {
                    Code=38855,
                    Name="Herzl/Goni",
                    Longitude=34.825249,
                    Latitude=31.856115,
                    Adress="Herzl 4",
                 },
                                          new Station
                 {
                    Code=38856,
                    Name="Rotation/demonstration",
                    Longitude=34.81249,
                    Latitude=31.874963,
                    Adress="Harotem 3",
                 },


                                           new Station {
                    Code=60413,
                    Name="Rachel's Tomb",
                    Longitude=35.202604,
                    Latitude=31.720193,
                    Adress="Hevron path",
                 },

                                            new Station {
                    Code=1493,
                    Name="Uziel/Bayt Vagan",
                    Longitude=35.11023,
                    Latitude=31.4614,
                    Adress="Bayt Vagan 21",
                 },
                                            new Station {
                    Code=844,
                    Name="Uziel/Michlin",
                    Longitude=35.26291,
                    Latitude=31.56430,
                    Adress="Uziel 130",
                 },


                                                   new Station {
                    Code=60028,
                    Name="Rabbi Pardes/Zocarman",
                    Longitude=35.243665,
                    Latitude=31.84387,
                    Adress="Maagalot Harav Pardes 11",
                 },
                                                    new Station {
                    Code=61157,
                    Name="The Rabbi Pardes/Meir in white",
                    Longitude=35.242001,
                    Latitude=31.844981,
                    Adress="Maagalot Harav Pardes 55",
                 },

                                                    new Station {
                    Code=62000,
                    Name="Al-Iman school/Ramallah road",
                    Longitude=35.228724,
                    Latitude=31.845808,
                    Adress="Ramallah road Street",
                 },
                                                    new Station {
                    Code=10030 ,
                    Name="Central Station Ashdod/Retsifim",
                    Longitude=34.639905,
                    Latitude=31.79089,
                    Adress="Kenyon city  ",
                 },
                                                     new Station {
                    Code=10038,
                    Name="The Sheddy Avraham Junction",          //eshkol(south)
                    Longitude=34.331187,
                    Latitude=31.210421,
                    Adress="Eshkol  ",
                 },
                                                      new Station {
                    Code=10039,
                    Name="Absalom Junction",           //eshkol(south)
                    Longitude=34.327073,
                    Latitude=31.222696,
                    Adress="Eshkol  ",
                 },
                                                       new Station {
                    Code=10040,
                    Name="Safety junction",           //eshkol(south)
                    Longitude=34.403063,
                    Latitude=31.25689,
                    Adress="Eshkol  ",
                 },

                                                       new Station {
                    Code=10045,
                    Name=" Herzl/Angel Avenue",         //eshkol(south)
                    Longitude=34.620177,
                    Latitude=31.318935,
                    Adress="Herzl Avenue",              //Ofakim
                 },

                                                       new Station {
                    Code=6117,
                    Name=" Kiryat science One",
                    Longitude=35.207169,
                    Latitude=31.803364,
                    Adress="Kiryat Meda",              //jerusalem
                 },

                                                       new Station {
                    Code=6116,
                    Name=" Kiryat science Two ",
                    Longitude=35.207807,
                    Latitude=31.805952,
                    Adress="Kiryat Meda",              //jerusalem
                 },

                                                       new Station {
                    Code=6114,
                    Name=" Kiryat science Three",
                    Longitude=35.212474,
                    Latitude=31.804263,
                    Adress="Hartom St 14",              //jerusalem
                 },
                                                       new Station {
                    Code=20902,
                    Name=" The 'Israel Gory' Avenue/Kibbutz Gpostcards",
                    Longitude=34.780691,
                    Latitude=32.046386,
                    Adress="Israel Gory Avenue 64",              //Tel Aviv
                 },
                                                       new Station {
                    Code=21000,
                    Name="Hôpital Ichilov / King David Blvd",
                    Longitude=34.787792,
                    Latitude=32.079787,
                    Adress="King David Boulevard 40",              //Tel Aviv
                 },
                                                        new Station {
                    Code=21005,
                    Name="Arlozorov / Dizengoff",
                    Longitude=34.774385,
                    Latitude=32.087073,
                    Adress="Arlozorov 19",              //Tel Aviv
                 },
                                                        new Station {
                    Code=21006,
                    Name="Arlozorov / Dizengoff",
                    Longitude=34.774173,
                    Latitude=32.08703,
                    Adress="Arlozorov 24",              //Tel Aviv
                 },
                                                        new Station {
                    Code=21022,
                    Name="Peace Train Station",
                    Longitude=34.792974,
                    Latitude=32.073112,
                    Adress="Ammunition Hill",              //Tel Aviv
                 },

                                                        new Station {
                    Code=21024,
                    Name="Leonardo da Vinci / Kaplan",
                    Longitude=34.784808,
                    Latitude=32.073875,
                    Adress="Leonardo da Vinci 11",              //Tel Aviv
                 },
                                                        new Station {
                    Code=21028,
                    Name="Derech Hashalom / Yigal Alon",
                    Longitude=34.795651,
                    Latitude=32.071995,
                    Adress="Derech Hashalom 8",              //Tel Aviv
                 },
                                                        new Station {
                    Code=21030,
                    Name="Derech Hashalom / Derech Yitzhak Rabin",
                    Longitude=34.803052,
                    Latitude=32.065178,
                    Adress="Derech Hashalom 75",              //Tel Aviv
                 },

 new Station {
                    Code=63424,
                    Name="The Negev / The Six Days",
                    Longitude=35.187932,
                    Latitude=32.105108,
                    Adress="The Negev 41",              //Ariel/Center
                 },
 new Station {
                    Code=63425,
                    Name="Moriah / Beautiful view",
                    Longitude=35.203624,
                    Latitude=32.101003,
                    Adress="Moriah 17",              //Ariel/Center
                 },
 new Station {
                    Code=60945,
                    Name="Sha'ar HaGai / Zionism Road",
                    Longitude=35.197745,
                    Latitude=32.104572,
                    Adress="Sha'ar HaGai ",              //Ariel/Center
                 },

  new Station {
                    Code=63097,
                    Name="Moriah / Neve Sha'anan",
                    Longitude=35.20594,
                    Latitude=32.101804,
                    Adress="Moriah 9 ",              //Ariel/Center
                 },

new Station {
                    Code=63125,
                    Name="Ariel West Industrial Park / S.G. Entrance",
                    Longitude=35.123598,
                    Latitude=32.096174,
                    Adress="Yasmin ",              //Ariel/Center
                 },
new Station {       Code=63422,
                    Name="Shaham / Ivory",
                    Longitude=35.117717,
                    Latitude=32.102926,
                    Adress="Gilboa 2",          //Mifalei Barkan
                 },
new Station {       Code=63434,
                    Name="Barkan / Amber Road",
                    Longitude=35.117423,
                    Latitude=32.110383 ,
                    Adress="Barkan Road",          //Mifalei Barkan
                 },
new Station {       Code=63435,
                    Name="Barkan / Amber Road",
                    Longitude=35.117167,
                    Latitude=32.110367,
                    Adress="Barkan Road 8",          //Mifalei Barkan
                 },
new Station {       Code=63407,
                    Name="Barkan / Halamish Road",
                    Longitude=35.112686,
                    Latitude=32.108509,
                    Adress="Barkan Road 16",          //Mifalei Barkan
                 },
new Station {       Code=63408 ,                        //Way back
                    Name="Barkan / Halamish Road",
                    Longitude=35.112514,
                    Latitude=32.108619,
                    Adress="Barkan Road 16",          //Mifalei Barkan
                 },
new Station {       Code=57962,
                    Name="Patient View One",
                    Longitude=35.530989,
                    Latitude=32.947145,
                    Adress="Patient View 10",          //Tsfat
                 },
new Station {       Code=57963,
                    Name="Nof Habashan One",
                    Longitude=35.531647,
                    Latitude=32.946942,
                    Adress="Nof Habashan Street",          //Tsfat
                 },
new Station {       Code=58005,
                    Name="Haim Weizmann / Mordechai Anielewicz",
                    Longitude=35.498073,
                    Latitude=32.957333,
                    Adress="Haim Weizmann Street",          //Tsfat
                 },
new Station {       Code=58006,
                    Name="Rasko Center / Haim Weizmann",
                    Longitude=35.496334,
                    Latitude=32.957351,
                    Adress="Haim Weizmann Street",          //Tsfat
                 },
new Station {       Code=58007,
                    Name="David Elazar / Yeffe Nof",
                    Longitude=35.492738,
                    Latitude=32.957531,
                    Adress="David Elazar Street",          //Tsfat
                 },
new Station {
                    Code=63416,                            //Way back
                    Name="Berkan/Shaham Road",
                    Longitude=35.11784,
                    Latitude=32.109024,
                    Adress="Shaham 2",                      //Mifalei Barkan
},

new Station {Code=63418,
                    Name="Shaham/Odem",                     //Way back
                    Longitude=35.120031,
                    Latitude=32.104213,
                    Adress="Shaham 16",                     //Mifalei Barkan
},

new Station { Code=57964,
                    Name="Nof Habashan Two",
                    Longitude=35.532128,                //Way back
                    Latitude=32.948835,
                    Adress="Nof Habashan 10",          //Tsfat
                 },
new Station {Code=57965,
Name="Patient View Two",
Longitude=35.531272,               ////Way back
Latitude=32.948126,
Adress="Patient View 9",          //Tsfat
},
new Station {Code=58002 ,
Name="Tzfat Central Station/Piers",
Longitude=35.497205,               ////Way back
Latitude=32.969703,
Adress="Tzfat Street",          //Tsfat
},
new Station {Code=30770 ,
Name="King Hassan II / Bossi St. George",
Longitude=34.813729,
Latitude=31.859745,
Adress="King Hassan II  4",          //KIriat Ekron
},
new Station {Code=31088,
Name="Road 40 / Brenner Hill",
Longitude=34.808948,
Latitude=31.861109,
Adress="Road 40",          //KIriat Ekron
},
new Station {Code=31089,
Name="Road 40 / Power Center Bilu",
Longitude=34.814784,
Latitude=31.866471,
Adress="Road 40",          //KIriat Ekron
},
new Station {Code=31090 ,
Name="Kaplan Hospital Branch / Route 40",
Longitude=34.816628,
Latitude=31.868289,
Adress="Road 40",          //KIriat Ekron
},
new Station {Code=31403,
Name="Council",
Longitude=34.822097,
Latitude=31.861004,
Adress="Herzl 47",          //KIriat Ekron
},
new Station {Code=34751,
Name="Shabazi / the boys ",
Longitude=34.824592,
Latitude=31.866799,
Adress="Shabazi 11",          //KIriat Ekron
},
new Station {Code=73,
Name="Golda Meir Boulevard / The Poet Acej",
Longitude=35.188624,
Latitude=31.825302,
Adress="Golda Meir Boulevard",          //Jerusalem
},
new Station {Code=76,
Name="Tzur Baher Girls School / Al-Medina Almonwara",
Longitude=35.228765,
Latitude=31.738425,
Adress="To a country to a monaura",          //Jerusalem
},
new Station {Code=77,
Name="Ibn Rashd / Almadina Almonvara School",
Longitude=35.226704,
Latitude=31.738676,
Adress="To a country to a monaura",          //Jerusalem
},
new Station {Code=78 ,
Name="Ministers of Israel / Jaffa",
Longitude=35.206146,
Latitude=31.789128,
Adress="Sderot Sarei Israel 15",          //Jerusalem
},
new Station {Code=84 ,
Name="Kings of Israel / The Columns ",
Longitude=35.209791,
Latitude=31.790758,
Adress="Kings of Israel 77",          //Jerusalem
},
new Station {Code=83 ,
Name="Belly / Soul to Marg",
Longitude=35.240417,
Latitude=31.766358,
Adress="Belly",          //Jerusalem
},
















































            };
            #endregion
            #region Line
            ListLine = new List<Line>
 {new Line
      {
            Id = Static.LineIdCounter++,
            Code = 21,
            Area = (Areas)3, //Kiriat EKron
            FirstStation = 38832,//Herzl / Intersection Bilo
            LastStation = 38855,// Herzl/Goni
      },

      new Line
      {
            Id = Static.LineIdCounter++,//AUTOMATI
            Code =33 ,
            Area = (Areas)3,//Rehovot,Geoulim
            FirstStation = 35505,//Herzl Rotshild
            LastStation =38863,//Expand 2
      },
     new Line
      {
            Id = Static.LineIdCounter++,//AUTOMATI
            Code =45 ,
            Area = (Areas)2,//Avigdor,Ofakim
            FirstStation = 12550,//"Station on Sderot / Sdocks"
            LastStation =  10045,// Herzl/Angel Avenue",
     },
               new Line
      {                Id = Static.LineIdCounter++,//AUTOMATI
            Code =55 ,
            Area = (Areas)4,//Jerusalem
            FirstStation = 844, //Uziel/Michlin,
            LastStation =  60413// Rachel's Tomb",
               },

                 new Line
      {              Id = Static.LineIdCounter++,//AUTOMATI
            Code =58 ,
            Area = (Areas)0,//Jerusalem
            FirstStation =20640,// Mahal / Rabbi Alenkawa,
    LastStation =  21030,// Derech Hashalom / Derech Yitzhak Rabin ",
                 },

                       new Line
      {
                           Id = Static.LineIdCounter++,//AUTOMATI
            Code =36 ,
            Area = (Areas)3,//Jerusalem
            FirstStation =60945, //Sha'ar HaGai / Zionism Road,
    LastStation =  63425,// "Moriah / Beautiful view",",
                       },
                                                new Line
      { Id = Static.LineIdCounter++,//AUTOMATI
            Code =44 ,
            Area = (Areas)1,//North
            FirstStation =63407, // Barkan / Halamish Road,
    LastStation =  58007,//  David Elazar, Yeffe Nof,
    },

              new Line
      {  Id = Static.LineIdCounter++,//AUTOMATI
            Code =42 ,//way back a changer
            Area = (Areas)1,//North,Tzfat/Mifalei Barkan
            FirstStation =63422,//"Shaham / Ivory",
    LastStation =  57964,// Nof Habashan Two,
              },
                 new Line
      {     Id = Static.LineIdCounter++,//AUTOMATI
            Code =22 ,
            Area = (Areas)3,//Kiriat Ekron
            FirstStation =30770,// King Hassan II / Bossi St. George,
            LastStation =  38855 , //Herzl/Goni
                },
                  new Line
      {     Id = Static.LineIdCounter++,//AUTOMATI
            Code = 34,
            Area = (Areas)3,//Jerusalem
            FirstStation =60028,// Rabbi Pardes/Zocarman,
            LastStation =  73 ,// Golda Meir Boulevard / The Poet Acej
     },

 };
            #endregion
            #region AdjacentStations
            ListAdjacentStations = new List<AdjacentStations>
 {      new AdjacentStations
      {  Station1=38832,
         Station2=38838,
         Distance=200,
         Time=new TimeSpan(00,00,50),
      },
      new AdjacentStations {
         Station1=38838,
         Station2=38839,
         Distance=150,
         Time=new TimeSpan(00,00,30),
      },
      new AdjacentStations {
         Station1=38839,
         Station2=38840,
         Distance=175,
         Time=new TimeSpan(00,00,40),
      },
      new AdjacentStations {
         Station1=38840,
         Station2=38841,
         Distance=125,
         Time=new TimeSpan(00,00,45),
      },
      new AdjacentStations {
         Station1=38841,
         Station2=38842,
         Distance=100,
         Time=new TimeSpan(00,00,40),
      },
      new AdjacentStations {
         Station1=38842,
         Station2=38845,
         Distance=122,
         Time=new TimeSpan(00,00,50),
      },
      new AdjacentStations {
         Station1=38845,
         Station2=38846,
         Distance=220,
         Time=new TimeSpan(00,01,20),
      },
      new AdjacentStations {
         Station1=38846,
         Station2=38855,
         Distance=230,
         Time=new TimeSpan(00,01,10),
      },//1st line 
      new AdjacentStations {
         Station1=35505,
         Station2=38834,
         Distance=5949,
         Time=new TimeSpan(00,15,00),
      },
      new AdjacentStations {
         Station1=38834,
         Station2=38837,
         Distance=632,
         Time=new TimeSpan(00,03,50),
      },
       new AdjacentStations {
         Station1=38837,
         Station2=38852,
         Distance=400,
         Time=new TimeSpan(00,02,00),
      },
        new AdjacentStations {
         Station1=38852,
         Station2=38856,
         Distance=450,
         Time=new TimeSpan(00,02,30),
      },
         new AdjacentStations {
         Station1=38856,
         Station2=38833,
         Distance=500,
         Time=new TimeSpan(00,03,00),
      },
          new AdjacentStations {
         Station1=38833,
         Station2=38847,
         Distance=525,
         Time=new TimeSpan(00,02,40),
      },
           new AdjacentStations {
         Station1=38847,
         Station2=38854,
         Distance=625,
         Time=new TimeSpan(00,05,00),
      },
            new AdjacentStations {
         Station1=38854,
         Station2=38862,
         Distance=780,
         Time=new TimeSpan(00,06,00),
      },
             new AdjacentStations {
         Station1=38862,
         Station2=38863,
         Distance=624,
         Time=new TimeSpan(00,05,00),
      },
//2ND LINE
  new AdjacentStations {
         Station1=12550,
         Station2=18317,
         Distance=8000,
         Time=new TimeSpan(00,20,00),
      },
  new AdjacentStations {
         Station1=18317 ,
         Station2=18112,
         Distance=275,
         Time=new TimeSpan(00,02,00),
      },
   new AdjacentStations {
         Station1=18112,
         Station2=18111,
         Distance=100,
         Time=new TimeSpan(00,01,30),
      },
    new AdjacentStations {
         Station1=18111 ,
         Station2=12551 ,
         Distance=827,
         Time=new TimeSpan(00,05,00),
      },
    new AdjacentStations {
         Station1=12551,
         Station2=10030 ,
         Distance=2032,
         Time=new TimeSpan(00,08,00),
      },
    new AdjacentStations {
         Station1=10030,
         Station2= 10038 ,
         Distance=2871,
         Time=new TimeSpan(00,09,00),
      },
    new AdjacentStations {
         Station1=10038,
         Station2= 10039 ,
         Distance=150,
         Time=new TimeSpan(00,01,34),
      },
    new AdjacentStations {
         Station1=10039,
         Station2= 10040 ,
         Distance=175,
         Time=new TimeSpan(00,01,30),
      },
    new AdjacentStations {
         Station1=10040 ,
         Station2= 10045 ,
         Distance=2376,
         Time=new TimeSpan(00,09,00),
      },
    //3rd line time
    new AdjacentStations {
         Station1=844,
         Station2= 1493 ,
         Distance=200,
         Time=new TimeSpan(00,02,00),
      },
      new AdjacentStations {
         Station1=1493,
         Station2=60028 ,
         Distance=3000,
         Time=new TimeSpan(00,10,00),
      },
       new AdjacentStations {
         Station1=60028,
         Station2=61157,
         Distance=237,
         Time=new TimeSpan(00,02,00),
      },
           new AdjacentStations {
         Station1=61157,
         Station2=62000,
         Distance=1257,
         Time=new TimeSpan(00,06,00),
      },

              new AdjacentStations {
         Station1=62000,
         Station2=1130 ,
         Distance=1873,
         Time=new TimeSpan(00,06,30),
      },
              new AdjacentStations {
         Station1=1130,
         Station2= 20637,
         Distance=376,
         Time=new TimeSpan(00,04,00),
      },
              new AdjacentStations {
         Station1=20637,
         Station2= 6117,
         Distance=2324,
         Time=new TimeSpan(00,08,00),
      },
                new AdjacentStations {
         Station1=6117,
         Station2= 6116,
         Distance=125,
         Time=new TimeSpan(00,00,40),
      },
                new AdjacentStations {
         Station1=6116,
         Station2= 6114,
         Distance=150,
         Time=new TimeSpan(00,01,45),
      },
                  new AdjacentStations {
         Station1=6114 ,
         Station2= 60413,
         Distance=345,
         Time=new TimeSpan(00,03,00),
      },
                  //4rth line
                  new AdjacentStations {
         Station1= 20640,
         Station2= 20641 ,
         Distance=150,
         Time=new TimeSpan(00,01,05),
      },
                   new AdjacentStations {
         Station1= 20641,
         Station2= 20902,
         Distance=3700,
         Time=new TimeSpan(00,10,00),
      },
                     new AdjacentStations {
         Station1=  20902,
         Station2= 21000 ,
         Distance=1000,
         Time=new TimeSpan(00,06,30),
      },
                      new AdjacentStations {
         Station1=  21000 ,
         Station2= 21005,
         Distance=1000,
         Time=new TimeSpan(00,06,40),
      },
                       new AdjacentStations {
         Station1=  21005 ,
         Station2= 21006,
         Distance=100,
         Time=new TimeSpan(00,01,00),
      },
                        new AdjacentStations {
         Station1=  21006,
         Station2= 210022,
         Distance=2000,
         Time=new TimeSpan(00,06,00),
      },
                         new AdjacentStations {
         Station1=  21022,
         Station2= 210024,
         Distance=500,
         Time=new TimeSpan(00,04,00),
      },
                         new AdjacentStations {
         Station1=  21024,
         Station2= 210028,
         Distance=560,
         Time=new TimeSpan(00,03,50),
      },new AdjacentStations {
         Station1=  21028,
         Station2= 21030,
         Distance=600,
         Time=new TimeSpan(00,03,50),
      },
                         //5TH line
new AdjacentStations {
         Station1=  60945,
         Station2= 63097 ,
         Distance=831,
         Time=new TimeSpan(00,05,00),
      },
new AdjacentStations {
         Station1=  63097,
         Station2=  63125,
         Distance=7000,
         Time=new TimeSpan(00,19,00),
      },
new AdjacentStations {
         Station1=  63125,
         Station2=  63410,
         Distance=6000,
         Time=new TimeSpan(00,15,00),
      },
new AdjacentStations {
         Station1=  63410,
         Station2=  63411,
         Distance=100,
         Time=new TimeSpan(00,01,00),
      },
new AdjacentStations {
         Station1=  63411,
         Station2=  63412,
         Distance=150,
         Time=new TimeSpan(00,01,20),
      },
new AdjacentStations {
         Station1=  63412,
         Station2=  63413,
         Distance=175,
         Time=new TimeSpan(00,01,30),
      },
new AdjacentStations {
         Station1=  63413,
         Station2=  63414,
         Distance=140,
         Time=new TimeSpan(00,01,10),
      },
new AdjacentStations {
         Station1=  63414,
         Station2=  63424,
         Distance=300,
         Time=new TimeSpan(00,03,00),
      },
new AdjacentStations {
         Station1=  63424,
         Station2=  63425,
         Distance=134,
         Time=new TimeSpan(00,01,22),
      },
//6th Line
new AdjacentStations {
         Station1=  63407,
         Station2=  63415,
         Distance=600,
         Time=new TimeSpan(00,06,00),
      },
new AdjacentStations {
         Station1=  63415,
         Station2=  63417,
         Distance=1000,
         Time=new TimeSpan(00,10,00),
      },
new AdjacentStations {
         Station1=  63417,
         Station2=  63419,
         Distance=100,
         Time=new TimeSpan(00,01,00),
      },
new AdjacentStations {
         Station1=  63419,
         Station2=  63421,
         Distance=500,
         Time=new TimeSpan(00,04,00),
      },
new AdjacentStations {
         Station1=  63421,
         Station2=  63434 ,
         Distance=1000,
         Time=new TimeSpan(00,07,00),
      },
new AdjacentStations {
         Station1=  63434,
         Station2=  63435 ,
         Distance=345,
         Time=new TimeSpan(00,03,00),
      },
new AdjacentStations {
         Station1= 63435,
         Station2= 57962,
         Distance=2000,
         Time=new TimeSpan(00,12,00),
      },
new AdjacentStations {
         Station1= 57962,
         Station2= 58007 ,
         Distance=620,
         Time=new TimeSpan(00,04,00),
      },
//7TH line
new AdjacentStations {
         Station1=  63422,
         Station2= 63420,
         Distance=600,
         Time=new TimeSpan(00,04,30),
      },
new AdjacentStations {
         Station1=  63420,
         Station2= 63418,
         Distance=700,
         Time=new TimeSpan(00,05,10),
      },
new AdjacentStations {
         Station1=  63418,
         Station2= 63416,
         Distance=800,
         Time=new TimeSpan(00,06,30),
      },
new AdjacentStations {
         Station1=  63416,
         Station2= 63408 ,
         Distance=900,
         Time=new TimeSpan(00,07,30),
      },
new AdjacentStations {
         Station1=  63408 ,
         Station2= 58006,
         Distance=1000,
         Time=new TimeSpan(00,09,00),
      },
new AdjacentStations {
         Station1=  58006 ,
         Station2= 58005,
         Distance=1200,
         Time=new TimeSpan(00,09,20),
      },
new AdjacentStations {
         Station1=  58005 ,
         Station2= 58002 ,
         Distance=1500,
         Time=new TimeSpan(00,09,40),
      },
new AdjacentStations {
         Station1=  58002 ,
         Station2= 57965,
         Distance=1800,
         Time=new TimeSpan(00,09,55),
},
new AdjacentStations {
         Station1= 57965,
         Station2= 57964,
         Distance=2000,
         Time=new TimeSpan(00,12,00),
      },
//8th line
new AdjacentStations {
         Station1=30770 ,
         Station2= 31088,
         Distance=2500,
         Time=new TimeSpan(00,12,20),
      },
new AdjacentStations {
         Station1=31088,
         Station2= 31089 ,
         Distance=3000,
         Time=new TimeSpan(00,13,00),
      },
new AdjacentStations {
         Station1=31089,
         Station2= 31090 ,
         Distance=600,
         Time=new TimeSpan(00,03,00),
      },

new AdjacentStations {
         Station1=31090,
         Station2= 31403,
         Distance=4000,
         Time=new TimeSpan(00,15,00),
      },
new AdjacentStations {
         Station1=31403,
         Station2= 34751,
         Distance=600,
         Time=new TimeSpan(00,03,00),
      },
new AdjacentStations {
         Station1=34751,
         Station2=  38844,
         Distance=8000,
         Time=new TimeSpan(00,20,00),
      },
//9th Line
new AdjacentStations {
         Station1=61157,
         Station2= 60413,
         Distance=700,
         Time=new TimeSpan(00,05,30),
      },
new AdjacentStations {
         Station1=61157,
         Station2=20638 ,
         Distance=800,
         Time=new TimeSpan(00,06,30),
      },
new AdjacentStations {
         Station1=20638,
         Station2= 84,
         Distance=900,
         Time=new TimeSpan(00,07,30),
      },
new AdjacentStations {
         Station1=84,
         Station2= 83,
         Distance=500,
         Time=new TimeSpan(00,04,00),
      },
new AdjacentStations {
         Station1=83,
         Station2= 78,
         Distance=400,
         Time=new TimeSpan(00,03,30),
      },
new AdjacentStations {
         Station1=78,
         Station2= 77,
         Distance=300,
         Time=new TimeSpan(00,03,00),
      },
new AdjacentStations {
         Station1=77,
         Station2= 76,
         Distance=200,
         Time=new TimeSpan(00,02,00),
      },
new AdjacentStations {
         Station1=76,
         Station2= 73,
         Distance=100,
         Time=new TimeSpan(00,01,00),
      }
            };
            #endregion
            #region BusOnTrip
            ListBusOnTrip = new List<BusOnTrip>
            { new BusOnTrip
            {
                Id = Static.BusOnTripIdCounter++,
                LicenseNum = 00003939,
                LineId = ListLine[0].Id,
                PlannedTakeOff =new TimeSpan(06,00,00),
                ActualTakeOff = new TimeSpan(06,05,05),
                PrevStation = 38839,                        //"Chidren/Eli Cohen"
                PrevStationAt = new TimeSpan(00,01,00),
                NextStationAt = new TimeSpan(00,00,40),
                DriverName = "Bob",
            },
                new BusOnTrip
                {
                    Id = Static.BusOnTripIdCounter++,
                    LicenseNum = 11112121,
                    LineId = ListLine[1].Id,
                    PlannedTakeOff = new TimeSpan(06,00,00),
                    ActualTakeOff = new TimeSpan(06,05,05),
                    PrevStation = 38837,                        //"Hannah Abach/volcanic"
                    PrevStationAt = new TimeSpan(00,01,00),
                    NextStationAt = new TimeSpan(00,02,00),
                    DriverName = "Emmanuel",
                },
                new BusOnTrip
                {
                    Id = Static.BusOnTripIdCounter++,
                    LicenseNum = 22223333,
                    LineId = ListLine[2].Id,
                    PlannedTakeOff = new TimeSpan(07,00,00),
                    ActualTakeOff = new TimeSpan(07,03,05),
                    PrevStation = 18112,                        //"Secretarial/Avigdor"
                    PrevStationAt = new TimeSpan(00,01,00),
                    NextStationAt = new TimeSpan(00,01,30),
                    DriverName = "Binyamin",
                },
                new BusOnTrip
                {
                    Id = Static.BusOnTripIdCounter++,
                    LicenseNum = 33333535,
                    LineId = ListLine[3].Id,
                    PlannedTakeOff = new TimeSpan(07,00,00),
                    ActualTakeOff = new TimeSpan(07,03,05),
                    PrevStation = 6117,                        //"Kiryat Science One"
                    PrevStationAt = new TimeSpan(00,01,00),
                    NextStationAt = new TimeSpan(00,08,00),
                    DriverName = "Puterkov",
                },
                new BusOnTrip
                {
                    Id = Static.BusOnTripIdCounter++,
                    LicenseNum = 44443939,
                    LineId = ListLine[4].Id,
                     PlannedTakeOff = new TimeSpan(09,00,00),
                    ActualTakeOff = new TimeSpan(09,10,00),
                    PrevStation = 6117,                        //"Kiryat Science One"
                    PrevStationAt = new TimeSpan(00,00,30),
                    NextStationAt = new TimeSpan(00,00,40),
                    DriverName = "Mercedes",
                },
                new BusOnTrip
                {
                    Id = Static.BusOnTripIdCounter++,
                    LicenseNum = 66661616,
                    LineId = ListLine[5].Id,
                   PlannedTakeOff = new TimeSpan(06,00,00),
                    ActualTakeOff = new TimeSpan(06,30,34),
                    PrevStation = 63097,                        //"Moriah / Neve Sha'anan"
                    PrevStationAt = new TimeSpan(00,01,00),
                    NextStationAt = new TimeSpan(00,00,19),
                    DriverName = "Clémentine",
                },
                new BusOnTrip
                {
                    Id = Static.BusOnTripIdCounter++,
                    LicenseNum = 77774040,
                    LineId = ListLine[6].Id,
                    PlannedTakeOff = new TimeSpan(05,00,00),
                    ActualTakeOff = new TimeSpan(05,15,34),
                    PrevStation = 63417,                        //"Moriah / Neve Sha'anan"
                   PrevStationAt = new TimeSpan(00,01,00),
                    NextStationAt = new TimeSpan(00,19,00),
                    DriverName = "Machlouf Zalman",
                },
                new BusOnTrip
                {
                    Id = Static.BusOnTripIdCounter++,
                    LicenseNum = 88880505,
                    LineId = ListLine[7].Id,
                    PlannedTakeOff = new TimeSpan(05,00,00),
                    ActualTakeOff = new TimeSpan(05,15,34),
                    PrevStation = 63418,                        //Shaham/Odem
                    PrevStationAt = new TimeSpan(00,01,00),
                    NextStationAt = new TimeSpan(00,06,30),
                    DriverName = "Tova",
                },
                new BusOnTrip
                {
                    Id = Static.BusOnTripIdCounter++,
                    LicenseNum = 99993131,
                    LineId = ListLine[8].Id,
                   PlannedTakeOff = new TimeSpan(05,00,00),
                    ActualTakeOff = new TimeSpan(05,15,34),
                    PrevStation = 31089,                        //Road 40 / Power Center Bilu
                    PrevStationAt = new TimeSpan(00,01,00),
                    NextStationAt = new TimeSpan(00,03,00),
                    DriverName = "Avi",
                },
                new BusOnTrip
                {
                    Id = Static.BusOnTripIdCounter++,
                    LicenseNum = 10103232,
                    LineId = ListLine[9].Id,
                   PlannedTakeOff = new TimeSpan(05,00,00),
                    ActualTakeOff = new TimeSpan(05,15,34),
                    PrevStation = 61157,                        //The Rabbi Pardes/Meir in white
                    PrevStationAt = new TimeSpan(00,01,00),
                    NextStationAt = new TimeSpan(00,06,30),
                    DriverName = "Yoko",
                },
            };

            #endregion
            #region LineStation
            ListLineStation = new List<LineStation>{
            //1st line
                new LineStation{
        LineId=ListLine[0].Id,
        StationCode= 38832,
        LineStationIndex=0,
        PrevStation= 0,                 //No previous station  bcz it s the first station                     
        NextStation= 38838,
        },
             new LineStation{
        LineId=ListLine[0].Id,
        StationCode= 38838,
        LineStationIndex=1,
        PrevStation= 38832,
        NextStation= 38839,
        },
             new LineStation{
        LineId=ListLine[0].Id,
        StationCode= 38839,
        LineStationIndex=2,
        PrevStation= 38838,
        NextStation= 38840,
        },
             new LineStation{
        LineId=ListLine[0].Id,
        StationCode= 38840,
        LineStationIndex=3,
        PrevStation= 38839,
        NextStation= 38841,
        },
              new LineStation{
        LineId=ListLine[0].Id,
        StationCode= 38841,
        LineStationIndex=4,
        PrevStation= 38840,
        NextStation= 38842,
        },

              new LineStation{
        LineId=ListLine[0].Id,
        StationCode= 38842,
        LineStationIndex=5,
        PrevStation= 38841,
        NextStation= 38844,
        },
               new LineStation{
        LineId=ListLine[0].Id,
        StationCode= 38844,
        LineStationIndex=6,
        PrevStation= 38842,
        NextStation= 38845,
        },
                new LineStation{
        LineId=ListLine[0].Id,
        StationCode= 38845,
        LineStationIndex=7,
        PrevStation= 38844,
        NextStation= 38846,
        },
                new LineStation{
        LineId=ListLine[0].Id,
        StationCode= 38846,
        LineStationIndex=8,
        PrevStation= 38845,
        NextStation= 38855,
        },
                 new LineStation{
        LineId=ListLine[0].Id,
        StationCode= 38855,
        LineStationIndex=9,
        PrevStation= 38846,
        NextStation= 0,
        },
                 //2nd line
                   new LineStation{
        LineId=ListLine[1].Id,
        StationCode= 35505,
        LineStationIndex=0,
        PrevStation= 0,
        NextStation= 38834,
        },
                     new LineStation{
        LineId=ListLine[1].Id,
        StationCode= 38834,
        LineStationIndex=1,
        PrevStation= 35505,
        NextStation= 38837,
        },
                       new LineStation{
        LineId=ListLine[1].Id,
        StationCode= 38837,
        LineStationIndex=2,
        PrevStation= 38834,
        NextStation= 38852,
        },
                         new LineStation{
        LineId=ListLine[1].Id,
        StationCode= 38852,
        LineStationIndex=4,
        PrevStation= 38837,
        NextStation= 38856,
        },
                           new LineStation{
        LineId=ListLine[1].Id,
        StationCode= 38856,
        LineStationIndex=5,
        PrevStation= 38852,
        NextStation= 38833,
        },
                             new LineStation{
        LineId=ListLine[1].Id,
        StationCode= 38833,
        LineStationIndex=6,
        PrevStation= 38856,
        NextStation= 38847,
        },
                               new LineStation{
        LineId=ListLine[1].Id,
        StationCode= 38847,
        LineStationIndex=7,
        PrevStation= 38833,
        NextStation= 38862,
        },
                               new LineStation{
        LineId=ListLine[1].Id,
        StationCode= 38862,
        LineStationIndex=8,
        PrevStation= 38847,
        NextStation= 38863,
        },
                                 new LineStation{
        LineId=ListLine[1].Id,
        StationCode= 38863,
        LineStationIndex=9,
        PrevStation= 38862,
        NextStation= 0,
        },
                                 //3rd line
 new LineStation{
        LineId=ListLine[2].Id,
        StationCode= 12550,
        LineStationIndex=0,
        PrevStation= 0,
        NextStation= 18317,
        },
 new LineStation{
        LineId=ListLine[2].Id,
        StationCode= 18317,
        LineStationIndex=1,
        PrevStation= 12550,
        NextStation= 18112,
        },
 new LineStation{
        LineId=ListLine[2].Id,
        StationCode= 18112,
        LineStationIndex=2,
        PrevStation= 18317,
        NextStation= 18111,
        },
 new LineStation{
        LineId=ListLine[2].Id,
        StationCode= 18111,
        LineStationIndex=3,
        PrevStation= 18112,
        NextStation= 12551,
        },
 new LineStation{
        LineId=ListLine[2].Id,
        StationCode= 12551,
        LineStationIndex=4,
        PrevStation= 18111,
        NextStation= 10030 ,
        },
 new LineStation{
        LineId=ListLine[2].Id,
        StationCode= 10030 ,
        LineStationIndex=5,
        PrevStation= 12551,
        NextStation= 10038,
        },
 new LineStation{
        LineId=ListLine[2].Id,
        StationCode= 10038,
        LineStationIndex=6,
        PrevStation= 10030,
        NextStation= 10039,
        },

 new LineStation{
        LineId=ListLine[2].Id,
        StationCode= 10039,
        LineStationIndex=7,
        PrevStation= 10038,
        NextStation= 10040,
        },
 new LineStation{
        LineId=ListLine[2].Id,
        StationCode= 10040,
        LineStationIndex=8,
        PrevStation= 10039,
        NextStation= 10045,
        },
 new LineStation{
        LineId=ListLine[2].Id,
        StationCode= 10045,
        LineStationIndex=9,
        PrevStation= 10040,
        NextStation= 0,
        },
 //4th line
 new LineStation{
        LineId=ListLine[3].Id,
        StationCode= 844,
        LineStationIndex=0,
        PrevStation= 0,
        NextStation= 1493,
        },
  new LineStation{
        LineId=ListLine[3].Id,
        StationCode= 1493,
        LineStationIndex=1,
        PrevStation= 844,
        NextStation= 60028,
        },
   new LineStation{
        LineId=ListLine[3].Id,
        StationCode= 60028,
        LineStationIndex=2,
        PrevStation= 1493,
        NextStation= 61157,
        },
    new LineStation{
        LineId=ListLine[3].Id,
        StationCode= 61157,
        LineStationIndex=3,
        PrevStation= 60028,
        NextStation= 62000,
        },
 new LineStation{
        LineId=ListLine[3].Id,
        StationCode= 62000,
        LineStationIndex=4,
        PrevStation= 61157,
        NextStation= 1130,
        },
 new LineStation{
        LineId=ListLine[3].Id,
        StationCode= 1130,
        LineStationIndex=5,
        PrevStation= 62000,
        NextStation= 20637,
        },
 new LineStation{
        LineId=ListLine[3].Id,
        StationCode= 20637,
        LineStationIndex=6,
        PrevStation= 1130,
        NextStation= 6117,
        },
 new LineStation{
        LineId=ListLine[3].Id,
        StationCode= 6117,
        LineStationIndex=7,
        PrevStation= 20637,
        NextStation= 6116,
        },
 new LineStation{
        LineId=ListLine[3].Id,
        StationCode= 6116,
        LineStationIndex=8,
        PrevStation= 6117,
        NextStation= 6114,
        },
 new LineStation{
        LineId=ListLine[3].Id,
        StationCode= 6114,
        LineStationIndex=9,
        PrevStation= 6116,
        NextStation= 0,
        },
 //5th line
 new LineStation{
        LineId=ListLine[4].Id,
        StationCode= 20640,
        LineStationIndex=0,
        PrevStation= 0,
        NextStation= 20641,
        },
 new LineStation{
        LineId=ListLine[4].Id,
        StationCode= 20641,
        LineStationIndex=1,
        PrevStation= 20640,
        NextStation= 20902,
        },
 new LineStation{
        LineId=ListLine[4].Id,
        StationCode= 20902,
        LineStationIndex=2,
        PrevStation= 20641,
        NextStation= 21000,
        },
 new LineStation{
        LineId=ListLine[4].Id,
        StationCode= 21000,
        LineStationIndex=3,
        PrevStation= 20902,
        NextStation= 21005,
        },
 new LineStation{
        LineId=ListLine[4].Id,
        StationCode= 21005,
        LineStationIndex=4,
        PrevStation= 21000,
        NextStation= 21006,
        },
 new LineStation{
        LineId=ListLine[4].Id,
        StationCode= 21006,
        LineStationIndex=5,
        PrevStation= 21005,
        NextStation= 21022,
        },
 new LineStation{
        LineId=ListLine[4].Id,
        StationCode= 21022,
        LineStationIndex=6,
        PrevStation= 21006,
        NextStation= 21024,
        },
 new LineStation{
        LineId=ListLine[4].Id,
        StationCode= 21024,
        LineStationIndex=7,
        PrevStation= 21022,
        NextStation= 21028,
        },
 new LineStation{
        LineId=ListLine[4].Id,
        StationCode= 21028,
        LineStationIndex=8,
        PrevStation= 21024,
        NextStation= 21030,
        },
 new LineStation{
        LineId=ListLine[4].Id,
        StationCode= 21030,
        LineStationIndex=9,
        PrevStation= 21028,
        NextStation= 0,
        },
 //6th line
 new LineStation{
        LineId=ListLine[5].Id,
        StationCode= 60945,
        LineStationIndex=0,
        PrevStation= 0,
        NextStation= 63097,
        },
 new LineStation{
        LineId=ListLine[5].Id,
        StationCode= 63097,
        LineStationIndex=1,
        PrevStation= 60945,
        NextStation= 63125,
        },
 new LineStation{
        LineId=ListLine[5].Id,
        StationCode= 63125,
        LineStationIndex=2,
        PrevStation= 63097,
        NextStation= 63410,
        },
 new LineStation{
        LineId=ListLine[5].Id,
        StationCode= 63410,
        LineStationIndex=3,
        PrevStation=63125 ,
        NextStation= 63411,
        },
 new LineStation{
        LineId=ListLine[5].Id,
        StationCode= 63411,
        LineStationIndex=4,
        PrevStation= 63410,
        NextStation= 63412,
        },
 new LineStation{
        LineId=ListLine[5].Id,
        StationCode= 63412,
        LineStationIndex=5,
        PrevStation= 63411,
        NextStation= 63413,
        },
 new LineStation{
        LineId=ListLine[5].Id,
        StationCode= 63413,
        LineStationIndex=6,
        PrevStation= 63412,
        NextStation= 63414,
        },
 new LineStation{
        LineId=ListLine[5].Id,
        StationCode= 63414,
        LineStationIndex=7,
        PrevStation= 63413,
        NextStation= 63424,
        },
 new LineStation{
        LineId=ListLine[5].Id,
        StationCode= 63424,
        LineStationIndex=8,
        PrevStation= 63414,
        NextStation= 63425,
        },
 new LineStation{
        LineId=ListLine[5].Id,
        StationCode= 63425,
        LineStationIndex=9,
        PrevStation= 63424,
        NextStation= 0,
        },
 //7th line 
  new LineStation{
        LineId=ListLine[6].Id,
        StationCode= 63407,
        LineStationIndex=0,
        PrevStation= 0,
        NextStation= 63415,
        },
   new LineStation{
        LineId=ListLine[6].Id,
        StationCode= 63415,
        LineStationIndex=1,
        PrevStation= 63407,
        NextStation= 63417,
        },
   new LineStation{
        LineId=ListLine[6].Id,
        StationCode= 63417,
        LineStationIndex=2,
        PrevStation= 63415,
        NextStation= 63419,
        },
   new LineStation{
        LineId=ListLine[6].Id,
        StationCode= 63419,
        LineStationIndex=3,
        PrevStation= 63417,
        NextStation= 63421,
        },
   new LineStation{
        LineId=ListLine[6].Id,
        StationCode= 63421,
        LineStationIndex=4,
        PrevStation= 63419,
        NextStation= 63434,
        },
   new LineStation{
        LineId=ListLine[6].Id,
        StationCode= 63434,
        LineStationIndex=5,
        PrevStation= 63421,
        NextStation= 63434,
        },
   new LineStation{
        LineId=ListLine[6].Id,
        StationCode= 63435,
        LineStationIndex=6,
        PrevStation= 63434,
        NextStation= 57962,
        },
   new LineStation{
        LineId=ListLine[6].Id,
        StationCode= 57962,
        LineStationIndex=7,
        PrevStation= 63435,
        NextStation= 57963,
        },
   new LineStation{
        LineId=ListLine[6].Id,
        StationCode= 57963,
        LineStationIndex=8,
        PrevStation= 57962,
        NextStation= 58007,
        },
   new LineStation{
        LineId=ListLine[6].Id,
        StationCode= 58007,
        LineStationIndex=9,
        PrevStation= 57963,
        NextStation= 0,
        },
   //8th line
   new LineStation{
        LineId=ListLine[7].Id,
        StationCode= 63422,
        LineStationIndex=0,
        PrevStation= 0,
        NextStation= 63420,
        },
   new LineStation{
        LineId=ListLine[7].Id,
        StationCode= 63420,
        LineStationIndex=1,
        PrevStation= 63422,
        NextStation= 63418,
        },
new LineStation{
        LineId=ListLine[7].Id,
        StationCode= 63418,
        LineStationIndex=2,
        PrevStation= 63420,
        NextStation= 63416,
        },
new LineStation{
        LineId=ListLine[7].Id,
        StationCode= 63416,
        LineStationIndex=3,
        PrevStation= 63418,
        NextStation= 63408 ,
        },
new LineStation{
        LineId=ListLine[7].Id,
        StationCode= 63408 ,
        LineStationIndex=4,
        PrevStation= 63416,
        NextStation= 58006,
        },

new LineStation{
        LineId=ListLine[7].Id,
        StationCode= 58006,
        LineStationIndex=5,
        PrevStation= 63408,
        NextStation= 58005,
        },
new LineStation{
        LineId=ListLine[7].Id,
        StationCode= 58005,
        LineStationIndex=6,
        PrevStation= 58006,
        NextStation= 58002,
        },
new LineStation{
        LineId=ListLine[7].Id,
        StationCode= 58002,
        LineStationIndex=7,
        PrevStation= 58005,
        NextStation= 57965,
        },
new LineStation{
        LineId=ListLine[7].Id,
        StationCode= 57965,
        LineStationIndex=8,
        PrevStation= 58002,
        NextStation= 57964,
        },
new LineStation{
        LineId=ListLine[7].Id,
        StationCode= 57964,
        LineStationIndex=9,
        PrevStation= 57965 ,
        NextStation= 0,
        },
//9th line
new LineStation{
        LineId=ListLine[8].Code,
        StationCode= 30770 ,
        LineStationIndex=0,
        PrevStation= 0 ,
        NextStation= 31088,
        },
new LineStation{
        LineId=ListLine[8].Code,
        StationCode= 31088,
        LineStationIndex=1,
        PrevStation= 30770  ,
        NextStation= 31089,
        },
                new LineStation{
        LineId=ListLine[8].Code,
        StationCode= 31089,
        LineStationIndex=2,
        PrevStation= 31088 ,
        NextStation= 31090,
        },
                new LineStation{
        LineId=ListLine[8].Code,
        StationCode= 31090 ,
        LineStationIndex=3,
        PrevStation= 31089 ,
        NextStation= 31403,
        },
                new LineStation{
        LineId=ListLine[8].Code,
        StationCode= 31403,
        LineStationIndex=4,
        PrevStation= 31090  ,
        NextStation= 34751,
        },
                new LineStation{
        LineId=ListLine[8].Code,
        StationCode= 34751,
        LineStationIndex=5,
        PrevStation= 31403 ,
        NextStation= 38844,
        },
                new LineStation{
        LineId=ListLine[8].Code,
        StationCode= 38844,
        LineStationIndex=6,
        PrevStation= 34751 ,
        NextStation= 38845,
        },
                new LineStation{
        LineId=ListLine[8].Code,
        StationCode= 38845,
        LineStationIndex=7,
        PrevStation= 38844 ,
        NextStation= 38846,
        },
                new LineStation{
        LineId=ListLine[8].Code,
        StationCode= 38846,
        LineStationIndex=8,
        PrevStation= 38845 ,
        NextStation= 38855,
        },
                new LineStation{
        LineId=ListLine[8].Code,
        StationCode= 38855,
        LineStationIndex=9,
        PrevStation= 38846 ,
        NextStation= 0,
        },
                //10th line
               
  new LineStation{
        LineId=ListLine[9].Code,
        StationCode= 60028,
        LineStationIndex=0,
        PrevStation= 0 ,
        NextStation= 61157,
         },
    new LineStation{
        LineId=ListLine[9].Code,
        StationCode= 61157,
        LineStationIndex=1,
        PrevStation= 60028 ,
        NextStation= 60413,
        },
      new LineStation{
        LineId=ListLine[9].Code,
        StationCode= 60413,
        LineStationIndex=2,
        PrevStation= 61157 ,
        NextStation= 20638,
        },
        new LineStation{
        LineId=ListLine[9].Code,
        StationCode= 20638,
        LineStationIndex=3,
        PrevStation= 60413 ,
        NextStation= 84 ,
        },
          new LineStation{
        LineId=ListLine[9].Code,
        StationCode= 84 ,
        LineStationIndex=4,
        PrevStation= 20638 ,
        NextStation= 83 ,
        },
            new LineStation{
        LineId=ListLine[9].Code,
        StationCode= 83 ,
        LineStationIndex=5,
        PrevStation= 84  ,
        NextStation= 78,
        },
              new LineStation{
        LineId=ListLine[9].Code,
        StationCode= 78,
        LineStationIndex=6,
        PrevStation= 83  ,
        NextStation= 77,
        },
                new LineStation{
        LineId=ListLine[9].Code,
        StationCode= 77,
        LineStationIndex=7,
        PrevStation= 78 ,
        NextStation= 76,
        },
                  new LineStation{
        LineId=ListLine[9].Code,
        StationCode= 76,
        LineStationIndex=8,
        PrevStation= 77 ,
        NextStation= 0,
        },
                    new LineStation{
        LineId=ListLine[9].Code,
        StationCode= 73,
        LineStationIndex=9,
        PrevStation= 76 ,
        NextStation= 0,
        },
            };


            #endregion
            #region User
            ListUser = new List<User>
            {
new User                    //if the users is an admin his password should containonly letters, otherwise only numbers
{
    UserName= "David",
    Password= "1234" ,
    Admin=false,
},
new User
{
    UserName= "Esther",
    Password= "4567" ,
    Admin=false,
},
new User
{
    UserName= "Sarah",
    Password= "7890" ,
    Admin=false,
},
new User
{
    UserName= "Myriam",
    Password= "myri" ,
    Admin=true,
},
new User
{
    UserName= "Naomie",
    Password= "naoo" ,
    Admin=true,
},
new User
{
    UserName= "Yehoudit",
    Password= "3452" ,
    Admin=false,
},
new User
{
    UserName= "Meir",
    Password= "meir" ,
    Admin=true,
},
new User
{
    UserName= "Aron",
    Password= "2622" ,
    Admin=false,
},
new User
{
    UserName= "Michael",
    Password= "3454" ,
    Admin=false,
}
            };
            #endregion
            #region LineTrip
            ListLineTrip = new List<LineTrip>
            {
                new LineTrip
{
    LineId=ListLine[0].Id,
    StartAt= new TimeSpan(06,00,00),
    Frequency= new TimeSpan(00,20,00),
    FinishedAt= new TimeSpan(00,00,00),
},
new LineTrip
{
    LineId=ListLine[1].Id,
    StartAt= new TimeSpan(07,00,00),
    Frequency=new TimeSpan(00,10,00),
    FinishedAt=new TimeSpan(00,00,00),
},
new LineTrip
{
    LineId=ListLine[2].Id,
    StartAt= new TimeSpan(06,25,00),
    Frequency= new TimeSpan(00,30,00),
    FinishedAt=new TimeSpan(01,00,00),
},
new LineTrip
{
    LineId=ListLine[3].Id,
    StartAt=new TimeSpan(07,40, 00),
    Frequency= new TimeSpan(00,15,00),
    FinishedAt=new TimeSpan(01,30,00),
},
new LineTrip
{
    LineId=ListLine[4].Id,
    StartAt= new TimeSpan(07,20,00),
    Frequency= new TimeSpan(00,15,00),
    FinishedAt=new TimeSpan(23,00,00),
},
new LineTrip
{
    LineId=ListLine[5].Id,
    StartAt= new TimeSpan(05,30,00),
    Frequency= new TimeSpan(00,20,00),
    FinishedAt=new TimeSpan(23,30,00),
},
new LineTrip
{
    LineId=ListLine[6].Id,
    StartAt= new TimeSpan(05,45,00),
    Frequency= new TimeSpan(00,40,00),
    FinishedAt=new TimeSpan(00,30,00),
},
new LineTrip
{
    LineId=ListLine[7].Id,
    StartAt= new TimeSpan(08,00,00),
    Frequency= new TimeSpan(00,15,00),
    FinishedAt=new TimeSpan(00,40,00),
},
new LineTrip
{
    LineId=ListLine[8].Id,
    StartAt= new TimeSpan(09,00,00),
    Frequency= new TimeSpan(00,18,00),
    FinishedAt=new TimeSpan(00,20,00),
},
new LineTrip
{
    LineId=ListLine[9].Id,
    StartAt= new TimeSpan(07,00,00),
    Frequency= new TimeSpan(00,10,00),
    FinishedAt=new TimeSpan(00,15,00),
},
};
            #endregion 
        }

    };

}
//new LineTrip
//{
//    LineId = ListLine[9].Id,
//    StartAt = TimeSpan.Parse("07.00.00"),
//    Frequency = TimeSpan.Parse("00.10.00"),
//    FinishedAt = TimeSpan.Parse("00.15.00"),
//},


