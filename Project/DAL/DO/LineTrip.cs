using System;

namespace DO
{
    public class LineTrip
    {
        public int Id { get; set; }                      //mispar ratz 
        public int LineId { get; set; }                  //line number(first entity key)
        public TimeSpan StartAt { get; set; }            //departure time(second entity key)
        public TimeSpan Frequency { get; set; }          //how often the bus goes out to the line?(if 0 one travel only)
        public TimeSpan FinishedAt { get; set; }         //time the bus stops its activity(only if the frequency is different than 0)//fr gaffe aux bus urbains la frequence varie en fonction de la journée(plusieurs)
    }
}

