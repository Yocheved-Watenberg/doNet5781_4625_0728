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
            //    a retenir le add rajoute a la fin de la liste
            //    il faudra verifier que ca rajoute bien ds la liste de allstations a chaque appel du banay
            //    et sinn a chaque fois quon cree une station l'ajouter a la liste a l'aide de AllStations.Add(nomdelanouvellestation)

            #region tests 
            //    BusStation b = new BusStation(66551, 22, 24);
            //    BusStation c = new BusStation(555616551, 200, 24);
            //    Console.WriteLine(b.BusStationKey);
            //    Console.WriteLine(c);
            //    List<BusLineStation> mylistofbuslinestations = new List<BusLineStation>();
            //    List<BusLineStation> l = new List<BusLineStation>();
            //    Station s1 = new Station(990, 1, 1);
            //    BusLineStation s2 = new BusLineStation(s1, 10, 10);
            //    BusLineStation s3 = new BusLineStation(s1, 20, 20);
            //    Station s6 = new Station(999, 1, 1);
            //    BusLineStation s4 = new BusLineStation(s1, 25, 25);
            //    BusLineStation s5 = new BusLineStation(s1, 50, 50);
            //    new BusLineStation(990, 20, 20, 20, 20);
            //    Station s7 = new BusLineStation(990, 20, 20, 22, 22);
            //    Station s3 = new BusLineStation(991, 30, 30, 30, 30);
            //    Station s4 = new BusLineStation(991, 30, 30, 60, 60);
            //    Station s6 = new BusLineStation(995, 70, 70, 70, 70);
            //    Station.AllStations.Add(s1);
            //    Station.AllStations.Add(s2);
            //    Station.AllStations.Add(s3);
            //    mylistofbuslinestations.Add((BusLineStation)s3);
            //    l.Add((BusLineStation)s3);
            //    mylistofbuslinestations.Add((BusLineStation)s7);
            //    mylistofbuslinestations.Add((BusLineStation)s6);
            //    mylistofbuslinestations.Add((BusLineStation)s4);
            //    l.Add((BusLineStation)s1);
            //    l.Add((BusLineStation)s5);
            //    l.Add((BusLineStation)s6);
            //   Line mylinebus = new Line(21, mylistofbuslinestations, (EnumArea)3);
            //    mylinebus.StationIsInLine(s7);
            //    Line myl = new Line(39, l, (EnumArea)3);
            //    Console.WriteLine(mylinebus);
            //    mylinebus.AddStationToLine(new BusLineStation(1000, 5, 5, 5, 5), 2);
            //    Console.WriteLine(mylinebus);
            //    mylinebus.DeleteStationOfLine(9);
            //    Console.WriteLine(mylinebus);
            //    if (mylinebus.StationIsInLine(s3)) Console.WriteLine("the station is in line 21");
            //    else Console.WriteLine("the station isnt is line 21");
            //    Console.WriteLine(mylinebus.TimeBetweenTwo((BusLineStation)s3, (BusLineStation)s2));
            //    Console.WriteLine(mylinebus.SubLine((BusLineStation)s2, (BusLineStation)s5));
            //    Console.WriteLine(myl.Choice(mylinebus, s1, s6));
            #endregion


            //Station s1 = new Station(990, 1, 1);                       //beginnig
            //BusLineStation s2 = new BusLineStation(s1, 10, 10);        //21
            //BusLineStation s3 = new BusLineStation(s1, 2, 2);        //39

            //Station s4 = new Station(999, 4, 4);                       //end
            //BusLineStation s5 = new BusLineStation(s4, 45, 45);        //21
            //BusLineStation s6 = new BusLineStation(s4, 50, 50);        //39

            //List<BusLineStation> list21 = new List<BusLineStation>(); //s2 et s5
            //List<BusLineStation> list39 = new List<BusLineStation>(); //s3 et s6

            //list21.Add(s2);
            //list21.Add(s5);
            //list39.Add(s3);
            //list39.Add(s6);

            //Line line39 = new Line(39, list39, (EnumArea)3);
            //Line line21 = new Line(21, list21, (EnumArea)3);
            ////line39.Choice(line21, s1, s4);
            //Console.WriteLine(line39.Choice(line21, s1, s4));
            //Console.ReadLine();

            
Console.WriteLine("e: search the buses which go through a station");
            Console.WriteLine("f: travel");
            MyList listLines = new MyList();
            int s;
            int first;


case "c":Console.WriteLine("Enter the number of the line you want to remove ");
            int line = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the first station of the line");
            int first = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the last station of the line");
            int last = int.Parse(Console.ReadLine());
            List < BusLineStation > bus= new List<BusLineStation>{new BusLineStation(line),new;
            Line n=new Line(line,bus           )
            int station = int.Parse(Console.ReadLine());
            listLines.deleteALine(station);

            public Line(int myLine, List<BusLineStation> myStationsList, EnumArea myArea)
case "e":      Console.WriteLine("Enter the bus station you want to check");
                s = Console.ReadLine();
               listLines.AllLineInStation(stationKey s);
            break;

case "f":
                Console.WriteLine("Enter the number of the first station");
           int firstKey = int.Parse(Console.ReadLine());

            BusLineStation b=  FindItemInList(first)



                MyList path = new MyList();


                foreach (Line item in listLines)
            {
                item.SubLine(first,last)







            }


case "g": listLines.print();
            

case "h":      foreach (Station item in Station.AllStations)
               (listLines.AllLineinStation(item.StationKey)).print;




            













        }
    }
}
