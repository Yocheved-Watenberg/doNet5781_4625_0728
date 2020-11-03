using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Targil_01
{
    class Program
    {
        static void Main(string[] args)
        {
            #region switchChoice
            List<Bus> l = new List<Bus>();                                                      //create the list of buses
            string num;
            do
            {
                Console.WriteLine("\n \n \n Choose 1 to add a bus \n");                        //print the 5 possibilities for the user
                Console.WriteLine("Choose 2 to choose a bus to travel \n");
                Console.WriteLine("Choose 3 to perform refueling or maintenance of a bus\n ");
                Console.WriteLine("Choose 4 to view the mileage of the buses \n");
                Console.WriteLine("Choose 5 to exit \n");
                num = Console.ReadLine();                                                      //the user enter a value 
                switch (num)                                                                   //switch with this value
                {
                    case "1":
                        addBusToList(l);                                                       // if case 1, 2, 3 or 4, go to the appropriate function
                        break;
                    case "2":
                        busTravel(l);
                        break;
                    case "3":
                        busModification(l);
                        break;
                    case "4":
                        displayMileage(l);
                        break;
                    case "5":
                        Console.WriteLine("exit");                                            //if case 5, print "exit" and exit
                        break;
                    default:
                        Console.WriteLine("ERROR\n");                                         //if other, print "error" and exit 
                        break;
                }
            } while (num != "5");                                                               //start the loop again until the user choose 5-exit

        }
        #endregion

        #region auxiliaryMethods
        // Auxiliary method wich return num of bus 

        private static string whichBus()
        {
            Console.WriteLine("What is the bus number?");
            string num = Console.ReadLine();
            while (!numIsCorrect(num))
            {
                Console.WriteLine("the num isn't valid, please enter a number on format xx-xxx-xx if it first activity before 2018, else xxx-xx-xxx ");
                num = Console.ReadLine();
            }
            return num;
        }

        // Auxiliary method wich check if the num of the bus is in good format 
        private static bool numIsCorrect(string num)
        {
            if ((num.Length != 9) && (num.Length != 10)) { return false; }                              //the string have to be 9 or 10
            else
            {
                if (num.Length == 9)
                    for (int i = 0; i < 9; i++)
                    {
                        int eachnum = Convert.ToInt32(num[i]);
                        if (((eachnum > 57) || (eachnum < 48)) && (eachnum != 45)) { return false; }    //check if all char in the string is number or '-'
                    }

                else if (num.Length == 10)
                    for (int i = 0; i < 10; i++)
                    {
                        int eachnum = Convert.ToInt32(num[i]);
                        if (((eachnum > 57) || (eachnum < 48)) && (eachnum != 45)) { return false; }    ////check if all char in the string is number or '-'
                    }
                return true;
            }
        }

        // Auxiliary method which return the place of the bus in the list if the bus exist 

        private static int search(List<Bus> l, string bus)

        {
            int place = -1;
            for (int i = 0; i < l.Count; i++)                                   //to verify all the buses in the list 
            {

                if (l[i].BusNumber == bus)                                      //if one of the bus num in the list is equal to the bus num that we search
                {
                    place = i;                                                  //change the value place to the place of the bus that we search 
                    break;                                                      //if we found the place of the bus, stop the search
                }

            }
            if (place == -1)                                                    //if we didn't find the bus in the list
            {
                Console.WriteLine("this bus doesn't exist, next time, chose another bus number");

            }
            return place;
        }
        #endregion

        #region Case1

        private static void addBusToList(List<Bus> l)
        {

            Bus b = new Bus() { };
            addName(l, b);
            addDate(b);
            while ((b.FirstActivity.Year > 2018) && (b.BusNumber[2] == 45))                                   //check if the format of the name of the bus corresponding to it year
            {
                Console.WriteLine("the buses on format xx-xxx-xx are the buses before 2018, try again");
                addDate(b);
            }
            while ((b.FirstActivity.Year < 2018) && (b.BusNumber[3] == 45))
            {
                Console.WriteLine("the buses on format xxx-xx-xxx are the buses after 2018, try again");
                addDate(b);
            }
            b.LastOverhaul = b.FirstActivity;                                   //initialize lastOverhaul
            b.Gasoline = Bus.GASOLINE;                                          //initialize gasoline to max
            b.Mileage = Bus.MILEAGE;                                            //initialize mileage to max
            b.TotalMileage = 0;                                                 //initialize totalMileage
            l.Add(b);                                                           //add the new bus to the list
            Console.WriteLine("The bus has been added to the list!");
            return;
        }

        private static void addName(List<Bus> l, Bus b)
        {
            string id = whichBus();                                             //input the num of the bus 
            while (checkIfAlreadyExist(l, id))                                  //check if there isn't any else bus with the same name 
            {
                id = whichBus();
            }
            b.BusNumber = id;
        }

        private static bool checkIfAlreadyExist(List<Bus> l, string id)
        {
            for (int i = 0; i < l.Count; i++)                                 //for each member of the list 
            {
                if (id == l[i].BusNumber)                                     //if the new name is same that one of the bus 
                {
                    Console.WriteLine("this bus is already in the list, choose another bus number");
                    return true;
                }
            }
            return false;
        }

        private static void addDate(Bus b)
        {
            Console.WriteLine("What is the date of its first activity? Please enter it on the format : 'DD/MM/YYYY HH:MM:SS AM' ");
            string myDate = Console.ReadLine();                                   //input date
            while (!DateTime.TryParse(myDate, out DateTime result))               //check the format
            {
                Console.WriteLine("please enter the date with the good format : 'DD/MM/YYYY HH:MM:SS AM'");
                myDate = Console.ReadLine();
            }
            b.FirstActivity = DateTime.Parse(myDate);
        }


        #endregion

        #region Case2

        private static void busTravel(List<Bus> l)
        {

            int place = search(l, whichBus());                                  //search a bus in the list 
            if (place != -1)                                                    //if the bus is in the list
            {
                Random r = new Random(DateTime.Now.Millisecond);
                int km = r.Next(1200);                                          //the program randomally decides a number of km of travel


                if (l[place].gasolineVerification(km))                          //if there is enought gasoline available
                {
                    if (l[place].mileageVerification(km))                       //and if there is enought mileage available 
                    {
                        l[place].updateFields(km);                              //the prgm have to update the fields of the bus
                    }

                }
            }
            return;
        }

        #endregion

        #region Case3 
        private static void busModification(List<Bus> l)
        {
            int place = search(l, whichBus());
            if (place != -1)                                                    //if the bus is in le list
            {
                Console.WriteLine("What do you want to change ? \n 1=refueling \n 2=overhaul ");
                string change = Console.ReadLine();                      //converse to int the choice of the user : 1 for refueling ; 2 for overhaul
                if (change == "1")                                                 //if refueling 
                {
                    l[place].Gasoline = Bus.GASOLINE;                            //update the field gasoline to max 
                    Console.WriteLine("The refueling was successfully completed");
                }
                else
                {
                    if (change == "2")                                             //if overhaul
                    {
                        l[place].LastOverhaul = DateTime.Now;                     //update the field lastOverhaul to the current DateTime
                        l[place].Mileage = Bus.MILEAGE;                           //update de the filed  mileage to max
                        Console.WriteLine("The overhaul was successfully completed");
                    }
                    else
                    {
                        Console.WriteLine("error");                             //if the user choice wasn't 1 or 2 
                    }
                }
            }
            return;

        }
        #endregion


        #region Case4 
        private static void displayMileage(List<Bus> l)
        {
            if (l.Count != 0)
            {

                for (int i = 0; i < l.Count; i++)                                                          //for each bus of the list
                {
                    Console.WriteLine(l[i].BusNumber + "\t" + (Bus.MILEAGE - l[i].Mileage) + "\n");        //print the bus number and its mileage 
                }

            }
            else
            {
                Console.WriteLine("there isn't any bus in the list");
            }
            return;
        }
        #endregion

    }

}
