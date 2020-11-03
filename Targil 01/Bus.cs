using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Targil_01
{
    class Bus
    {
        public const int GASOLINE = 1200;                                   //max of gazoline remaining after refueling
        public const int MILEAGE = 20000;                                   //max of mileage remaining before the next overhaul

        public string BusNumber { get; set; }
        public DateTime FirstActivity { get; set; }
        public DateTime LastOverhaul { get; set; }
        public int Gasoline { get; set; }                                   //amount of gasoline remaining   
        public long TotalMileage { get; set; }                              //num of km that the bus travelled since its first activity
        public int Mileage { get; set; }                                    //number of km that the bus can travel before the next overhaul 

        public Bus() { }                                                    //empty ctor 


        public bool gasolineVerification(int km)                            //verify if the bus can travel this num of km before the next refueling
        {
            if (Gasoline - km < 0)
            {
                Console.WriteLine("The bus can't travel,you have to put gasoline");
                return false;
            }
            return true;                                                    //the function return true if the bus can travel whith its amount of gasoline
        }


        public bool mileageVerification(int km)                             //verify if the bus can travel this num of km before the next overhaul
        {
            if (Mileage - km < 0)                                           //check if the num of km won't exceed 20000
            {
                Console.WriteLine("The bus needs overhaul beause the bus will travel more than 20,000 km since the last overhaul");
                return false;
            }
            if (AYearPassed(LastOverhaul, DateTime.Now))                    //check that it is less than a year since the last overhaul
            {
                Console.WriteLine("The bus needs overhaul because a year passed since the last overhaul");
                return false;
            }
            return true;                                                   //the function return true if the bus can travel whith its mileage
        }

        static bool AYearPassed(DateTime former, DateTime recent)          //check if a year passed between two dates 
        {
            TimeSpan Ts = recent - former;
            if (Ts.TotalDays >= 365)
                return true;
            else
                return false;
        }

        public void updateFields(int km)                                   //update fields of bus because a travel 
        {
            Gasoline -= km;
            Mileage -= km;
            TotalMileage += km;
            Console.WriteLine("The bus can travel, the fields of the bus are updated, have a nice trip");
            return;
        }
    }
}
