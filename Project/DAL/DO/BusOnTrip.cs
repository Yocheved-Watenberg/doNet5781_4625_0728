﻿using System;

namespace DO
{
    public class BusOnTrip
    {
        public int Id { get; set; }                                          //mispar rats 
        public int LicenseNum { get; set; }                                  //license number,first entity key of the bus
        public int LineId { get; set; }                                      //id of the line,second entity key
        public TimeSpan PlannedTakeOff { get; set; }                         //departure time for the formal line,third entity key
        public TimeSpan ActualTakeOff { get; set; }                          //departure time actually
        public int PrevStation { get; set; }                                 //last station the bus went through
        public TimeSpan PrevStationAt { get; set; }                          //time past in the last station
        public TimeSpan NextStationAt { get; set; }                          //how much time to the next station
        public string DriverName { get; set; }                               //name of the driver
    }
}
