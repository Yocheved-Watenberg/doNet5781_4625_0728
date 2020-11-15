using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotNet5781_02_4625_0728
{
    class BusStation
    {
        public readonly int id;
        public float Latitude { get; set; }
        public float Longitude { get; set; }
        public string Adresse { get; set; }
        int x; //a degager
        public BusStation(int myId, int myLatitude , int myLongitude)
        {
            id = myId;                   //ca doit etre 6 chiffres , sortir exception 
            Latitude = myLatitude;       //ca doit etre entre -90 et 90 , sortir exception
            Longitude = myLongitude;     //ca doit etre entre -180 et 180 , sortir exception
            //try
            //{
            //    if ((myId > 999999)||(myId<0))
            //        throw new TooLongException("The id have to be a positive number of 6 digits maximum");    //faire une boucle a chaque fois quon utilise le banay pr jeter la hariga while  (myId > 999999)
            //    else id = myId;
            //}
            //catch (TooLongException ex)
            //{
            //    Console.WriteLine(ex.Message);
            //}
            
        }
        public override string ToString()
        {
            return "The number of the bus station is " +id+ ", its latitude is " +Latitude+ ", its longitude is " +Longitude;
            //ca doit etre de cette forme la : Bus Station Code: 765432, 31.234567°N 34.56789°E
        }

    }
}
