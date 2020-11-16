using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotNet5781_02_4625_0728
{
    public class MyList : IEnumerable
    {
        List<Line> l;
        public MyList()
        {
            l = new List<Line>();
        }

        private void addLine(Line lineToAdd)                            //j met ttes les fonctions en private car il ve pas public, pk?
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

        private void deleteALine(Line line)
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

        private bool IsExist(Line line)
        {
            foreach (Line item in l)
            {
                if (line == item)
                {
                    return true;
                }
            }
            return false ;
        }
        

        //public MyList AllLineInStation(int stationKey)
        //{
        //    MyList listOfLine = new MyList();


        //    foreach (Line item in l)
        //    {
        //        item.
        //    }
        //    //    listOfLine.addLine(a);


        //    return listOfLine;
        //}

        //public MyList SortTime(MyList l)
        //{ 
        //    l.Sort();
        //    return l; 
        //}
            






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






        private Line FindLine(Line line)
        {
            foreach (Line item in l)
            {
                if (line == item)
                {
                    return item;
                }
            }
            return new Line();
        }

        IEnumerator<Line> IEnumerable.GetEnumerator()
        {
            return l.GetEnumerator();                        //return how to scan the list 
        }

    }

    

}
