using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotNet5781_02_4625_0728
{
    class Station
    {
        public int StationKey { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public static List<Station> AllStations = new List<Station>(); //il faudra a chaque fois quon cree une station l'ajouter a la liste a l'aide de AllStations.Add(nomdelanouvellestation)
        //  public string Adresse { get; set; } // a faire si on se chauffe 
        //public Station(int myStationKey, float myLatitude , float myLongitude)
        //{
        //    try
        //    {
        //        foreach (Station item in AllStations)
        //        {
        //            if (item.StationKey == myStationKey)
        //                throw new ArgumentException($"the station with the key {myStationKey} already exist");
        //        }

        //        if ((myStationKey > 999999) || (myStationKey < 0))
        //            throw new ArgumentException("The number of the station have to be a positive number of 6 digits maximum");
        //        StationKey = myStationKey;

        //        if ((myLatitude > 90) || (myLatitude < -90))
        //            throw new ArgumentException("The latitude have to be between -90 and 90");
        //        Latitude = myLatitude;

        //        if ((myLongitude > 180) || (myLongitude < -180))
        //            throw new ArgumentException("The longitude have to be between -180 and 180");
        //        Longitude = myLongitude;
        //        Station.AllStations.Add(this);
        //    }
        //    catch (ArgumentException ex1)
        //    {
        //        Console.WriteLine(ex1.Message);
        //    }

        //}






        public Station(int myStationKey, double myLatitude, double myLongitude)
        {
            try
            {
                foreach (Station item in AllStations)
                {
                    if (item.StationKey == myStationKey)
                        throw new ArgumentException($"the station with the key {myStationKey} already exist");
                }

                if ((myStationKey > 999999) || (myStationKey < 0))
                    throw new ArgumentException("The number of the station have to be a positive number of 6 digits maximum");
                StationKey = myStationKey;

                if ((myLatitude > 90) || (myLatitude < -90))
                    throw new ArgumentException("The latitude have to be between -90 and 90");
                Latitude = myLatitude;

                if ((myLongitude > 180) || (myLongitude < -180))
                    throw new ArgumentException("The longitude have to be between -180 and 180");
                Longitude = myLongitude;
                Station.AllStations.Add(this);
            }
            catch (ArgumentException ex1)
            {
                Console.WriteLine(ex1.Message);
            }

        }














        //le pb du banay est que il met des valeurs par defaut qd les valeurs sont mauvaises .
        //est ce bien? ou je prfr qu'il redemande des parametres.
        //ds ce cas, fr une fonction qui appelle le banay while ya des harigots 



        public Station(double myLatitude, double myLongitude)
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


        static Random rand = new Random(DateTime.Now.Millisecond);
        public Station(bool flagRandom)               //create a station with randomally parameters
        {
            if (flagRandom==true)
            {
                StationKey = rand.Next(1, 1000000);
                Latitude = (rand.NextDouble() * 2.3) + 31;
                Longitude = (rand.NextDouble() * 1.2) + 34.3;
            }
        }




        public override string ToString()
        {
            return "Bus Station Code: " + StationKey +",  " + Latitude + "°N " + Longitude + "°E";
        }  

        public Station()
        {
        }   //ctor empty     



        public bool Equals(Station other)
        {

            if ((other == null) || (GetType() != other.GetType()) || (StationKey != other.StationKey) || (Latitude != other.Latitude) || (Longitude != other.Longitude))
            { 
                return false;
            }
            return true;
        }

        public static Station FindStation(int key)
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

    }
}
