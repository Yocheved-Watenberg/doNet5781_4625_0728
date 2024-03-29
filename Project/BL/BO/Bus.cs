﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BL.BO.Enum;

namespace BL.BO
{
    public class Bus
    {
        public int LicenseNum { get; set; }                        //bus number
        public DateTime FromDate { get; set; }                     //date of its first activity
        public double TotalTrip { get; set; }                      //mileage
        public int FuelRemain { get; set; }                        //amount of gasoline remaining   
        public State BusState { get; set; }                        //data to know if the bus is able to travel
        public int MaxTravellers { get; set; }                     //maximum of travellers the bus can travel with
        public Line MyLine { get; set; }                           // a bus goes through a line 
    }
}
