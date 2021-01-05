namespace DO
{
    public class LineStation
    {
        public int LineId { get; set; }                                //line number (first attribute feature)
        public int Station { get; set; }                               //station number(second attribute feature)
        public int LineStationIndex { get; set; }                      //place of the station in the line
        public int PrevStation { get; set; }                           //?
        public int NextStation { get; set; }                           //?
    }
}
