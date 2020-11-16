using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotNet5781_02_4625_0728
{
    class Station
    {
        public readonly int StationKey;
        public float Latitude { get; set; }
        public float Longitude { get; set; }
        public static List<Station> AllStations = new List<Station>(); //il faudra a chaque fois quon cree une station l'ajouter a la liste a l'aide de AllStations.Add(nomdelanouvellestation)

        //  public string Adresse { get; set; } // a faire si on se chauffe 
        public Station(int myStationKey, float myLatitude , float myLongitude)
        {
            try
            {
                foreach (Station item in AllStations)
                {
                    if (item.StationKey == myStationKey)
                        throw new ArgumentException($"the station with the key {myStationKey} already exist");
                }
            }
            catch (ArgumentException ex0)
            {
                Console.WriteLine(ex0.Message);
            }


            try
            { 
                if ((myStationKey > 999999) || (myStationKey < 0))
                    throw new ArgumentException("The number of the station have to be a positive number of 6 digits maximum");
                StationKey = myStationKey;

            }
            catch (ArgumentException ex1)
            {
                Console.WriteLine(ex1.Message);
            }



            try
            {
                if ((myLatitude > 90) || (myLatitude < -90))
                    throw new ArgumentException("The latitude have to be between -90 and 90");
                Latitude = myLatitude;
            }
            catch (ArgumentException ex2)
            {
                Console.WriteLine(ex2.Message);
            }



            try
            {
                if ((myLongitude > 180) || (myLongitude < -180))
                    throw new ArgumentException("The latitude have to be between -180 and 180");
                Longitude = myLongitude;
            }
            catch (ArgumentException ex3)
            {
                Console.WriteLine(ex3.Message);
            }

            Station.AllStations.Add(this);

        }
        //le pb du banay est que il met des valeurs par defaut qd les valeurs sont mauvaises .
        //est ce bien? ou je prfr qu'il redemande des parametres.
        //ds ce cas, fr une fonction qui appelle le banay while ya des harigots 

        public override string ToString()
        {
            return "Bus Station Code: " + StationKey + ", " + Latitude + "°N " + Longitude + "°E";
        }  

        public Station()
        {
        }   //ctor empty         

    }
}
