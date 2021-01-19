namespace DO
{
   public class Line
    {
        public int Id { get; set; }                                         //pour savoir s il est a jeru ou a tel aviv(rats automati)
        public int Code { get; set; }                                       //line number
        public Areas Area { get; set; }                                    //in which area the bus travel
        public int FirstStation { get; set; }                              //name of the first station
        public double LastStation { get; set; }                         //name of the last station
        public bool IsDeleted { get; set; } = false; 


    }
}
