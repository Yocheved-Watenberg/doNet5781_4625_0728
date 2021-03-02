using System;

namespace DO
{
    public class Trip
    {
        public int Id { get; set; }        
        public string UserName { get; set; }        //name of the user who wants to travel  
        public int LineId { get; set; }             //line number
        public int InStation { get; set; }          //station number the user wants to travel from
        public TimeSpan InAt { get; set; }          //zman alia
        public int OutStation { get; set; }         //station number the user wants to travel to
        public TimeSpan OutAt { get; set; }         //zman yerida
    }
}
