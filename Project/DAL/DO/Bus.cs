using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DO
{
    class Bus
    {
        public int LicenseNum { get; set; }                                  //attention ca doit etre unique //bus number
        public DateTime FirstActivity { get; set; }                          //date of its first activity
        public double TotalTrip { get; set; }                                //mileage
        public int FuelRemain { get; set; }                                  //amount of gasoline remaining   
        public State BusState { get; set; }                                  //data to know if the bus is able to travel
        public int MaxTravellers { get; set; }                               //meda optionel //maximum of travellers the bus can travel with
                                                                                
    }
}
