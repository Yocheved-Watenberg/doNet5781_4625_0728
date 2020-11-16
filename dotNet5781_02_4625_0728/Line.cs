﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotNet5781_02_4625_0728
{
    class Line : IComparable<Line>
    {
        public readonly int LineKey; //num of the bus 
        public List<BusLineStation> StationsList; //list of stations of the line 
        public BusLineStation FirstStation { get; set; }
        public BusLineStation LastStation { get; set; }
        public EnumArea Area { get; set; }
        public float Time { get; set; }

        public Line(int myLine, List<BusLineStation> myStationsList, EnumArea myArea)
        {
            LineKey = myLine;
            StationsList = myStationsList;
            Area = myArea;
            //Area = (enumArea)Enum.Parse(typeof(enumArea), myArea)
            FirstStation = StationsList.First();                            
            //faire gaffe que la first station, son sadé time et distance de la station d'avant  soient 0 
            LastStation = StationsList.Last();
            Time = TimeBetweenTwo(FirstStation, LastStation);
        }  //ctor 
        public Line()
        {
        } //ctor empty

        // il faut faire une fonction a laquelle on envoie un num de tahana et un kav 
        //et elle ns renvoie la place de la tahana ds la liste des tahanots du kav

        public void AddStationToLine(BusLineStation b, int index)   // add Station to LineBus when we send Station and place in the list where we want to add it 
        {
            try
            {
                if (index > StationsList.Count)
                    throw new ArgumentException("The index isn't within the expected range.");
                StationsList.Insert(index, b);
            }
            catch (ArgumentException ex9)
            {
                Console.WriteLine(ex9.Message);
            }
        }

        public void DeleteStationOfLine(int toDelete) //delete Station of a LineBus when we send the key of the station to delete
        {
            BusLineStation b = FindItemInList(toDelete);
            if (b.StationKey!=0)
            {
                StationsList.Remove(b);
            }
        }

        public BusLineStation FindItemInList(int KeyToFind) // we send a station key and the function returns Station in LineBus, else returns an empty one.
        { 
            try
            {
                foreach (BusLineStation item in StationsList)
                { 
                    if (item.StationKey == KeyToFind)
                    {
                        return item;
                    }
                }
                throw new ArgumentException("The bus station doesn't exist in the line");
            }
            catch (ArgumentException ex10)
            {
                Console.WriteLine(ex10.Message);
            }

            return new BusLineStation();
        }

        #region ToStringARevoirCmtPrinterList
        //public override string ToString()
        //{
        //    return "Bus number: " + LineKey + "\nArea: " + Area + "\nStations of the line :" + StationsList.ToString();
        //}
        //public override string ToString()
        //{
        //    return "Bus number: " + LineKey + "\nArea: " + Area + "\nStations of the line :" + PrintList();

        //}

        public override string ToString()
        {
            return "Bus number: " + LineKey + "\nArea :" + Area + "\nStations of the line :" + PrintList();
        }

        //public string PrintList()
        //{
        //    foreach (BusLineStation item in StationsList)
        //        Convert.ToString(item.StationKey);
        //}

        public string PrintList()
        {
            foreach (BusLineStation item in StationsList)
                Console.WriteLine(item.StationKey);
            return " ";
        }

        #endregion

        public bool StationIsInLine (Station s) //function to check if a station is in the line  
        {
            foreach (BusLineStation item in StationsList)
                if (item.StationKey == s.StationKey)
                {
                    return true;
                }
            return false;
        }


        public int FindPlaceInList(BusLineStation b)   //function to find the index of the station in the list of the line, else return -1
        {
            int mycount = 0;
            foreach (BusLineStation item in StationsList)
            {
                if (item == b)
                    return mycount;
                mycount++;
            }
            return -1;                       // faire une hariga ici 
        }



        // pr les trois fonctions a venir : time et distance entre 2 stations, et tat masloul, faire une fonction commune 
        public float DistanceBetweenTwo (BusLineStation s1, BusLineStation s2)
        {
            //fr en sorte que les stations soient rangées ds la liste dans leur ordre du trajet

            int indexS1 = FindPlaceInList(s1);
            int indexS2 = FindPlaceInList(s2);

            if ((indexS1 != -1) && (indexS2 != -1))
            {
                if (indexS1 == indexS2)
                    return 0;
                if (indexS2 < indexS1)
                    Swap(ref indexS1, ref indexS2);               //now, indexS1<indexS2
                float distance = 0;
                for (int i= ++indexS1; i<=indexS2; i++)
                {
                    distance += StationsList[i].DistanceFromLastStation;
                }
                return distance;
            }

            Console.WriteLine("We haven't found one of the station, in this line"); //jeter une harigaaaaaaa
            return -1;
        }

        public float TimeBetweenTwo(BusLineStation s1, BusLineStation s2)
        {
            //fr en sorte que les stations soient rangées ds la liste dans leur ordre du trajet

            int indexS1 = FindPlaceInList(s1);
            int indexS2 = FindPlaceInList(s2);

            if ((indexS1 != -1) && (indexS2 != -1))
            {
                if (indexS1 == indexS2)
                    return 0;
                if (indexS2 < indexS1)
                    Swap(ref indexS1, ref indexS2);   //now, indexS1<indexS2
                float time = 0;
                for (int i = ++indexS1; i <= indexS2; i++)
                {
                    time += StationsList[i].TimeFromLastStation;
                }
                return time;
            }
            Console.WriteLine("We haven't found one of the station, in this line"); //jeter une harigaaaaaaa
            return -1;
           
        }

        public Line SubLine(BusLineStation s1, BusLineStation s2)               //comment appeler le nv kav ??????? pareil que lancien c fo, au autre dou je sais sil est pris ? 
        {
            //fr en sorte que les stations soient rangées ds la liste dans leur ordre du trajet

            int indexS1 = FindPlaceInList(s1);
            int indexS2 = FindPlaceInList(s2);

            if ((indexS1 != -1) && (indexS2 != -1))
            {
                if (indexS1 == indexS2)
                {
                    List<BusLineStation> l1 = new List<BusLineStation>();
                    l1.Add(s1);
                    return new Line(LineKey, l1, Area);
                }
                if (indexS2 < indexS1)
                    Swap(ref indexS1, ref indexS2);   //now, indexS1<indexS2
                List<BusLineStation> l2 = new List<BusLineStation>();
                for (int i = indexS1; i <= indexS2; i++)
                {
                    l2.Add(StationsList[i]);
                }
                return new Line(LineKey, l2,Area);
            }
            Console.WriteLine("We haven't found one of the station, in this line");  //jeter une harigaaaaaaa
            return new Line();                                                     

        }


        public static void Swap(ref int indexS1, ref int indexS2)
        {
            int temp = indexS1;
            indexS1 = indexS2;
            indexS2 = temp;
        }

        public int CompareTo(Line other)
        {
            if (Time < other.Time) return 1;
            if (Time > other.Time)  return -1;
            return 0;
        }

        //faut il faire operateur = 
        //faut il fr une fonction equals

        public Line Choice(Line other, Station beginning, Station end)            //the function returns the shortest 
                                                                                   //cheker les input
        { 
            Line choice1 = SubLine(FindItemInList(beginning.StationKey), FindItemInList(end.StationKey)); //choice1 contains the subLine for the first bus (this) 
            Line choice2 = other.SubLine(other.FindItemInList(beginning.StationKey), other.FindItemInList(end.StationKey));  //choice2 contains the subLine for the second bus (other) 
            if (choice1.CompareTo(choice2) == 1) return choice1;
            if (choice1.CompareTo(choice2) == -1) return choice2;
            return choice1;                                                     //it was the same time for both

        }







        //// override object.Equals
        //public override bool Equals(BusLineStation obj)
        //{
        //    if (obj == null || GetType() != obj.GetType())
        //    {
        //        return false;
        //    }

        //    bool flag = true;

        //    if (StationKey!=

        //    return flag;
        //}

        ////// override object.GetHashCode
        ////public override int GetHashCode()
        ////{
        ////    // TODO: write your implementation of GetHashCode() here
        ////    throw new NotImplementedException();
        ////    return base.GetHashCode();
        ////}



    }


}
