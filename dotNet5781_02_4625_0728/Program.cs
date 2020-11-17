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
            //    Line mylinebus = new Line(21, mylistofbuslinestations, (EnumArea)3);
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

            #region testspropres
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
            #endregion



            //Station[] listedes40stations = new Station[40];            // g fait une liste de 40 stations
            //for (int i = 0; i < 40; i++)
            //{
            //    listedes40stations[i] = new Station(true);
            //}

            //BusLineStation[] listede100buslinestatons = new BusLineStation[100];
            //for (int i = 0; i < 100; i++)
            //{
            //    listedes40stations[i] = new BusLineStation(listedes40stations[rand.Next(0,40)],true);
            //}

            //for (int i = 0; i < 10; i++)
            //{
            //    List<BusLineStation> mylistofbuslinestations = new List<BusLineStation>() { new BusLineStation };
            //}

            // elish: creer 40 stations puis creer 10 lines ( et leur rentrer des tahanots, ds ttes les lignes fo au moins 2 tahanots, et ds chepacmb de ligne ya plus que 2 tahanots(4) ) puis ajouter les lignes au osef 
            // jimagine que ta une mahlaka liste de ttes les lignes: fonction qui recoit les lignes et rajoute a sa list
            // fonction qui recoit des tahanots et qui les rajoute ds le masloul dune ligne en faisant fonction qui recoit 4 tahanots et qui cree un bus
            // ta 10 bus et 40 tahanot dc ttes tes tahanots vont etre utilisees 


            //   List<Station> listedes40stations = new List<Station>();


            Random rand = new Random(DateTime.Now.Millisecond);

            //static Random rand = new Random(DateTime.Now.Millisecond);


            Station s1 = new Station(true);
            Station s2 = new Station(true);
            Station s3 = new Station(true);
            Station s4 = new Station(true);
            Station s5 = new Station(true);
            Station s6 = new Station(true);
            Station s7 = new Station(true);
            Station s8 = new Station(true);
            Station s9 = new Station(true);
            Station s10 = new Station(true);
            Station s11 = new Station(true);
            Station s12 = new Station(true);
            Station s13 = new Station(true);
            Station s14 = new Station(true);
            Station s15 = new Station(true);
            Station s16 = new Station(true);
            Station s17 = new Station(true);
            Station s18 = new Station(true);
            Station s19 = new Station(true);
            Station s20 = new Station(true);
            Station s21 = new Station(true);
            Station s22 = new Station(true);
            Station s23 = new Station(true);
            Station s24 = new Station(true);
            Station s25 = new Station(true);
            Station s26 = new Station(true);
            Station s27 = new Station(true);
            Station s28 = new Station(true);
            Station s29 = new Station(true);
            Station s30 = new Station(true);
            Station s31 = new Station(true);
            Station s32 = new Station(true);
            Station s33 = new Station(true);
            Station s34 = new Station(true);
            Station s35 = new Station(true);
            Station s36 = new Station(true);
            Station s37 = new Station(true);
            Station s38 = new Station(true);
            Station s39 = new Station(true);
            Station s40 = new Station(true);

            List<BusLineStation> list1 = new List<BusLineStation>() {new BusLineStation(s1, true), new BusLineStation(s2,true), new BusLineStation(s3, true), new BusLineStation(s4, true), new BusLineStation(s5, true) };
            List<BusLineStation> list2 = new List<BusLineStation>() { new BusLineStation(s6, true), new BusLineStation(s7, true), new BusLineStation(s8, true), new BusLineStation(s9, true), new BusLineStation(s10, true) };
            List<BusLineStation> list3 = new List<BusLineStation>() { new BusLineStation(s11, true), new BusLineStation(s12, true), new BusLineStation(s13, true), new BusLineStation(s14, true), new BusLineStation(s15, true) };
            List<BusLineStation> list4 = new List<BusLineStation>() { new BusLineStation(s16, true), new BusLineStation(s17, true), new BusLineStation(s18, true), new BusLineStation(s19, true) , new BusLineStation(s20, true) };
            List<BusLineStation> list5 = new List<BusLineStation>() { new BusLineStation(s21, true), new BusLineStation(s22, true), new BusLineStation(s23, true), new BusLineStation(s24, true), new BusLineStation(s25, true) };
            List<BusLineStation> list6 = new List<BusLineStation>() { new BusLineStation(s26, true), new BusLineStation(s27, true), new BusLineStation(s28, true), new BusLineStation(s29, true), new BusLineStation(s30, true), };
            List<BusLineStation> list7 = new List<BusLineStation>() { new BusLineStation(s31, true), new BusLineStation(s32, true), new BusLineStation(s33, true), new BusLineStation(s34, true), new BusLineStation(s35, true), };
            List<BusLineStation> list8 = new List<BusLineStation>() { new BusLineStation(s36, true), new BusLineStation(s37, true), new BusLineStation(s38, true),new BusLineStation(s39, true), new BusLineStation(s40, true), };
            List<BusLineStation> list9 = new List<BusLineStation>() { new BusLineStation(s1, true), new BusLineStation(s2, true), new BusLineStation(s3, true), new BusLineStation(s28, true), };
            List<BusLineStation> list10 = new List<BusLineStation>() { new BusLineStation(s22, true), new BusLineStation(s1, true), new BusLineStation(s3, true), new BusLineStation(s38, true), };
            List<BusLineStation> list11 = new List<BusLineStation>() { new BusLineStation(s1, true), new BusLineStation(s7, true), new BusLineStation(s8, true), new BusLineStation(s24, true), };
            List<BusLineStation> list12 = new List<BusLineStation>() { new BusLineStation(s29, true), new BusLineStation(s21, true), new BusLineStation(s3, true), new BusLineStation(s23, true), };


            Line line1 = new Line(rand.Next(1, 1000),list1,(EnumArea)rand.Next(0,4));
            Line line2 = new Line(rand.Next(1, 1000), list2, (EnumArea)rand.Next(0, 4));
            Line line3 = new Line(rand.Next(1, 1000), list3, (EnumArea)rand.Next(0, 4));
            Line line4 = new Line(rand.Next(1, 1000), list4, (EnumArea)rand.Next(0, 4));
            Line line5 = new Line(rand.Next(1, 1000), list5, (EnumArea)rand.Next(0, 4));
            Line line6 = new Line(rand.Next(1, 1000), list6, (EnumArea)rand.Next(0, 4));
            Line line7 = new Line(rand.Next(1, 1000), list7, (EnumArea)rand.Next(0, 4));
            Line line8 = new Line(rand.Next(1, 1000), list8, (EnumArea)rand.Next(0, 4));
            Line line9 = new Line(rand.Next(1, 1000), list9, (EnumArea)rand.Next(0, 4));
            Line line10 = new Line(rand.Next(1, 1000), list10, (EnumArea)rand.Next(0, 4));
            Line line11 = new Line(rand.Next(1, 1000), list11, (EnumArea)rand.Next(0, 4));
            Line line12 = new Line(rand.Next(1, 1000), list12, (EnumArea)rand.Next(0, 4));



             
            MyList listLines = new MyList();
            listLines.AddLine(line1);
            listLines.AddLine(line2);
            listLines.AddLine(line3);
            listLines.AddLine(line4); 
            listLines.AddLine(line5); 
            listLines.AddLine(line6); 
            listLines.AddLine(line7); 
            listLines.AddLine(line8); 
            listLines.AddLine(line9); 
            listLines.AddLine(line10);
            listLines.AddLine(line11);
            listLines.AddLine(line12);

            Console.WriteLine("chose one of these options:");
            Console.WriteLine("a: add new line");
            Console.WriteLine("b: add new station to line");
            Console.WriteLine("c: delete line");
            Console.WriteLine("d: delete station of a line");
            Console.WriteLine("e: search the buses which go through a station");
            Console.WriteLine("f: travel");
            Console.WriteLine("g: print all lines");
            Console.WriteLine("h: print list of all stations and these lines");
            Console.WriteLine("i: exit:");
            string ch;

            do
            {
                Console.WriteLine("chose one of the options");
                ch = Console.ReadLine();
                switch (ch)
                {
                    case "a":
                        Console.WriteLine("Which num of line do you want to add");
                        int myLine = int.Parse(Console.ReadLine());
                        Console.WriteLine("In which area is the line?");
                        Console.WriteLine("chose 1 for north, 2 for south, 3 for center, 4 for jerusalem, or 0 to a general line");
                        EnumArea myArea = (EnumArea)int.Parse(Console.ReadLine());
                        List<BusLineStation> myStationsList = new List<BusLineStation>();
                        Line l = new Line(myLine, myStationsList,myArea);
                        listLines.AddLine(l);
                        Console.WriteLine("succes");
                        break;

                    case "b":

                        break;

                    case "c":
                        break;

                    case "d":
                        break;

                    case "e":
                        Console.WriteLine("Enter the bus station you want to search");
                        int s = int.Parse(Console.ReadLine());
                        (listLines.AllLineInStation(s)).Print();
                        break;

                    case "f":
                        int first;

                        break;

                    case "g":
                        break;

                    case "h":
                        break;


                    case "i": Console.WriteLine("bye");
                        break;

                    default: Console.WriteLine("Error");
                        break; 

                }
            } while (ch != "i");





        }
    }
}
