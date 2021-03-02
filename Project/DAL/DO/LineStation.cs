namespace DO
{
    public class LineStation
    {
        public int LineCode { get; set; }                              //line number
        public int StationCode { get; set; }                           //station number
        public int LineStationIndex { get; set; }                      //place of the station in the line
        public int PrevStation { get; set; }                           //previous station
        public int NextStation { get; set; }                           //next station
        
    }
}
