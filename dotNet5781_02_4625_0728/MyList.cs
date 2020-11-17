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

        public MyList SortTime()
        {
            l.Sort();
            return this;
        }

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
            int count = 0;
            foreach (Line item in l)
            {
                if (line == item)
                {
                    return item;
                }
            }
            return -1;
        }




        //private Line FindLine(Line line)
        //{
        //    foreach (Line item in l)
        //    {
        //        if (line == item)
        //        {
        //            return item;
        //        }
        //    }
        //    return new Line();
        //}

        IEnumerator<Line> IEnumerable.GetEnumerator()
        {
            return l.GetEnumerator();                        //return how to scan the list
        }

    }


}
//class MyList : IEnumerable
//{
//    List<Line> l;
//    public MyList()
//    {
//        l = new List<Line>();
//    }
//    static Random rand = new Random(DateTime.Now.Millisecond);

//    //public MyList(int size, size2)
//    //{
//    //    l = new List<Line>();
//    //    for (int i=0; i<size; i++)
//    //    {
//    //        l.Add(new Line(rand.Next(1, 1000), new List<BusLineStation>(size2) , (EnumArea)rand.Next(0, 4)));
//    //    }
//    //}//pb le parametre liste de busline station est vide

//    public void AddLine(Line lineToAdd)                            //j met ttes les fonctions en private car il ve pas public, pk?
//    {
//        try
//        {
//            if (!IsExist(lineToAdd))
//            {
//                l.Add(lineToAdd);
//            }
//            else
//            {
//                throw new ArgumentException("You can't add the line to the list.");
//            }
//        }
//        catch (ArgumentException ex)
//        {
//            Console.WriteLine(ex.Message);
//        }
//    }

//    private void deleteALine(Line line)
//    {
//        try
//        {
//            if (IsExist(line))
//            {
//                l.Remove(line);
//            }
//            else
//            {
//                throw new ArgumentException("You can't delete the line to the list because the line doesn't exist.");
//            }
//        }
//        catch (ArgumentException ex)
//        {
//            Console.WriteLine(ex.Message);
//        }
//    }

//    private bool IsExist(Line line)
//    {
//        foreach (Line item in l)
//        {
//            if (line == item)
//            {
//                return true;
//            }
//        }
//        return false;
//    }

//    public MyList AllLineInStation(int stationKey)
//    {
//        MyList listOfLine = new MyList();
//        foreach (Line item in l)
//        {
//            if (item.FindItemInList(stationKey) != null)
//                listOfLine.AddLine(item);
//        }
//        try
//        {
//            if (listOfLine == null)
//                throw new ArgumentException("there is no bus line that goes through this station");
//        }
//        catch (ArgumentException ex)
//        {
//            Console.WriteLine(ex.Message);
//        }
//        return listOfLine;

//    }

//    public MyList SortTime()
//    {
//        l.Sort();
//        return this;
//    }

//    private Line this[int myLineKey]
//    {
//        get { return l[FindLine(myLineKey)]; }
//        set { l[FindLine(myLineKey)] = value; }
//    }
//    // a partir de now on peut fr MyList[5]= malignepreferee (21) et il nous renvoie la ligne qui est au makom 14 de notre liste


//    //A SUPPRIMERRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRR
//    //public Line KeyStationIsInLine(int myKey) //function to check if a station is in the line  
//    //{
//    //    foreach (BusLineStation item in StationsList)
//    //        if (item.StationKey == myKey)
//    //        {
//    //            return item;
//    //        }
//    //    return new Line();
//    //}


//    private int FindLine(int myLineKey)
//    {
//        int count = 0;
//        foreach (Line item in l)
//        {
//            if (myLineKey != item.LineKey)
//            {
//                count++;
//            }
//            else
//            {
//                return count;
//            }
//        }

//        try
//        {
//            throw new ArgumentException("this line key doesn't exist");
//        }
//        catch (ArgumentException ex)
//        {
//            Console.WriteLine(ex.Message);
//        }
//        return -1;
//    }




//    //private Line FindLine(Line line)
//    //{
//    //    foreach (Line item in l)
//    //    {
//    //        if (line == item)
//    //        {
//    //            return item;
//    //        }
//    //    }
//    //    return new Line();
//    //}

//    IEnumerator<Line> IEnumerable.GetEnumerator()
//    {
//        return l.GetEnumerator();                        //return how to scan the list
//    }


//}

//‪Le lun. 16 nov. 2020 à 19:1
