using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotNet5781_02_4625_0728
{

    class MyList : IEnumerable
    {
        List<Line> l;
        public MyList()
        {
            l = new List<Line>();
        }
        static Random rand = new Random(DateTime.Now.Millisecond);

        //public MyList(int size, size2)
        //{
        //    l = new List<Line>();
        //    for (int i=0; i<size; i++)
        //    {
        //        l.Add(new Line(rand.Next(1, 1000), new List<BusLineStation>(size2) , (EnumArea)rand.Next(0, 4)));
        //    }
        //}//pb le parametre liste de busline station est vide

        public void AddLine(Line lineToAdd)                            //j met ttes les fonctions en private car il ve pas public, pk?
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

        public void deleteALine(Line line)
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

        //public bool IsExist(Line line)
        //{
        //    foreach (Line item in l)
        //    {
        //        if (line == item)
        //        {
        //            return true;
        //        }
        //    }
        //    return false ;
        //}



        public bool IsExist(Line line)
        {
            foreach (Line item in l)
            {
                if ((line.LineKey == item.LineKey) && (line.FirstStation == item.FirstStation) && (line.LastStation == item.LastStation))
                    return true;
            }
            return false;
        }


        public int HowManyIsExist(int KeyOfLine)          //this function return 1, 2, or 0 for the number of times that this line is in the list
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




        public MyList AllLineInStation(int stationKey)
        {
            MyList listOfLine = new MyList();
            foreach (Line item in l)
            {
                if (item.FindItemInList(stationKey) != null)
                    listOfLine.AddLine(item);
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
            return listOfLine;

        }


        public void Print()                             //print the lines of the station
        {
            if (l.Count != 0)
            {
                // Console.WriteLine("The lines are:");
                for (int i = 0; i < l.Count; i++)
                    Console.WriteLine(l[i].LineKey);
            }
            else
            {
                Console.WriteLine("there isn't any buses in this station");
            }


        }

        public MyList SortTime()
        {
            l.Sort();
            return this;
        }

        public Line this[int myLineKey]
        {
            get { return l[FindLine(myLineKey)]; }
            set { l[FindLine(myLineKey)] = value; }
        }
        // a partir de now on peut fr MyList[5]= malignepreferee (21) et il nous renvoie la ligne qui est au makom 14 de notre liste


        //A SUPPRIMERRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRR
        //public Line KeyStationIsInLine(int myKey) //function to check if a station is in the line  
        //{
        //    foreach (BusLineStation item in StationsList)
        //        if (item.StationKey == myKey)
        //        {
        //            return item;
        //        }
        //    return new Line();
        //}


        public int FindLine(int myLineKey)                     //jenvoie un numero de ligne et il me sort la premiere apparation de la ligne ds la liste 
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

        public Line FindLineYoko(int myKey, int myFirst, int myLast)           //a supprimer pr avi 
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


        public Line FindLine(Line line)             //we send a line to the function and the fonction return this line of the list 
        {
            foreach (Line item in l)
            {
                if (line.Equals(item))
                {
                    return item;
                }
            }
            return new Line();
        }


        public IEnumerator GetEnumerator()
        {
            return l.GetEnumerator();                        //return how to scan the list 
        }


    }



}