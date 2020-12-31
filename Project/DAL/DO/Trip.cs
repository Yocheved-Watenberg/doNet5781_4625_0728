using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DO
{
    class Trip
    {
        public int Id { get; set; }                 //mezae nessia
        public string UserName { get; set; }        //name of the user who wants to travel  
        public int LineId { get; set; }             //line number
        public int InStation { get; set; }          //station number the user wants to travel from
        public TimeSpan InAt { get; set; }          //zman alia?
        public int OutStation { get; set; }         //station number the user wants to travel to

        public TimeSpan OutAt { get; set; }         //zman yerida
                                                    //attention l'entreprise (utilisateur qui se connecte en tant que manager) n'a pas accès aux informations sur les passagers mais uniquement aux gares / lignes / bus ...


    }
}
