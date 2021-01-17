namespace DO
{
    public class LineStation
    {
        public int LineId { get; set; }                                //pour effacer une station ds une ligne mezae qui va m aider a le fr
        public int StationCode { get; set; }                               //station number(second attribute feature)
        public int LineStationIndex { get; set; }                      //place of the station in the line
        public int PrevStation { get; set; }                           //?
        public int NextStation { get; set; }                           //?
        public override string ToString()                                                //override ToString for a station
        {
            return "Station number: " + StationCode + ",  " + PrevStation + " " + NextStation + " ";
        }
    }
}
