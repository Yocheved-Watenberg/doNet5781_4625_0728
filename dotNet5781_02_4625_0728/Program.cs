using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotNet5781_02_4625_0728
{
    class Program
    {
        static void Main(string[] args)
        {
            //il faudra verifier que ca rajoute bien ds la liste de allstations a chaque appel du banay 
            //et sinn a chaque fois quon cree une station l'ajouter a la liste a l'aide de AllStations.Add(nomdelanouvellestation)


            //BusStation b = new BusStation(66551, 22, 24);
            // BusStation c = new BusStation(555616551, 200, 24);

            //Console.WriteLine(b.BusStationKey);
            // Console.WriteLine(c);
            List<BusLineStation> mylistofbuslinestations = new List<BusLineStation>();
            List<BusLineStation> l = new List<BusLineStation>();


            Station s1 = new Station(990, 1, 1);
            BusLineStation s2= new BusLineStation(s1, 10, 10);
            BusLineStation s3 = new BusLineStation(s1, 20, 20);

            Station s6 = new Station(999, 1, 1);
            BusLineStation s4 = new BusLineStation(s1, 25, 25);
            BusLineStation s5 = new BusLineStation(s1, 50, 50);


            //new BusLineStation(990, 20, 20, 20, 20);
            //Station s66 = new BusLineStation(990, 20, 20, 22, 22);
            //Station s3 = new BusLineStation(991, 30, 30, 30, 30);
            //Station s4 = new BusLineStation(991, 30, 30, 60, 60);
            //Station s6 = new BusLineStation(995, 70, 70, 70, 70);

            //  Station.AllStations.Add(s1);
            //Station.AllStations.Add(s2);



            //  Station.AllStations.Add(s3);
            mylistofbuslinestations.Add((BusLineStation)s2);
            l.Add((BusLineStation)s3);
            mylistofbuslinestations.Add((BusLineStation)s4);
          //  l.Add((BusLineStation)s1);
            l.Add((BusLineStation)s5);
           // l.Add((BusLineStation)s6);

            // a retenir le add rajoute a la fin de la liste 
            Line mylinebus = new Line(21, mylistofbuslinestations, (EnumArea)3);
            Line myl = new Line(39, l, (EnumArea)3);

            // Console.WriteLine(mylinebus);
            // mylinebus.AddStationToLine(new BusLineStation(1000, 5, 5, 5, 5), 2);
            // Console.WriteLine(mylinebus);
            //  mylinebus.DeleteStationOfLine(9);
            //  Console.WriteLine(mylinebus);
            //if (mylinebus.StationIsInLine(s3)) Console.WriteLine("the station is in line 21");
            //else Console.WriteLine("the station isnt is line 21");
            // Console.WriteLine(mylinebus.TimeBetweenTwo((BusLineStation)s3, (BusLineStation)s2));
            // Console.WriteLine(mylinebus.SubLine((BusLineStation)s2, (BusLineStation)s5));
            Console.WriteLine( myl.Choice(mylinebus, s1, s6));
            Console.ReadLine();
            Console.ReadLine();
        }
    }
}
