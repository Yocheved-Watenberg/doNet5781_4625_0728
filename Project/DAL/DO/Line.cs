namespace DO
{
   public class Line
    {
        public int Id { get; set; }                                         //pour savoir s il est a jeru ou a tel aviv(rats automati)
        public int Code { get; set; }                                       //line number
        public Enums.Areas Area { get; set; }                              //in which area the bus travel
        public int FirstStation { get; set; }                              //code of the first station
        public int LastStation { get; set; }                              //code of the last station
        public bool IsDeleted { get; set; } = false;
        public override string ToString()                                                //override ToString for a station
        {
            return "Line number:" + Code + ", Area:" + Area;
        }
    }
}
