using System;
using System.Collections.Generic;

namespace dotNet5781_02_4625_0728
{
     class Line : IComparable<Line>
     {
        public int LineKey { get; set; }
   //     public readonly int LineKey;                            //num of the bus 
        public List<BusLineStation> StationsList;               //list of stations of the line 
        public BusLineStation FirstStation { get; set; }
        public BusLineStation LastStation { get; set; }
        public EnumArea Area { get; set; }
        public double Time { get; set; }                        //Time of the whole travel of the line 
        public Line() {}                                        //ctor empty

        public Line(int myLine, List<BusLineStation> myStationsList, int myArea)       //ctor
        {
            LineKey = myLine;
            StationsList = myStationsList;
            Area = (EnumArea)myArea;
            if (StationsList.Count != 0)
            {
                FirstStation = myStationsList[0];
                LastStation = myStationsList[(myStationsList.Count) - 1];
                Time = TimeBetweenTwo(FirstStation, LastStation);
            }
        } 

        public void AddStationToLineHelp(BusLineStation b, int index)       // add Station to LineBus when we send Station and place in the list where we want to add it 
        {
            try
            {
                if (index > StationsList.Count)
                    throw new ArgumentException("The index isn't within the expected range.");
                StationsList.Insert(index, b);
                FirstStation = StationsList[0];                             //updates the first station
                LastStation = StationsList[(StationsList.Count) - 1];       //updates the last station
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void DeleteStationOfLine(int toDelete)                       //delete Station of a LineBus when we send the key of the station to delete
        {
            BusLineStation b = FindItemInList(toDelete);
            if (b != null)
            {
                if (StationsList.Count > 2)
                {
                     StationsList.Remove(b);
                     FirstStation = StationsList[0];                             //updates the first station of the line
                     LastStation = StationsList[(StationsList.Count) - 1];       //updates the last station of the line 
                    Console.WriteLine("succes");
                }
                else
                {
                    Console.WriteLine("You can't remove a station of this line because it's the only station of this line");
                }
            }
            else
            {
                Console.WriteLine("this station doesn't exist");
            }
        }

        public BusLineStation FindItemInList(int KeyToFind)                // we send a station key and the function returns Station in LineBus if it is.
        {
            if (StationsList != null)
            {
                foreach (BusLineStation item in StationsList)
                {
                    if (item.StationKey == KeyToFind)
                    {
                        return item;
                    }
                }
            }
            else
            {
                Console.WriteLine("this station doesn't exist");
            }
            return null;
        }


        //old tostring
        //public override string ToString()                                  //override ToString for a line 
        //{
        //    return "Stations of the line:" + PrintList() + "\nBus number: " + LineKey + "\nArea :" + Area;
        //}

        //new to string
        public override string ToString()                                  //override ToString for a line 
        {
            return "bus" + LineKey;
        }

        public string PrintList()
        {
            foreach (BusLineStation item in StationsList)
                Console.WriteLine(item.StationKey);
            return " ";
        }

        public bool StationIsInLine(Station s)                            //boolean function to check if a station is in a line  
        {
            foreach (BusLineStation item in StationsList)
                if (item.StationKey == s.StationKey)
                {
                    return true;
                }
            return false;
        }

        public int FindPlaceInList(BusLineStation b)                      //This function is used when we send to the user a buslinestation with all its parameters and we want to know where this buslinestation is in the list
        {                                                                 
            int mycount = 0;
            foreach (BusLineStation item in StationsList)
            {
                if (item.Equals(b))                                       //Therefore,check all the parameters of the station
                      return mycount;
                mycount++;
            }
            return -1;                    
        }
        public int FindPlaceInList2(BusLineStation b)                     //This function is used when a user just know the Stationkey of a busLineStation and wants to know what is the place in the list of the "real" buslinestation(ie with all its parameters) 
        {
            int mycount = 0;
            foreach (BusLineStation item in StationsList)
            {
                if (item.StationKey == b.StationKey)                    //Therefore,check just if the station key is the same
                    return mycount;
                mycount++;
            }
            //Console.WriteLine("this station doesn't exist");
            return -1;                       
        }

        public double DistanceBetweenTwo(BusLineStation s1, BusLineStation s2)  //finds the distance between two stations in a line
        {
            int indexS1, indexS2;
            Index(s1, s2, out indexS1, out indexS2);                             //finds the indexes of the stations in the line

            if ((indexS1 != -1) && (indexS2 != -1))
            {
                double distance = 0;
                if (indexS1 != indexS2)
                {
                    for (int i = ++indexS1; i <= indexS2; i++)
                    {
                        distance += StationsList[i].DistanceFromLastStation;      //calculates the distance 
                    }
                }
                return distance;
            }
            Console.WriteLine("We haven't found one of the station, in this line"); 
            return -1;
        }

        public double TimeBetweenTwo(BusLineStation s1, BusLineStation s2)      //finds the time between two stations in a line
        {
            int indexS1, indexS2;
            Index(s1, s2, out indexS1, out indexS2);                            //finds the indexes of the stations in the line

            if ((indexS1 != -1) && (indexS2 != -1))
            {
                double time = 0;
                if (indexS1 != indexS2)
                {
                    for (int i = ++indexS1; i <= indexS2; i++)
                    {
                        time += StationsList[i].TimeFromLastStation;            //calculates the time 
                    }
                }
                return time;
            }
            Console.WriteLine("We haven't found one of the station, in this line");
            return -1;

        }

        public Line SubLine(BusLineStation s1, BusLineStation s2)              
        {
            int indexS1, indexS2;
            Index(s1, s2, out indexS1, out indexS2);                            //finds the indexes of the stations in the line

            if ((indexS1 != -1) && (indexS2 != -1))
            {
                if (indexS1 == indexS2)                                         //if the stations are the same one
                {
                    List<BusLineStation> l1 = new List<BusLineStation>();      
                    l1.Add(s1);
                    return new Line(LineKey, l1, (int)Area);                    //returns a line with a list with just one station
                }
                List<BusLineStation> l2 = new List<BusLineStation>();
                for (int i = indexS1; i <= indexS2; i++)
                {
                    l2.Add(StationsList[i]);
                }
                return new Line(LineKey, l2, (int)Area);                        //returns the subline
            }
            return new Line();
        }

        public void Index(BusLineStation s1, BusLineStation s2, out int indexS1, out int indexS2)  //finds the indexes of the lines 
        {
            indexS1 = FindPlaceInList2(s1);
            indexS2 = FindPlaceInList2(s2);
            if (indexS2 < indexS1)
                Swap(ref indexS1, ref indexS2);   //now, indexS1<indexS2
        }

        public static void Swap(ref int indexS1, ref int indexS2)
        {
            int temp = indexS1;
            indexS1 = indexS2;
            indexS2 = temp;
        }           //function swap

        public int CompareTo(Line other)                                       //fonction CompareTo, interface IComparable
        {
            return Time.CompareTo(other.Time);
        }

        public bool Equals(Line other)                               //2 lines are equals if their key, first and last stations are equals 
        {
            if ((other == null) || (GetType() != other.GetType()) || (LineKey != other.LineKey) || (FirstStation.StationKey != other.FirstStation.StationKey) || (LastStation.StationKey != other.LastStation.StationKey))
            {
                return false;
            }
            return true;
        }

        public Line Choice(Line other, Station beginning, Station end)          //the function returns the shortest travel
        {
            Line choice1 = SubLine(FindItemInList(beginning.StationKey), FindItemInList(end.StationKey)); //choice1 contains the subLine for the first bus (this) 
            Line choice2 = other.SubLine(other.FindItemInList(beginning.StationKey), other.FindItemInList(end.StationKey));  //choice2 contains the subLine for the second bus (other) 
            if (choice1.CompareTo(choice2) == 1) return choice1;
            if (choice1.CompareTo(choice2) == -1) return choice2;
            return choice1;                                                     //it was the same time for both
        }
    }
}
