using System;

namespace DO
{
    public class Bus
    {
        public int LicenseNum { get; set; }                                  //bus number
        public DateTime FromDate { get; set; }                               //date of its first activity
        public double TotalTrip { get; set; }                                //mileage
        public int FuelRemain { get; set; }                                  //amount of gasoline remaining   
        public Enums.State BusState { get; set; }                            //data to know if the bus is able to travel
        public int MaxTravellers { get; set; }                               //maximum of travellers the bus can travel with
    }
}
