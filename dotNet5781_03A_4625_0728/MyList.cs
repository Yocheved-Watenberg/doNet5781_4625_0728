using System;
using System.Collections;
using System.Collections.Generic;

namespace dotNet5781_02_4625_0728
{
    class MyList : IEnumerable
    {
        public List<Line> l;
        public MyList()             //ctor 
        {
            l = new List<Line>();
        }

        public void AddLine(Line lineToAdd)                   //function to add a line to MyList
        {
            try
            {
                if (!IsExist(lineToAdd))
                {
                    l.Add(lineToAdd);
                }
                else
                {
                    throw new ArgumentException("You can't add the line to the list.");
                }
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void deleteALine(Line line)                    //function to delete a line in MyList 
        {
            try
            {
                if (IsExist(line))
                {
                    l.Remove(line);
                }
                else
                {
                    throw new ArgumentException("You can't delete the line to the list because the line doesn't exist.");
                }
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public bool IsExist(Line line)                        //boolean function to check if a line exist in MyList
        {
            foreach (Line item in l)
            {
                if ((line.LineKey == item.LineKey) && (line.FirstStation == item.FirstStation) && (line.LastStation == item.LastStation))
                    return true;
            }
            return false;
        }

        public int HowManyIsExist(int KeyOfLine)              //this function return 1, 2, or 0 for the number of times that this line is in the list
        {
            int count = 0;
            foreach (Line item in l)
            {
                if (KeyOfLine == item.LineKey)
                {
                    count++;
                }
            }
            return count;
        }

        public MyList AllLineInStation(int stationKey)        //we send a station key to the function and the function returns a list of lines which go through this station
        {
            MyList listOfLine = new MyList();
            foreach (Line item in l)                            //for each line of MyList
            {
                if (item.FindItemInList(stationKey) != null)    //if the line goes through this station 
                    listOfLine.AddLine(item);                   //put the line in a new list
            }
            try
            {
                if (listOfLine == null)
                    throw new ArgumentException("there is no bus line that goes through this station");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
            return listOfLine;                                  //returns the list of lines which go through this station
        }

        public void Print()                                   //print the lines of MyList
        {
            if (l.Count != 0)
            {
                for (int i = 0; i < l.Count; i++)
                    Console.WriteLine(l[i].LineKey);
            }
            else
            {
                Console.WriteLine("there isn't any lines in the list");
            }
        }

        public MyList SortTime()                              //sort the list of lines (compared to their time) 
        {
            l.Sort();
            return this;
        }

        //public Line this[int myLineKey]                          //indexer 
        //{         
        //    get { if (myLineKey == -1) myLineKey = 21;  return l[FindLineIndex(myLineKey)]; }
        //    set { l[FindLineIndex(myLineKey)] = value; }
        //}

        public Line this[int i]                                //indexer?
        {
            get { return l[i]; }
            set { l[i] = value; }
        }

        public int FindLineIndex(int myLineKey)                 //we send a num of line and the function return the index of the first apparition of the line in the list
        {
            int count = 0;
            foreach (Line item in l)
            {
                if (myLineKey != item.LineKey)
                {
                    count++;
                }
                else
                {
                    return count;
                }
            }

            try
            {
                throw new ArgumentException("this line key doesn't exist");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
            return -1;
        }

        public Line FindLine(int myKey, int myFirst, int myLast)     // we send the parameters and its returns the line of my list with these parameters
        {
            foreach (Line item in l)
            {
                if ((myKey == item.LineKey) && (myFirst == item.FirstStation.StationKey) && (myLast == item.LastStation.StationKey))
                {
                    return item;
                }
            }
            return new Line();
        }

       public  IEnumerator GetEnumerator()                  //for the interface IEnumerable, we have to do the function GetEnumerator 
        {
            return l.GetEnumerator();                        //return how to scan MyList : like a List 
        }

    }



}