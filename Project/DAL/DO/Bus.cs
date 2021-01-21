using System;

namespace DO
{
    public class Bus
    {
        public int LicenseNum { get; set; }                                  //attention ca doit etre unique //bus number
        public DateTime FromDate { get; set; }                                //date of its first activity
        public double TotalTrip { get; set; }                                //mileage
        public int FuelRemain { get; set; }                                  //amount of gasoline remaining   
        public Enums.State BusState { get; set; }                                  //data to know if the bus is able to travel
        public int MaxTravellers { get; set; }                               //meda optionel //maximum of travellers the bus can travel with


        //IL NE FAUT PAS METTRE DE CTOR ICI 
        //public Bus(int myLicenseNum, DateTime myFromDate,double myTotalTrip, int myFuelRemain, State myBusState, int myMaxTravellers)
        //{
        //    LicenseNum = myLicenseNum;
        //    FromDate = myFromDate;
        //    TotalTrip = myTotalTrip;
        //    FuelRemain = myFuelRemain;
        //    BusState = myBusState;
        //    MaxTravellers = myMaxTravellers;
        //}
    }
}
