using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DO
{
    public enum State
    {
        readyToTravel,          //0: ready to travel 
        travelling,             //1: in travel
        gazoline,               //2: refueling
        overhaul                //3: in overhaul
    }
    public enum Areas
    {
        General,            //0
        North,              //1
        South,              //2
        Center,             //3
        Jerusalem           //4
    };
}


